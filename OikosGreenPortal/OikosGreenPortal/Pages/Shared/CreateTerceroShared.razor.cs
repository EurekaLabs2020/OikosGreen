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
    public partial class CreateTerceroShared : ComponentBase
    {
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Documento_data> _listaSecundaria { get; set; }
        public Tercero_data _regActual { get; set; }
        public List<String> _listaTipo { get; set; }
        public Int64 _datoPadre { get; set; }

        private infoBrowser _dataStorage { get; set; }
        private String _Mensaje { get; set; }
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
            _datoPadre = 0;
            _regActual = new Tercero_data();
            TipoDocumento tipo = new TipoDocumento();
            _listaTipo = tipo.tiposDocumentos();
            TercerosRequest _dataRequest = new TercerosRequest();
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
                        _listaSecundaria = _dataRequestDocumento.entities.Where(w => w.type == _listaTipo[0]).ToList();
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
            if (validaDatos(_regActual))
            {
                var resultadoCode = await General.solicitudUrl<Tercero_data>(_dataStorage.user.token, "POST", urlgetcode, _regActual);
                TerceroRequest _dataRequestCode = JsonConvert.DeserializeObject<TerceroRequest>(resultadoCode.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestCode == null || (_dataRequestCode.status.code != 200 ))
                {
                    try
                    {
                        var resultado = await General.solicitudUrl<Tercero_data>(_dataStorage.user.token, "POST", urlinsert, _regActual);
                        TerceroRequest _dataRequest = JsonConvert.DeserializeObject<TerceroRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                        if (_dataRequest != null && _dataRequest.status != null && _dataRequest.status.code == 200)
                        {
                            if (_dataRequest.entity != null && _dataRequest.entity.id > 0)
                                retorno = _dataRequest.entity.id;
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
        }

        public void OnSelectedValueChanged(Int64 value)
        {
            _datoPadre = value;
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
