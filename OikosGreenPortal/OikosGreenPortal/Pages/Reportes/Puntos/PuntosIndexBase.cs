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

namespace OikosGreenPortal.Pages.Reportes.Puntos
{
    public class PuntosIndexBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] NavigationManager _nav { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Transaccion_data> _lista { get; set; }
        public Transaccion_data _regActual { get; set; }
        public List<Tercero_data> _lsttercero { get; set; }
        public TerceroPunto_data _datoPuntoTerc { get; set; }
        public Int64 _datoPadre { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }
        public String _terceronombre { get; set; }
        public DateTime _fechaini { get; set; }
        public DateTime _fechafin { get; set; }
        public Int64 _idtercero { get; set; }
        public Boolean mostrar { get; set; }


        private infoBrowser _dataStorage { get; set; }
        private Boolean isok { get; set; } = false;


        protected async override Task OnInitializedAsync()
        {
            mostrar = false;
            _lista = new List<Transaccion_data>();
            _datoPadre = 0;
            _Mensaje = "";
            _regActual = new Transaccion_data();
            _lsttercero = new List<Tercero_data>();
            _idtercero = 0;
            _fechaini = _fechafin = DateTime.Now;
            _datoPuntoTerc = new TerceroPunto_data();

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
                    var resultadoTercero = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urltercero_getall, "");
                    TercerosRequest _dataRequestTercero = JsonConvert.DeserializeObject<TercerosRequest>(resultadoTercero.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestTercero != null && _dataRequestTercero.entities != null && _dataRequestTercero.entities.Count > 0)
                        _lsttercero = _dataRequestTercero.entities.OrderBy(o => o.nombrefull).ToList();

                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }

        #region Presentación
        public void estilofila(Transaccion_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Transaccion_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion




        public async Task procesar()
        {
            mostrar = true;
            TransaccionRequest _dataRequest = new TransaccionRequest();
            //TerceroPuntoRequest _dataRequest = new TerceroPuntoRequest();
            _lista = new List<Transaccion_data>();
            if (_datoPadre > 0 && _fechaini <= _fechafin)
            {
                Transaccion_data envio = new Transaccion_data();
                envio.terceroid = _datoPadre;
                envio.dateinitial = _fechaini;
                envio.datefinal = _fechafin;

                try
                {
                    var resultado = await General.solicitudUrl<Transaccion_data>(_dataStorage.user.token, "POST", Urls.urltransaccion_getbyfecha, envio);
                    _dataRequest = JsonConvert.DeserializeObject<TransaccionRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());

                    if (_dataRequest != null && _dataRequest.entities != null) 
                    {
                        _lista = _dataRequest.entities.OrderByDescending(o => o.date).OrderBy(o2 => o2.numberdocument).OrderBy(o3 => o3.detline).OrderBy(o4 => o4.code).ToList();
                        foreach (var reg in _lista)
                            reg.points = reg.points * (reg.affect == "S" ? -1 : (reg.affect == "E" ? 1 : 0));
                    }
                    //Obtenemos los datos actuales
                    TerceroPunto_data envioTerc = new TerceroPunto_data();
                    envioTerc.terceroid = envio.terceroid;
                    var resultadoTerc = await General.solicitudUrl<TerceroPunto_data>(_dataStorage.user.token, "POST", Urls.urlterceropunto_getbytercid, envioTerc);
                    TerceroPuntoRequest _dataRequestTerc = JsonConvert.DeserializeObject<TerceroPuntoRequest>(resultadoTerc.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestTerc != null && _dataRequestTerc.entity != null)
                        _datoPuntoTerc = _dataRequestTerc.entity;

                }
                catch
                {
                    _lista = new List<Transaccion_data>();
                }
            }
        }


    }
}
