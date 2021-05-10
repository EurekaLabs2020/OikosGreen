using Blazored.Modal;
using Blazored.Modal.Services;
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

namespace OikosGreenPortal.Pages.Shared
{
    public class CreateTerceroSharedBase : ComponentBase
    {
        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Documento_data> _listaSecundaria { get; set; }
        public Tercero_data _regActual { get; set; }
        public TerceroTipo_data _regTercTipoActual { get; set; }
        public List<String> _listaTipo { get; set; }
        public List<String> _listaDocumento { get; set; }
        public Int64 _datoPadre { get; set; }

        private infoBrowser _dataStorage { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }

        private String urlgetall { get; set; } = Urls.urltercero_getall;
        private String urlinsert { get; set; } = Urls.urltercero_insert;
        private String urlupdate { get; set; } = Urls.urltercero_update;
        private String urlinactive { get; set; } = Urls.urltercero_inactive;
        private String urlgetcode { get; set; } = Urls.urltercero_getbycode;



        protected async override Task OnInitializedAsync()
        {
            _mensajeIsDanger = "alert-danger";
            _listaSecundaria = null;
            _Mensaje = "";
            _regActual = new Tercero_data();
            _regActual.birthdate = DateTime.Now;
            _regActual.iddocumento = 1;
            _regActual.documentoid = 1;

            _regTercTipoActual = new TerceroTipo_data();            

            TipoTerceroTipo tipo = new TipoTerceroTipo();
            _listaTipo = tipo.tiposTerceroTipo();
            TipoDocumento tipoDoc = new TipoDocumento();
            _listaDocumento = tipoDoc.tiposDocumentos();

            TercerosRequest _dataRequest = new TercerosRequest();
            TercerosTipoRequest _dataReqTipo = new TercerosTipoRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                try
                {
                    var resultadoDocumento = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urldocumento_getall, "");
                    DocumentosRequest _dataRequestDocumento = JsonConvert.DeserializeObject<DocumentosRequest>(resultadoDocumento.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestDocumento != null && _dataRequestDocumento.entities != null && _dataRequestDocumento.entities.Count > 0)
                        _listaSecundaria = _dataRequestDocumento.entities.Where(w => w.type == _listaDocumento[0]).ToList();
                }
                catch (Exception ex) { }

            }
            catch (Exception ex)
            {
            }
        }

        public async Task createAliado()
        {
            Int64 retorno = 0;
            _regActual.phone = _regActual.cellphone;
            _regActual.name = _regActual.name.ToUpper().Trim();
            _regActual.lastname = _regActual.lastname.ToUpper().Trim();
            _regActual.numdocument = _regActual.numdocument.ToUpper().Trim();
            _regActual.address = _regActual.address.ToUpper().Trim();
            _regActual.email = _regActual.email.ToUpper().Trim();
            _regActual.documentoid = _regActual.iddocumento;

            _regTercTipoActual.usermodify = _regActual.usermodify = _regActual.usercreate = _regTercTipoActual.usercreate = _dataStorage.user.user;
            _regTercTipoActual.datemodify = _regActual.datemodify = _regActual.datecreate = _regTercTipoActual.datecreate = DateTime.Now;
            _regActual.active = _regTercTipoActual.active = true;


            if (validaDatos(_regActual))
            {
                try
                {
                    var resultadoCode = await General.solicitudUrl<Tercero_data>(_dataStorage.user.token, "POST", urlgetcode, _regActual);
                    TerceroRequest _dataRequestCode = JsonConvert.DeserializeObject<TerceroRequest>(resultadoCode.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestCode == null || (_dataRequestCode.status.code == 404))
                    {
                        try
                        {
                            var resultado = await General.solicitudUrl<Tercero_data>(_dataStorage.user.token, "POST", urlinsert, _regActual);
                            TerceroRequest _dataRequest = JsonConvert.DeserializeObject<TerceroRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                            if (_dataRequest != null && _dataRequest.status != null && _dataRequest.status.code == 200)
                            {
                                if (_dataRequest.entity != null && _dataRequest.entity.id > 0)
                                {
                                    retorno = _dataRequest.entity.id;
                                    _regActual.id = retorno;
                                }
                                if (retorno > 0)
                                {
                                    _regTercTipoActual.terceroid = _regTercTipoActual.idtercero = retorno;
                                    // Adicionamos el Tercero Tipo
                                    var resultadoCodeTipo = await General.solicitudUrl<TerceroTipo_data>(_dataStorage.user.token, "POST", Urls.urltercerotipo_getbycode, _regTercTipoActual);
                                    TerceroTipoRequest _dataRequestCodeTipo = JsonConvert.DeserializeObject<TerceroTipoRequest>(resultadoCodeTipo.Content.ReadAsStringAsync().Result.ToString());
                                    if (_dataRequestCodeTipo == null || (_dataRequestCodeTipo.status.code == 404))
                                    {
                                        try
                                        {
                                            var resultadoTipo = await General.solicitudUrl<TerceroTipo_data>(_dataStorage.user.token, "POST", Urls.urltercerotipo_insert, _regTercTipoActual);
                                            TerceroTipoRequest _dataRequestTipo = JsonConvert.DeserializeObject<TerceroTipoRequest>(resultadoTipo.Content.ReadAsStringAsync().Result.ToString());
                                            if (_dataRequestTipo != null && _dataRequestTipo.status != null && _dataRequestTipo.status.code == 200)
                                            {
                                                if (_dataRequestTipo.entity != null && _dataRequestTipo.entity.id > 0)
                                                {
                                                    retorno = _dataRequest.entity.id;
                                                    _regTercTipoActual.id = retorno;
                                                }
                                            }
                                            else
                                                _Mensaje += _dataRequest.status.message + "&s";
                                        }
                                        catch (Exception ex) { _Mensaje += ex.Message + "&s"; }
                                    }
                                    else
                                        _Mensaje += "Por favor revisar, el código se encuentra duplicado.&s";
                                }
                            }
                            else
                                _Mensaje += _dataRequest.status.message + "&s";
                        }
                        catch (Exception ex) { _Mensaje += ex.Message + "&s"; }
                    }
                    else
                        _Mensaje += "Por favor revisar, el código se encuentra duplicado.&s";
                }
                catch (Exception ex) { _Mensaje += ex.Message + "&s"; }
            }
            if (retorno > 0)
            {
                await BlazoredModal.CloseAsync(ModalResult.Ok<TerceroTipo_data>(_regTercTipoActual));
            }
            StateHasChanged();
        }

        public void OnSelectedValueChanged(Int64 value)
        {
            _regActual.iddocumento = value;
        }

        public void OnSelectedValueChangedTercTipo(String value)
        {
            _regTercTipoActual.type = value;
        }

        public Boolean validaDatos(Tercero_data _paraValidar)
        {
            _Mensaje = "";
            _mensajeIsDanger = "alert-danger";
            if (_paraValidar.name == null)
                _Mensaje += "Por favor diligenciar el NOMBRE, es un campo obligatorio.&s";
            if (_paraValidar.lastname == null)
                _Mensaje += "Por favor diligenciar el CODIGO, es un campo obligatorio.&s";
            if (_paraValidar.numdocument == null)
                _Mensaje += "Por favor diligenciar el NUMERO DOCUMENTO, es un campo obligatorio.&s";
            if (_paraValidar.documentoid == null || _paraValidar.documentoid == 0)
                _Mensaje += "Por favor diligenciar el TIPO DE DOCUMENTO, es un campo obligatorio.&s";
            if (_paraValidar.address == null)
                _Mensaje += "Por favor diligenciar la Dirección, es un campo obligatorio.&s";


            if (_Mensaje.Trim().Length > 0)
                return false;
            return true;
        }

    }
}
