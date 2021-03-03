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
        public Int64 _datoBodegaOrig { get; set; }
        public Int64 _datoBodegadest { get; set; }
        public Int64 _datoProveedor { get; set; }


        public List<Documento_data> _listaTipo { get; set; }
        public List<String> _tipo { get; set; }
        public List<String> _tipoProv { get; set; }
        public List<Bodega_data> _listaOrig { get; set; }
        public List<Bodega_data> _listaDest { get; set; }
        public List<TerceroTipo_data> _listaProv { get; set; }
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
            TipoTerceroTipo tipoUbica = new TipoTerceroTipo();
            _tipoProv = tipoUbica.tiposTerceroTipo();
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
                //Obtiene la bodega
                var resultadoBodega = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlbodega_getall, "");
                BodegasRequest _dataRequestBodega = JsonConvert.DeserializeObject<BodegasRequest>(resultadoBodega.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestBodega != null && _dataRequestBodega.entities != null && _dataRequestBodega.entities.Count > 0)
                    _listaOrig = _listaDest = _dataRequestBodega.entities;
                //Obtiene Proveedor
                var resultadoProveedor = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlterceropunto_getall, "");
                TercerosTipoRequest _dataRequestProveedor = JsonConvert.DeserializeObject<TercerosTipoRequest>(resultadoProveedor.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestProveedor != null && _dataRequestProveedor.entities != null && _dataRequestProveedor.entities.Count > 0)
                    _listaProv = _dataRequestProveedor.entities.Where(w=>w.type== _tipoProv[0]).ToList();
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

        public void OnDateChanged(DateTime? date)
        {
            _datoFecha = date;
        }


    }
}
