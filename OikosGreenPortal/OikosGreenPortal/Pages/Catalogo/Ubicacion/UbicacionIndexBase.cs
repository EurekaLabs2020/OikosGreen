using Blazored.Modal.Services;
using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;
using OikosGreenPortal.Data.Personal;
using OikosGreenPortal.Data.Request;
using OikosGreenPortal.PersonalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Pages.Catalogo.Ubicacion
{
    public class UbicacionIndexBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }


        public List<Ubicacion_data> _lista { get; set; }
        public List<Ubicacion_data> _listaSecundaria { get; set; }
        public Ubicacion_data _regActual { get; set; }
        public List<String> _listaTipoUbicacion { get; set; }
        public Int64 _datoPadre { get; set; }
        public String _datoTipoUbicacion
        {
            get { return datoTipoUbicacion; }
            set
            {
                datoTipoUbicacion = value;
                _datoPadre = 0;
                if (datoTipoUbicacion == _listaTipoUbicacion[0] || datoTipoUbicacion=="0")
                    _listaSecundaria = null;
                else if (datoTipoUbicacion == _listaTipoUbicacion[1])
                    _listaSecundaria = _lista.Where(w => w.type!=null && w.type.Trim().ToUpper() == _listaTipoUbicacion[0]).ToList();
                else
                    _listaSecundaria = _lista.Where(w => w.type != null && w.type.Trim().ToUpper() == _listaTipoUbicacion[1]).ToList();
            }
        }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }
        
        private infoBrowser _dataStorage { get; set; }
        private String datoTipoUbicacion { get; set; }
        private Boolean isok { get; set; } = false;
        private String urlgetall { get; set; } = Urls.urlubicacion_getall;
        private String urlinsert { get; set; } = Urls.urlubicacion_insert;
        private String urlupdate { get; set; } = Urls.urlubicacion_update;
        private String urlinactive { get; set; } = Urls.urlubicacion_inactive;
        private String urlgetcode { get; set; } = Urls.urlubicacion_getbycode;



        protected async override Task OnInitializedAsync()
        {
            _lista = new List<Ubicacion_data>();
            _listaSecundaria = null;
            _datoPadre = 0;
            _Mensaje = "";
            _regActual = new Ubicacion_data();
            TipoUbicacion tipoUbica = new TipoUbicacion();
            _listaTipoUbicacion = tipoUbica.tiposUbicaciones();
            UbicacionesRequest _dataRequest = new UbicacionesRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", urlgetall, "");
                _dataRequest = JsonConvert.DeserializeObject<UbicacionesRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                {
                    _listaSecundaria = _lista = _dataRequest.entities;
                    _listaSecundaria = _lista.OrderBy(o => o.type).OrderBy(o => o.name).ToList();
                }

            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal);
            }
        }

        #region Presentación
        public void estilofila(Ubicacion_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Ubicacion_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion


        public Boolean validaDatos(Ubicacion_data _paraValidar)
        {
            _Mensaje = "";
            _mensajeIsDanger = "alert-danger";
            if (_paraValidar.name==null)
                _Mensaje += "Por favor diligenciar el NOMBRE, es un campo obligatorio.&s";
            if (_paraValidar.code==null)
                _Mensaje += "Por favor diligenciar el CODIGO, es un campo obligatorio.&s";
            if (_paraValidar.type==null)
                _Mensaje += "Por favor diligenciar el TIPO, es un campo obligatorio.&s";
            else if(_paraValidar.type != _listaTipoUbicacion[0])
                 if (_paraValidar.nameparent==null)
                    _Mensaje += "Por favor diligenciar el PADRE, es un campo obligatorio.&s";


            if (_Mensaje.Trim().Length > 0)
                return false;
            return true;
        }

        public void iniciaDatos(Ubicacion_data data)
        {
            data.type = "";
            _listaSecundaria = _lista.OrderBy(o => o.type).OrderBy(o => o.name).ToList();
            _Mensaje = "";
        }

        public async Task insertFila(SavedRowItem<Ubicacion_data, Dictionary<String, object>> e)
        {
            e.Item.id = await setUbicacion(e.Item, true, urlinsert);
        }

        public async Task updateFila(SavedRowItem<Ubicacion_data, Dictionary<String, object>> e)
        {
            await setUbicacion(e.Item, false, urlupdate);
        }

        public async Task inactiveFila(Ubicacion_data item)
        {
            item.active = !item.active;
            try
            {
                var resultado = await General.solicitudUrl<Ubicacion_data>(_dataStorage.user.token, "POST", urlinactive, item);
                UbicacionRequest _dataRequest = JsonConvert.DeserializeObject<UbicacionRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest == null || _dataRequest.entity == null || _dataRequest.entity.id == 0)
                    item.active = !item.active;
            }
            catch (Exception) { item.active = !item.active; }
        }

        private void datosAdicionales(Boolean isNuevo, ref Ubicacion_data item)
        {
            if (isNuevo)
            {
                item.usercreate = _dataStorage.user.user;
                item.datecreate = DateTime.Now;
                item.active = true;
            }
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
        }

        private async Task<Int64> setUbicacion(Ubicacion_data Item, Boolean Crear, String Url)
        {
            Int64 retorno = 0;
            isok = false;
            //Item.type = _datoTipoUbicacion;
            //Item.parent = _datoPadre;
            if(Item.type==_listaTipoUbicacion[0])
            {
                Item.parent = 0;
                Item.nameparent = "";
            }
            else
                Item.nameparent = _lista.Where(w => w.id == Item.parent).Select(s => s.name).FirstOrDefault();
            Item.name = Item.name.ToUpper();
            Ubicacion_data reg = Item;
            datosAdicionales(Crear, ref reg);
            if (validaDatos(Item))
            {
                var resultadoCode = await General.solicitudUrl<Ubicacion_data>(_dataStorage.user.token, "POST", urlgetcode, reg);
                UbicacionRequest _dataRequestCode = JsonConvert.DeserializeObject<UbicacionRequest>(resultadoCode.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestCode!=null && (_dataRequestCode.status.code != 200 || !Crear))
                {
                    try
                    {
                        var resultado = await General.solicitudUrl<Ubicacion_data>(_dataStorage.user.token, "POST", Url, reg);
                        UbicacionRequest  _dataRequest = JsonConvert.DeserializeObject<UbicacionRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                        if (_dataRequest != null && _dataRequest.status != null && _dataRequest.status.code == 200)
                        {
                            if (_dataRequest.entity != null && _dataRequest.entity.id > 0)
                            {
                                isok = true;
                                retorno = _dataRequest.entity.id;
                            }
                        }
                        else
                            _Mensaje = _dataRequest.status.message;
                    }
                    catch (Exception ex) { _Mensaje = ex.Message; }
                }
                else 
                    _Mensaje = "Por favor revisar, el registro se encuentra duplicado.&s";
            }
            StateHasChanged();
            if (!isok && Crear)
                _lista.Remove(reg);
            return retorno;
        }


    }
}
