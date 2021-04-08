using Blazored.Modal;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OikosGreenPortal.Data.Personal;
using OikosGreenPortal.Data.Request;
using OikosGreenPortal.PersonalClass;
using Newtonsoft.Json;
using Microsoft.JSInterop;
using Blazored.Modal.Services;

namespace OikosGreenPortal.Pages.Domicilio.Despachar
{
    public class ModalDespachoBase : ComponentBase
    {

        [CascadingParameter] public BlazoredModalInstance BlazoredModal { get; set; }
        [Parameter] public Int32 _tipo { get; set; }
        [Parameter] public Int64 _id { get; set; }
        [Parameter] public String _titulo { get; set; }
        [Parameter] public infoBrowser userLogueado { get; set; }
        [Parameter] public List<Usuario_data> _lstUsuarios { get; set; }
        [Parameter] public List<vDespacho_data> _regdespacho { get; set; }


        [Inject] IJSRuntime js { get; set; }
        [Inject] IModalService _modal { get; set; }
        [Inject] NavigationManager _nav { get; set; }



        public String _observacion { get; set; }
        public Int64 _idconcepto { get; set; }
        public String _idusuario { get; set; }
        public Int32 _cajas { get; set; }
        public Int32 _bolsas { get; set; }
        public List<Concepto_data> _lstConcepto { get; set; }
        public String _Mensaje { get; set; }

        protected override async Task OnInitializedAsync()
        {
            String statusApi = _observacion = _Mensaje = "";
            _idconcepto = 0;
            ConceptosRequest respAuth = new ConceptosRequest();            
            try
            {
                var resultado = await General.solicitudUrl<String>(userLogueado.user.token, "POST", Urls.urlconcepto_getall, "");
                ConceptosRequest _dataRequest = JsonConvert.DeserializeObject<ConceptosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lstConcepto = _dataRequest.entities;
            }
            catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }
        }



        public async Task Save()
        {
            if (Valida())
            {
                DateTime fechaActual = DateTime.Now;
                foreach (var regdet in _regdespacho)
                {
                    if (_tipo == 1 && _idusuario.Trim().Length > 0)
                    {
                        Separado_data envio = new Separado_data();
                        envio.asignaid = userLogueado.user.user;
                        envio.conceptid = _idconcepto;
                        envio.datefinal = envio.dateinitial = DateTime.Now;
                        envio.detallemovimientoid = regdet.iddet;
                        envio.quantity = regdet.cantdetalle.Value;
                        envio.separaid = _idusuario;
                        ConceptosRequest respAuth = new ConceptosRequest();
                        try
                        {
                            var resultado = await General.solicitudUrl<String>(userLogueado.user.token, "POST", Urls.urlconcepto_getall, "");
                            ConceptosRequest _dataRequest = JsonConvert.DeserializeObject<ConceptosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                            if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                                _lstConcepto = _dataRequest.entities;
                        }
                        catch (Exception ex) { _Mensaje = ex.Message; }
                    }
                    if (_tipo == 2 && _idusuario.Trim().Length > 0)
                    {
                        Chequeado_data envio = new Chequeado_data();
                        envio.asignaid = userLogueado.user.user;
                        envio.conceptid = _idconcepto;
                        envio.datefinal = envio.dateinitial = DateTime.Now;
                        envio.detallemovimientoid = regdet.iddet;
                        envio.quantity = regdet.cantdetalle.Value;
                        envio.chequeaid = _idusuario;
                        ConceptosRequest respAuth = new ConceptosRequest();
                        try
                        {
                            var resultado = await General.solicitudUrl<String>(userLogueado.user.token, "POST", Urls.urlconcepto_getall, "");
                            ConceptosRequest _dataRequest = JsonConvert.DeserializeObject<ConceptosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                            if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                                _lstConcepto = _dataRequest.entities;
                        }
                        catch (Exception ex) { _Mensaje = ex.Message; }
                    }
                    if (_tipo == 3 && _idusuario.Trim().Length > 0)
                    {
                        Despacho_data envio = new Despacho_data();
                        envio.despachaid = userLogueado.user.user;
                        envio.conceptoiddispatch = _idconcepto;
                        envio.dispatchdate = DateTime.Now;
                        envio.encabezadomovimientoid = regdet.idenca;
                        envio.numberbags = _bolsas;
                        envio.numberboxes = _cajas;
                        envio.numberguide = 0;
                        envio.weight = 0;
                        ConceptosRequest respAuth = new ConceptosRequest();
                        try
                        {
                            var resultado = await General.solicitudUrl<String>(userLogueado.user.token, "POST", Urls.urlconcepto_getall, "");
                            ConceptosRequest _dataRequest = JsonConvert.DeserializeObject<ConceptosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                            if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                                _lstConcepto = _dataRequest.entities;
                        }
                        catch (Exception ex) { _Mensaje = ex.Message; }
                    }

                }
            }


        }

        private Boolean Valida()
        {
            _Mensaje = "";



            if (_Mensaje.Trim().Length > 0)
                return false;
            else
                return true;
        }


        public async Task Salir()
        {
            await BlazoredModal.CloseAsync();
        }



    }
}
