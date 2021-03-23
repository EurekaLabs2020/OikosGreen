using Blazored.Modal.Services;
using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using OikosGreenPortal.Data.Personal;
using OikosGreenPortal.Data.Request;
using OikosGreenPortal.PersonalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Pages.Domicilio.Despachar
{
    public class DespachoBase: ComponentBase
    {
        [Inject] IJSRuntime js { get; set; }
        [Inject] IModalService _modal { get; set; }
        [Inject] NavigationManager _nav { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }


        public List<vDespacho_data> _lista { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }


        private infoBrowser _dataStorage { get; set; }
        private String datoTipoUbicacion { get; set; }
        private Boolean isok { get; set; } = false;
        private String urlgetall { get; set; } = Urls.urlvdespachos_getall;
        private String urlinsert { get; set; } = Urls.urlusuario_insert;
        private String urlupdate { get; set; } = Urls.urlusuario_update;
        private String urlinactive { get; set; } = Urls.urlusuario_inactive;
        private String urlgetcode { get; set; } = Urls.urlusuario_getbycode;



        protected override async Task OnInitializedAsync()
        {
            _lista = new List<vDespacho_data>();
            vDespachosRequest _dataRequest = new vDespachosRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", urlgetall, "");
                _dataRequest = JsonConvert.DeserializeObject<vDespachosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.agrupa().OrderByDescending(o => o.deliverdate).ToList();//.entities.OrderByDescending(o => o.date).ToList();

                //if (_lista != null)
                //    foreach (var x in _lista)
                //        x.idtercero = x.terceroid == null ? 0 : x.terceroid.Value;


                //Obtenemos la Tabla de Tipos Documento
                //try
                //{
                //    var resultadoTipoDoc = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urldocumento_getall, "");
                //    DocumentosRequest _dataRequestTipoDoc = JsonConvert.DeserializeObject<DocumentosRequest>(resultadoTipoDoc.Content.ReadAsStringAsync().Result.ToString());
                //    if (_dataRequestTipoDoc != null && _dataRequestTipoDoc.entities != null && _dataRequestTipoDoc.entities.Count > 0)
                //        _listaTipoDocument = _dataRequestTipoDoc.entities;

                //}
                //catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }


                ////Obtenemos la Tabla de Roles
                //try
                //{
                //    var resultadoRoles = await General.solicitudUrl<String>(_dataStorage.user.token, "POST", Urls.urlrol_getall, "");
                //    RolesRequest _dataRequestRol = JsonConvert.DeserializeObject<RolesRequest>(resultadoRoles.Content.ReadAsStringAsync().Result.ToString());
                //    if (_dataRequestRol != null && _dataRequestRol.entities != null && _dataRequestRol.entities.Count > 0)
                //        _listaTRoles = _dataRequestRol.entities;

                //}
                //catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }



        #region Presentación
        public void estilofila(vDespacho_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(vDespacho_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion


        public async Task updateFila(SavedRowItem<vDespacho_data, Dictionary<String, object>> e)
        {

        }

        public async Task accion(Int32 _accion)
        {

        }


    }
}
