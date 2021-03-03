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

namespace OikosGreenPortal.Pages.Transacciones
{
    public class NuevaTransaccionBase : ComponentBase
    {
        [Inject] public IModalService _modal { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }
        [Inject] public NavigationManager _navigation { get; set; }

        public Boolean _mostrarDetalle { get; set; }
        public String _resumenDetalle { get; set; }
        public Int64 _datoTipo { get; set; }
        public Int64 _datoClase { get; set; }
        public DateTime? _datoFecha { get; set; }


        public List<Documento_data> _listaTipo { get; set; }
        public List<String> _tipo { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }

        private infoBrowser _dataStorage { get; set; }



        protected async override Task OnInitializedAsync()
        {
            _mostrarDetalle = false;
            _resumenDetalle = "...";
            _datoTipo = _datoClase = 0;
            _datoFecha = DateTime.Now;

            TipoDocumento tipo = new TipoDocumento();
            _tipo = tipo.tiposDocumentos();

            DocumentosRequest _dataRequest = new DocumentosRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urldocumento_getall, "");
                _dataRequest = JsonConvert.DeserializeObject<DocumentosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _listaTipo = _dataRequest.entities.Where(w=>w.type==_tipo[1]).ToList();
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal);
            }
        }


        public async Task Detalle()
        {
            _mostrarDetalle = !_mostrarDetalle;
            if (_datoTipo != 0)
                _resumenDetalle += _listaTipo.Where(w => w.id == _datoTipo).Select(s=>s.name).FirstOrDefault();
        }



    }
}
