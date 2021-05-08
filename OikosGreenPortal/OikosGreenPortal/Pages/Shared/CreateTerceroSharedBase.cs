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
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Documento_data> _listaSecundaria { get; set; }
        public Tercero_data _regActual { get; set; }
        public List<String> _listaTipo { get; set; }
        public Int64 _datoPadre { get; set; }

        private infoBrowser _dataStorage { get; set; }

        private String urlinsert { get; set; } = Urls.urltercero_insert;

        protected async override Task OnInitializedAsync()
        {
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
                catch (Exception ex) {  }

            }
            catch (Exception ex)
            {
            }
        }

        public async Task createAliado()
        {

        }

        public void OnSelectedValueChanged(Int64 value)
        {
            _datoPadre = value;
        }
    }
}
