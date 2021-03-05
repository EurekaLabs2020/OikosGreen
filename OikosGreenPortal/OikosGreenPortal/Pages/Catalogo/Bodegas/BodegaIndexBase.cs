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

namespace OikosGreenPortal.Pages.Catalogo.Bodegas
{
    public class BodegaIndexBase : ComponentBase 
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] NavigationManager _nav { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Bodega_data> _lista { get; set; }
        public List<Ubicacion_data> _listaSecundaria { get; set; }
        public Bodega_data _regActual { get; set; }
        public List<String> _listaTipo { get; set; }
        public List<String> _listaTipoUbicacion { get; set; }

        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }

        private infoBrowser _dataStorage { get; set; }
        private String datoTipo { get; set; }
        private Boolean isok { get; set; } = false;
        private String urlgetall { get; set; } = Urls.urlbodega_getall;
        private String urlinsert { get; set; } = Urls.urlbodega_insert;
        private String urlupdate { get; set; } = Urls.urlbodega_update;
        private String urlinactive { get; set; } = Urls.urlbodega_inactive;
        private String urlgetcode { get; set; } = Urls.urlbodega_getbycode;


        protected async override Task OnInitializedAsync()
        {
            _lista = new List<Bodega_data>();
            _listaSecundaria = null;
            _Mensaje = "";
            _regActual = new Bodega_data();
            TipoUbicacion tipoUbica = new TipoUbicacion();
            _listaTipoUbicacion = tipoUbica.tiposUbicaciones();
            TipoBodega tipo = new TipoBodega();
            _listaTipo = tipo.tiposBodegas();
            BodegasRequest _dataRequest = new BodegasRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", urlgetall, "");
                _dataRequest = JsonConvert.DeserializeObject<BodegasRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities;
                if(_lista!=null && _lista.Count>0)
                {
                    foreach (var reg in _lista)
                        reg.idubicacion = reg.ubicacionid==null ? 0 : reg.ubicacionid.Value;
                }
                // Obtenemos la Lista Ciudad
                try
                {
                    var resultadoCiudad = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlubicacion_getall, "");
                    UbicacionesRequest _dataRequestCiudad = JsonConvert.DeserializeObject<UbicacionesRequest>(resultadoCiudad.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestCiudad != null && _dataRequestCiudad.entities != null && _dataRequestCiudad.entities.Count > 0)
                        _listaSecundaria = _dataRequestCiudad.entities.Where(w=>w.type== _listaTipoUbicacion[1]).ToList();
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }

        #region Presentación
        public void estilofila(Bodega_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Bodega_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion


        public Boolean validaDatos(Bodega_data _paraValidar)
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

        public void iniciaDatos(Bodega_data data)
        {
            data.idubicacion = 0;
            data.type = "";
            _Mensaje = "";
        }

        public async Task insertFila(SavedRowItem<Bodega_data, Dictionary<String, object>> e)
        {
            e.Item.id = await setUbicacion(e.Item, true, urlinsert);
        }

        public async Task updateFila(SavedRowItem<Bodega_data, Dictionary<String, object>> e)
        {
            e.Item.ubicacionid = e.Item.idubicacion;
            await setUbicacion(e.Item, false, urlupdate);
        }

        public async Task inactiveFila(Bodega_data item)
        {
            item.active = !item.active;
            try
            {
                var resultado = await General.solicitudUrl<Bodega_data>(_dataStorage.user.token, "POST", urlinactive, item);
                BodegaRequest _dataRequest = JsonConvert.DeserializeObject<BodegaRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest == null || _dataRequest.entity == null || _dataRequest.entity.id == 0)
                    item.active = !item.active;
            }
            catch (Exception) { item.active = !item.active; }
        }

        private void datosAdicionales(Boolean isNuevo, ref Bodega_data item)
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

        private async Task<Int64> setUbicacion(Bodega_data Item, Boolean Crear, String Url)
        {
            Int64 retorno = 0;
            isok = false;
            Item.ubicaname = _listaSecundaria.Where(w => w.id == Item.idubicacion).Select(s => s.name).FirstOrDefault();
            Item.name = Item.name.ToUpper();
            Item.code = Item.code.ToUpper();
            Item.phone = Item.phone.ToUpper();
            Item.address = Item.address.ToUpper();
            Bodega_data reg = Item;
            datosAdicionales(Crear, ref reg);
            if (validaDatos(Item))
            {
                var resultadoCode = await General.solicitudUrl<Bodega_data>(_dataStorage.user.token, "POST", urlgetcode, reg);
                BodegaRequest _dataRequestCode = JsonConvert.DeserializeObject<BodegaRequest>(resultadoCode.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestCode != null && (_dataRequestCode.status.code != 200 || !Crear))
                {
                    try
                    {
                        var resultado = await General.solicitudUrl<Bodega_data>(_dataStorage.user.token, "POST", Url, reg);
                        BodegaRequest _dataRequest = JsonConvert.DeserializeObject<BodegaRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
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
