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


namespace OikosGreenPortal.Pages.Catalogo.Conversion
{
    public class ConversionPageBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] NavigationManager _nav { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Conversion_data> _lista { get; set; }
        public List<Presentacion_data> _listaSecundaria { get; set; }
        public List<Presentacion_data> _listaTercera { get; set; }
        public Conversion_data _regActual { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }
        private infoBrowser _dataStorage { get; set; }
        private Boolean isok { get; set; } = false;
        private String urlgetall { get; set; } = Urls.urlconversion_getall;
        private String urlinsert { get; set; } = Urls.urlconversion_insert;
        private String urlupdate { get; set; } = Urls.urlconversion_update;
        private String urlinactive { get; set; } = Urls.urlconversion_inactive;

        protected async override Task OnInitializedAsync()
        {
            _lista = new List<Conversion_data>();
            _listaSecundaria = null;
            _Mensaje = "";
            _regActual = new Conversion_data();
            ConversionesRequest _dataRequest = new ConversionesRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", urlgetall, "");
                _dataRequest = JsonConvert.DeserializeObject<ConversionesRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities;
                // Obtenemos las Presentaciones
                try
                {
                    var resultadoPresentacion = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlpresentacion_getall, "");
                    PresentacionesRequest _dataRequestPresentaciones = JsonConvert.DeserializeObject<PresentacionesRequest>(resultadoPresentacion.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestPresentaciones != null && _dataRequestPresentaciones.entities != null && _dataRequestPresentaciones.entities.Count > 0)
                        _listaSecundaria = _dataRequestPresentaciones.entities.ToList();
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }
                try
                {
                    var resultadoPresentacion = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlpresentacion_getall, "");
                    PresentacionesRequest _dataRequestPresentaciones = JsonConvert.DeserializeObject<PresentacionesRequest>(resultadoPresentacion.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestPresentaciones != null && _dataRequestPresentaciones.entities != null && _dataRequestPresentaciones.entities.Count > 0)
                        _listaTercera = _dataRequestPresentaciones.entities.ToList();
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }


        #region Presentación
        public void estilofila(Conversion_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Conversion_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion

        public void iniciaDatos(Conversion_data data)
        {
            data.unitdestinationid = data.unitoriginid = 0;
            _Mensaje = "";
        }

        public async Task insertFila(SavedRowItem<Conversion_data, Dictionary<String, object>> e)
        {
            e.Item.id = await setData(e.Item, true, urlinsert);
        }

        public async Task updateFila(SavedRowItem<Conversion_data, Dictionary<String, object>> e)
        {
            await setData(e.Item, false, urlupdate);
        }

        public async Task inactiveFila(Conversion_data item)
        {
            item.active = !item.active;
            try
            {
                var resultado = await General.solicitudUrl<Conversion_data>(_dataStorage.user.token, "POST", urlinactive, item);
                ConversionRequest _dataRequest = JsonConvert.DeserializeObject<ConversionRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest == null || _dataRequest.entity == null || _dataRequest.entity.id == 0)
                    item.active = !item.active;
            }
            catch (Exception) { item.active = !item.active; }
        }

        private void datosAdicionales(Boolean isNuevo, ref Conversion_data item)
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

        private async Task<Int64> setData(Conversion_data Item, Boolean Crear, String Url)
        {
            Int64 retorno = 0;
            isok = false;
            Item.value = Item.value;
            Item.presorigin = _listaSecundaria.Where(w => w.id == Item.unitoriginid).Select(s => s.name).FirstOrDefault();
            Item.presdestination = _listaTercera.Where(w => w.id == Item.unitdestinationid).Select(s => s.name).FirstOrDefault();
                        
            Conversion_data reg = Item;
            datosAdicionales(Crear, ref reg);
            if (validaDatos(Item))
            {
                try
                {
                    var resultadoCode = await General.solicitudUrl<Conversion_data>(_dataStorage.user.token, "POST", Urls.urlconversion_getbycode, reg);
                    ConversionRequest _dataRequestCode = JsonConvert.DeserializeObject<ConversionRequest>(resultadoCode.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestCode != null && (_dataRequestCode.status.code != 200 || !Crear))
                    {

                        var resultado = await General.solicitudUrl<Conversion_data>(_dataStorage.user.token, "POST", Url, reg);
                        ConversionRequest _dataRequest = JsonConvert.DeserializeObject<ConversionRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
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
                    else
                        _Mensaje = "Por favor revisar, el registro se encuentra duplicado.&s";

                }
                catch (Exception ex) { _Mensaje = ex.Message; }
            }
            StateHasChanged();
            if (!isok && Crear)
                _lista.Remove(reg);
            return retorno;
        }


        public Boolean validaDatos(Conversion_data _paraValidar)
        {
            _Mensaje = "";
            _mensajeIsDanger = "alert-danger";
            if (_paraValidar.unitoriginid == null || _paraValidar.unitoriginid==0)
                _Mensaje += "Por favor diligenciar el PRESENTACION ORIGEN, es un campo obligatorio.&s";
            if (_paraValidar.unitdestinationid == null || _paraValidar.unitdestinationid == 0)
                _Mensaje += "Por favor diligenciar el PRESENTACION DESTINO, es un campo obligatorio.&s";
            if (_paraValidar.value == null || _paraValidar.value == 0)
                _Mensaje += "Por favor diligenciar el VALOR, es un campo obligatorio.&s";


            if (_Mensaje.Trim().Length > 0)
                return false;
            return true;
        }


    }
}
