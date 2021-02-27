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

namespace OikosGreenPortal.Pages.Catalogo.Documentos
{
    public class DocumentosBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Documento_data> _lista { get; set; }
        public List<Lista_data> _listaSecundaria { get; set; }
        public Documento_data _regActual { get; set; }
        public List<String> _listaTipo { get; set; }
        
        public Int64 _datoPadre { get; set; }
        public String _datoTipo
        {
            get { return datoTipo; }
            set
            {
                datoTipo = value;
                _datoPadre = 0;
            }
        }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }

        private infoBrowser _dataStorage { get; set; }
        private String datoTipo { get; set; }
        private Boolean isok { get; set; } = false;
        private String urlgetall { get; set; } = Urls.urldocumento_getall;
        private String urlinsert { get; set; } = Urls.urldocumento_insert;
        private String urlupdate { get; set; } = Urls.urldocumento_update;
        private String urlinactive { get; set; } = Urls.urldocumento_inactive;
        private String urlgetcode { get; set; } = Urls.urldocumento_getbycode;


        protected async override Task OnInitializedAsync()
        {
            _lista = new List<Documento_data>();
            _listaSecundaria = null;
            _datoPadre = 0;
            _Mensaje = "";
            _regActual = new Documento_data();

            TipoDocumento tipo = new TipoDocumento();
            _listaTipo = tipo.tiposDocumentos();

            DocumentosRequest _dataRequest = new DocumentosRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", urlgetall, "");
                _dataRequest = JsonConvert.DeserializeObject<DocumentosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities;
                // Obtenemos la Lista Ciudad
                try
                {
                    var resultadoLista = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urllista_getall, "");
                    ListasRequest _dataRequestLista = JsonConvert.DeserializeObject<ListasRequest>(resultadoLista.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestLista != null && _dataRequestLista.entities != null && _dataRequestLista.entities.Count > 0)
                        _listaSecundaria = _dataRequestLista.entities.ToList();
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal); }
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal);
            }
        }

        #region Presentación
        public void estilofila(Documento_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Documento_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion


        public Boolean validaDatos(Documento_data _paraValidar)
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

        public void iniciaDatos(Documento_data data)
        {
            _datoPadre = 0;
            _datoTipo = "0";
            _Mensaje = "";
        }

        public async Task insertFila(SavedRowItem<Documento_data, Dictionary<String, object>> e)
        {
            e.Item.id = await setUbicacion(e.Item, true, urlinsert);
        }

        public async Task updateFila(SavedRowItem<Documento_data, Dictionary<String, object>> e)
        {
            await setUbicacion(e.Item, false, urlupdate);
        }

        public async Task inactiveFila(Documento_data item)
        {
            item.active = !item.active;
            try
            {
                var resultado = await General.solicitudUrl<Documento_data>(_dataStorage.user.token, "POST", urlinactive, item);
                DocumentoRequest _dataRequest = JsonConvert.DeserializeObject<DocumentoRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest == null || _dataRequest.entity == null || _dataRequest.entity.id == 0)
                    item.active = !item.active;
            }
            catch (Exception) { item.active = !item.active; }
        }

        private void datosAdicionales(Boolean isNuevo, ref Documento_data item)
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

        private async Task<Int64> setUbicacion(Documento_data Item, Boolean Crear, String Url)
        {
            Int64 retorno = 0;
            isok = false;
            Item.type = _datoTipo;
            Item.listid = _datoPadre;
            Item.namelist = _listaSecundaria.Where(w => w.id == _datoPadre).Select(s => s.name).FirstOrDefault();
            Item.name = Item.name.ToUpper();
            Documento_data reg = Item;
            datosAdicionales(Crear, ref reg);
            if (validaDatos(Item))
            {
                var resultadoCode = await General.solicitudUrl<Documento_data>(_dataStorage.user.token, "POST", urlgetcode, reg);
                DocumentoRequest _dataRequestCode = JsonConvert.DeserializeObject<DocumentoRequest>(resultadoCode.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestCode != null && (_dataRequestCode.status.code != 200 || !Crear))
                {
                    try
                    {
                        var resultado = await General.solicitudUrl<Documento_data>(_dataStorage.user.token, "POST", Url, reg);
                        DocumentoRequest _dataRequest = JsonConvert.DeserializeObject<DocumentoRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
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
