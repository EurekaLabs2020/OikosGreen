using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazored.Modal.Services;
using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Newtonsoft.Json;
using OikosGreenPortal.Data.Personal;
using OikosGreenPortal.Data.Request;
using OikosGreenPortal.PersonalClass;

namespace OikosGreenPortal.Pages.GestionAccesos.Grupos
{
    public class GrupoIndexBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] NavigationManager _nav { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Rol_data> _lista { get; set; }
        public List<String> _listaTipo { get; set; }
        public Rol_data _regActual { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }
        public String _datoTipo { get; set; }
        private infoBrowser _dataStorage { get; set; }

        protected async override Task OnInitializedAsync()
        {
            _mensajeIsDanger = "alert-danger";
            _lista = new List<Rol_data>();
            _regActual = new Rol_data();
            _Mensaje = "";
            RolesRequest _dataRequest = new RolesRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "POST", Urls.urlrol_getall, "");
                _dataRequest = JsonConvert.DeserializeObject<RolesRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities;

            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }


        #region Presentación
        public void estilofila(Rol_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Rol_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion

        public async Task insertaFila(EventArgs arg)
        {
            var valores = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Rol_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Rol_data, System.Collections.Generic.Dictionary<string, object>>)arg).Item;
            var nombre = valores.Where(w => w.Key == "name").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();            
            item.name = nombre;
            
        
            try
            {
                _Mensaje = "";
                var resultadoValida = await General.solicitudUrl<Rol_data>(_dataStorage.user.token, "POST", Urls.urlrol_getbycode, item);
                RolRequest _dataRequestValida = JsonConvert.DeserializeObject<RolRequest>(resultadoValida.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestValida != null && _dataRequestValida.status.code != 200)
                {
                    var resultado = await General.solicitudUrl<Rol_data>(_dataStorage.user.token, "POST", Urls.urlrol_insert, item);
                    RolRequest _dataRequest = JsonConvert.DeserializeObject<RolRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity.id != "")
                        item.id = _dataRequest.entity.id;
                }
                else if (_dataRequestValida == null)
                {
                    _Mensaje = "Error realizando validación";
                    ((System.ComponentModel.CancelEventArgs)arg).Cancel = true;
                }
                else if (_dataRequestValida.entity != null)
                {
                    _Mensaje = "El código se encuentra duplicado";
                    ((System.ComponentModel.CancelEventArgs)arg).Cancel = true;
                }
            }
            catch (Exception) { item = new Rol_data(); }
        }

        public async Task updateFila(EventArgs arg)
        {
            var valores = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Rol_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Rol_data, System.Collections.Generic.Dictionary<string, object>>)arg).Item;
            var nombre = valores.Where(w => w.Key == "name").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();            
            item.name = nombre;
            
            try
            {
                var resultado = await General.solicitudUrl<Rol_data>(_dataStorage.user.token, "POST", Urls.urlrol_update, item);
                RolRequest _dataRequest = JsonConvert.DeserializeObject<RolRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity.id != "")
                    item.id = _dataRequest.entity.id;
            }
            catch (Exception) { item = new Rol_data(); }
        }

       public void validaName(ValidatorEventArgs arg)
        {
            ValidationRule.IsUppercase(arg.Value.ToString());
            if (arg.Status == ValidationStatus.Error)
                arg.ErrorText = "El nombre debe de ser en letras mayusculas";
        }



    }
}
