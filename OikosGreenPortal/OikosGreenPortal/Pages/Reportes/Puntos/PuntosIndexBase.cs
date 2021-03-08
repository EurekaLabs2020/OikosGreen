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

        public List<TerceroPunto_data> _lista { get; set; }
        public List<Tercero_data> _listaSecundaria { get; set; }
        public TerceroPunto_data _regActual { get; set; }
        public List<String> _listaTipo { get; set; }
        public List<Tercero_data> _lsttercero { get; set; }
        public Int64 _datoPadre { get; set; }
        public String _datoTipo { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }
        public String _terceronombre { get; set; }
        public DateTime _fechaini { get; set; }
        public DateTime _fechafin { get; set; }
        public Int64 _idtercero { get; set; }

        private infoBrowser _dataStorage { get; set; }
        private Boolean isok { get; set; } = false;
        private String urlgetall { get; set; } = Urls.urlterceropunto_getall;
        private String urlinsert { get; set; } = Urls.urlterceropunto_insert;
        private String urlupdate { get; set; } = Urls.urlterceropunto_update;
        private String urlinactive { get; set; } = Urls.urlterceropunto_inactive;
        private String urlgetcode { get; set; } = Urls.urlterceropunto_getbycode;


        protected async override Task OnInitializedAsync()
        {
            _lista = new List<TerceroPunto_data>();
            _listaSecundaria = null;
            _datoPadre = 0;
            _Mensaje = _datoTipo = "";
            _regActual = new TerceroPunto_data();
            _lsttercero = new List<Tercero_data>();
            _idtercero = 0;
            Periodos tipoUbica = new Periodos();
            _listaTipo = tipoUbica.listaPeriodos();
            _fechaini = _fechafin = DateTime.Now;


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
                        _listaSecundaria = _dataRequestTercero.entities.OrderBy(o => o.nombrefull).ToList();

                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }

        #region Presentación
        public void estilofila(TerceroPunto_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(TerceroPunto_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion


        public Boolean validaDatos(TerceroPunto_data _paraValidar)
        {
            _Mensaje = "";
            _mensajeIsDanger = "alert-danger";
            if (_paraValidar.period == null)
                _Mensaje += "Por favor diligenciar el TIPO, es un campo obligatorio.&s";
            if (_paraValidar.idtercero == null || _paraValidar.idtercero == 0)
                _Mensaje += "Por favor diligenciar el TERCERO, es un campo obligatorio.&s";


            if (_Mensaje.Trim().Length > 0)
                return false;
            return true;
        }

        public void iniciaDatos(TerceroPunto_data data)
        {
            _datoPadre = 0;
            data.previousbalance = data.input = data.output = data.currentbalance = 0;
            _Mensaje = "";
        }


        public async Task insertaFila(SavedRowItem<TerceroPunto_data, Dictionary<String, object>> e)
        {

        }

        public async Task insertandoFila(EventArgs arg)
        {
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.TerceroPunto_data, System.Collections.Generic.Dictionary<string, object>>)arg).Item;
            var valor = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.TerceroPunto_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;            
            item.input = Convert.ToDecimal(valor["input"].ToString());
            item.output = Convert.ToDecimal(valor["output"].ToString());
            item.previousbalance= Convert.ToDecimal(valor["previousbalance"].ToString());
            item.currentbalance = item.previousbalance + item.input - item.output;
            TerceroPunto_data registro = item;
            registro = await setUbicacion(registro, true, urlinsert);
            if (registro.id > 0)
            {
                _lista.Add(registro);
                ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.TerceroPunto_data, System.Collections.Generic.Dictionary<string, object>>)arg).Cancel = false;                
                StateHasChanged();
            }
            else
                ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.TerceroPunto_data, System.Collections.Generic.Dictionary<string, object>>)arg).Cancel = true;
        }

        public async Task inactiveFila(TerceroPunto_data item)
        {
            item.active = !item.active;
            try
            {
                var resultado = await General.solicitudUrl<TerceroPunto_data>(_dataStorage.user.token, "POST", urlinactive, item);
                TerceroPuntoRequest _dataRequest = JsonConvert.DeserializeObject<TerceroPuntoRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest == null || _dataRequest.entity == null || _dataRequest.entity.id == 0)
                    item.active = !item.active;
            }
            catch (Exception) { item.active = !item.active; }
        }

        public async Task updateFila(SavedRowItem<TerceroPunto_data, Dictionary<String, object>> e)
        {
            _datoPadre = e.Item.terceroid;
            await setUbicacion(e.Item, false, urlupdate);
        }

        public async Task updatingFila(EventArgs arg)
        {

        }

        private void datosAdicionales(Boolean isNuevo, ref TerceroPunto_data item)
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


        private async Task<TerceroPunto_data> setUbicacion(TerceroPunto_data Item, Boolean Crear, String Url)
        {
            TerceroPunto_data retorno = Item;
            isok = false;
            retorno.period = _datoTipo;
            retorno.idtercero = Item.terceroid = _datoPadre;
            retorno.name = _listaSecundaria.Where(w => w.id == _datoPadre).Select(s => s.name).FirstOrDefault();
            retorno.lastname = _listaSecundaria.Where(w => w.id == _datoPadre).Select(s => s.lastname).FirstOrDefault();
            TerceroPunto_data reg = retorno;
            datosAdicionales(Crear, ref reg);
            if (validaDatos(Item))
            {
                //var resultadoCode = await General.solicitudUrl<TerceroPunto_data>(_dataStorage.user.token, "POST", urlgetcode, reg);
                //TerceroPuntoRequest _dataRequestCode = JsonConvert.DeserializeObject<TerceroPuntoRequest>(resultadoCode.Content.ReadAsStringAsync().Result.ToString());
                //if (_dataRequestCode != null && (_dataRequestCode.status.code != 200 || !Crear))
                //{
                    try
                    {
                        var resultado = await General.solicitudUrl<TerceroPunto_data>(_dataStorage.user.token, "POST", Url, reg);
                        TerceroPuntoRequest _dataRequest = JsonConvert.DeserializeObject<TerceroPuntoRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                        if (_dataRequest != null && _dataRequest.status != null && _dataRequest.status.code == 200)
                        {
                            if (_dataRequest.entity != null && _dataRequest.entity.id > 0)
                            {
                                isok = true;
                                retorno.id = _dataRequest.entity.id;
                            }
                        }
                        else
                            _Mensaje = _dataRequest.status.message;
                    }
                    catch (Exception ex) { _Mensaje = ex.Message; }
                //}
                //else
                //    _Mensaje = "Por favor revisar, el código se encuentra duplicado.&s";
            }

            StateHasChanged();
            if (!isok && Crear)
                _lista.Remove(reg);
            return retorno;
        }

        public async Task procesar()
        {
            TerceroPuntosRequest _dataRequest = new TerceroPuntosRequest();
            if (_datoPadre > 0 && _fechaini <= _fechafin)
            {
                TerceroPunto_data envio = new TerceroPunto_data();
                envio.terceroid = _datoPadre;
                envio.idtercero = _datoPadre;
                envio.period = _fechaini.Year.ToString()+_fechaini.Month.ToString("0#");

                try
                {
                    var resultado = await General.solicitudUrl<TerceroPunto_data>(_dataStorage.user.token, "GET", Urls.urlterceropunto_getbycode, envio);
                    _dataRequest = JsonConvert.DeserializeObject<TerceroPuntosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                        _lista = _dataRequest.entities.OrderBy(o => o.nombrefull).OrderByDescending(o => o.period).ToList();
                }
                catch
                {
                    _lista = new List<TerceroPunto_data>();
                }
            }

        }

    }
}
