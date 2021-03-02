using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Modal.Services;
using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;
using OikosGreenPortal.Data.Personal;
using OikosGreenPortal.Data.Request;
using OikosGreenPortal.PersonalClass;

namespace OikosGreenPortal.Pages.Catalogo.Opcion
{
    public class OpcionIndexBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Opcion_data> _lista { get; set; }
        public List<Opcion_data> _listaSecundaria { get; set; }
        public Opcion_data _regActual { get; set; }
        public List<String> _listaTipoOpcion { get; set; }
        public Int64 _datoPadre { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }
        private infoBrowser _dataStorage { get; set; }
        private String datoTipoOpcion { get; set; }
        public String _datoTipoOpcion
        {
            get { return datoTipoOpcion; }
            set 
            {
                datoTipoOpcion = value;
                _datoPadre = 0;
            }
        }
        private Boolean isok { get; set; } = false;
        private String urlgetall { get; set; } = Urls.urlopcion_getall;
        private String urlinsert { get; set; } = Urls.urlopcion_insert;
        private String urlupdate { get; set; } = Urls.urlopcion_update;
        private String urlinactive { get; set; } = Urls.urlopcion_inactive;
        private String urlgetcode { get; set; } = Urls.urlopcion_getbycode;

        protected async override Task OnInitializedAsync()
        {
            _lista = new List<Opcion_data>();
            _listaSecundaria = null;
            _datoPadre = 0;
            _Mensaje = "";
            _regActual = new Opcion_data();
            TipoOpcion tipoOpcion = new TipoOpcion();
            _listaTipoOpcion = tipoOpcion.tiposOpciones();
            OpcionesRequest _dataRequest = new OpcionesRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", urlgetall, "");
                _dataRequest = JsonConvert.DeserializeObject<OpcionesRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities;
                try
                {
                    var resultadoPadre = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", urlgetall, "");
                    OpcionesRequest _dataRequestPadre = JsonConvert.DeserializeObject<OpcionesRequest>(resultadoPadre.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestPadre != null && _dataRequestPadre.entities != null && _dataRequestPadre.entities.Count > 0)
                        _listaSecundaria = _dataRequestPadre.entities.Where(w=> w.type =="MENU").ToList();
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal); }

            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal);
            }
        }

        #region Presentación
        public void estilofila(Opcion_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Opcion_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion


        public Boolean validaDatos(Opcion_data _paraValidar)
        {
            _Mensaje = "";
            _mensajeIsDanger = "alert-danger";
            if (_paraValidar.name == null)
                _Mensaje += "Por favor diligenciar el NOMBRE, es un campo obligatorio.&s";
            if (_paraValidar.code == null)
                _Mensaje += "Por favor diligenciar el CODIGO, es un campo obligatorio.&s";
            if (_paraValidar.type == null)
                _Mensaje += "Por favor diligenciar el TIPO, es un campo obligatorio.&s";
            
            if (_Mensaje.Trim().Length > 0)
                return false;
            return true;
        }

        public void iniciaDatos(Opcion_data data)
        {
            _datoPadre = 0;
            _datoTipoOpcion = "0";
            _Mensaje = "";
        }

        public async Task insertFila(SavedRowItem<Opcion_data, Dictionary<String, object>> e)
        {
            e.Item.id = await setUbicacion(e.Item, true, urlinsert);
        }

        public async Task updateFila(SavedRowItem<Opcion_data, Dictionary<String, object>> e)
        {
            await setUbicacion(e.Item, false, urlupdate);
        }

        public async Task inactiveFila(Opcion_data item)
        {
            item.active = !item.active;
            try
            {
                var resultado = await General.solicitudUrl<Opcion_data>(_dataStorage.user.token, "POST", urlinactive, item);
                OpcionRequest _dataRequest = JsonConvert.DeserializeObject<OpcionRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest == null || _dataRequest.entity == null || _dataRequest.entity.id == 0)
                    item.active = !item.active;
            }
            catch (Exception) { item.active = !item.active; }
        }

        private void datosAdicionales(Boolean isNuevo, ref Opcion_data item)
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

        private async Task<Int64> setUbicacion(Opcion_data Item, Boolean Crear, String Url)
        {
            Int64 retorno = 0;
            isok = false;
            Item.type = _datoTipoOpcion;
            Item.parent = _datoPadre;
            Item.nameparent = _lista.Where(w => w.id == _datoPadre).Select(s => s.name).FirstOrDefault();
            Item.name = Item.name.ToUpper();
            Item.code = Item.code;
            Item.url = Item.url;
            Item.icon = Item.icon;
            Opcion_data reg = Item;
            datosAdicionales(Crear, ref reg);
            if (validaDatos(Item))
            {
                var resultadoCode = await General.solicitudUrl<Opcion_data>(_dataStorage.user.token, "POST", urlgetcode, reg);
                OpcionRequest _dataRequestCode = JsonConvert.DeserializeObject<OpcionRequest>(resultadoCode.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestCode != null && (_dataRequestCode.status.code != 200 || !Crear))
                {
                    try
                    {
                        var resultado = await General.solicitudUrl<Opcion_data>(_dataStorage.user.token, "POST", Url, reg);
                        OpcionRequest _dataRequest = JsonConvert.DeserializeObject<OpcionRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
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
                    _Mensaje = "Por favor revisar, el código se encuentra duplicado.&s";
            }
            StateHasChanged();
            if (!isok && Crear)
                _lista.Remove(reg);
            return retorno;
        }


    }
}
