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

namespace OikosGreenPortal.Pages.GestionAccesos.Usuarios
{
    public class UsuariosIndexBase : ComponentBase
    {
        [Inject] IJSRuntime js { get; set; }
        [Inject] IModalService _modal { get; set; }
        [Inject] NavigationManager _nav { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Usuario_data> _lista { get; set; }

        public List<Documento_data> _listaTipoDocument { get; set; }
        public List<Rol_data> _listaTRoles { get; set; }
        public List<String> lstSelecRol { get; set; }


        public Usuario_data _regActual { get; set; }
        //public List<String> _listaTipo { get; set; }
        public Int64 _datoPadre { get; set; }
        public String _datoTipo { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }
        public ElementReference refMultiple { get; set; }
        public string customFilterValue { get; set; }

        private infoBrowser _dataStorage { get; set; }
        private String datoTipoUbicacion { get; set; }
        private Boolean isok { get; set; } = false;
        private String urlgetall { get; set; } = Urls.urlusuario_getall;
        private String urlinsert { get; set; } = Urls.urlusuario_insert;
        private String urlupdate { get; set; } = Urls.urlusuario_update;
        private String urlinactive { get; set; } = Urls.urlusuario_inactive;
        private String urlgetcode { get; set; } = Urls.urlusuario_getbycode;




        protected override async Task OnInitializedAsync()
        {
            _lista = new List<Usuario_data>();
            _listaTipoDocument = null;
            _datoPadre = 0;
            _Mensaje = _datoTipo = "";
            _regActual = new Usuario_data();
            _listaTRoles = new List<Rol_data>();
            lstSelecRol = new List<string>();
            UsuariosRequest _dataRequest = new UsuariosRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "POST", urlgetall, "");
                _dataRequest = JsonConvert.DeserializeObject<UsuariosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities.OrderBy(o => o.nombrefull).ToList();

                //if (_lista != null)
                //    foreach (var x in _lista)
                //        x.idtercero = x.terceroid == null ? 0 : x.terceroid.Value;


                //Obtenemos la Tabla de Tipos Documento
                try
                {
                    var resultadoTipoDoc = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urldocumento_getall, "");
                    DocumentosRequest _dataRequestTipoDoc = JsonConvert.DeserializeObject<DocumentosRequest>(resultadoTipoDoc.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestTipoDoc != null && _dataRequestTipoDoc.entities != null && _dataRequestTipoDoc.entities.Count > 0)
                        _listaTipoDocument = _dataRequestTipoDoc.entities;

                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }


                //Obtenemos la Tabla de Roles
                try
                {
                    var resultadoRoles = await General.solicitudUrl<String>(_dataStorage.user.token, "POST", Urls.urlrol_getall, "");
                    RolesRequest _dataRequestRol = JsonConvert.DeserializeObject<RolesRequest>(resultadoRoles.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestRol != null && _dataRequestRol.entities != null && _dataRequestRol.entities.Count > 0)
                        _listaTRoles = _dataRequestRol.entities;

                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }

        public async Task selecRoles(ChangeEventArgs evt)
        {
            lstSelecRol = (await js.InvokeAsync<List<string>>("getSelectedValues", refMultiple)).ToList();

            //await InvokeAsync(StateHasChanged);
        }


        #region Presentación
        public void estilofila(Usuario_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Usuario_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion


        public Boolean validaDatos(Usuario_data _paraValidar)
        {
            _Mensaje = "";
            _mensajeIsDanger = "alert-danger";
            //if (_paraValidar.type == null)
            //    _Mensaje += "Por favor diligenciar el TIPO, es un campo obligatorio.&s";
           


            if (_Mensaje.Trim().Length > 0)
                return false;
            return true;
        }

        public void iniciaDatos(Usuario_data data)
        {
            _datoPadre = 0;
            _Mensaje = "";
            data.documentid = 0;
            data.lstRol = new List<String>();
        }

        public void selecc(EventArgs _dato)
        {

        }

        public async Task insertFila(SavedRowItem<Usuario_data, Dictionary<String, object>> e)
        {
            //e.Item.id = await setUbicacion(e.Item, true, urlinsert);
        }

        public async Task updateFila(SavedRowItem<Usuario_data, Dictionary<String, object>> e)
        {
            //await setUbicacion(e.Item, false, urlupdate);
        }

        public async Task inactiveFila(Usuario_data item)
        {
            item.isactive = !item.isactive;
            try
            {
                var resultado = await General.solicitudUrl<Usuario_data>(_dataStorage.user.token, "POST", urlinactive, item);
                UsuarioRequest _dataRequest = JsonConvert.DeserializeObject<UsuarioRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest == null || _dataRequest.entity == null || _dataRequest.entity.id.Trim().Length == 0)
                    item.isactive = !item.isactive;
            }
            catch (Exception) { item.isactive = !item.isactive; }
        }

        private void datosAdicionales(Boolean isNuevo, ref Usuario_data item)
        {
            if (isNuevo)
            {
                //item.usercreate = _dataStorage.user.user;
                //item.datecreate = DateTime.Now;
                //item.active = true;
            }
            //item.usermodify = _dataStorage.user.user;
            //item.datemodify = DateTime.Now;
        }

        private async Task<String> setData(Usuario_data Item, Boolean Crear, String Url)
        {
            String retorno = "";
            isok = false;
            //Item.idtercero = _datoPadre;
            
            Item.name = Item.name.ToUpper();// _lista.Where(w => w.id == _datoPadre).Select(s => s.name).FirstOrDefault();
            Item.lastname = Item.lastname.ToUpper();//_lista.Where(w => w.id == _datoPadre).Select(s => s.lastname).FirstOrDefault();
            Usuario_data reg = Item;
            //Item.type = _datoTipo;
            //Item.idtercero = _datoPadre;
            //Item.name = _lista.Where(w => w.id == _datoPadre).Select(s => s.name).FirstOrDefault();
            //Item.lastname = _lista.Where(w => w.id == _datoPadre).Select(s => s.lastname).FirstOrDefault();
            datosAdicionales(Crear, ref reg);
            if (validaDatos(Item))
            {
                var resultadoCode = await General.solicitudUrl<Usuario_data>(_dataStorage.user.token, "POST", urlgetcode, reg);
                UsuarioRequest _dataRequestCode = JsonConvert.DeserializeObject<UsuarioRequest>(resultadoCode.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestCode != null && (_dataRequestCode.status.code != 200 || !Crear))
                {
                    try
                    {
                        var resultado = await General.solicitudUrl<Usuario_data>(_dataStorage.user.token, "POST", Url, reg);
                        UsuarioRequest _dataRequest = JsonConvert.DeserializeObject<UsuarioRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                        if (_dataRequest != null && _dataRequest.status != null && _dataRequest.status.code == 200)
                        {
                            if (_dataRequest.entity != null && _dataRequest.entity.id.Trim().Length > 0)
                            {
                                isok = true;
                                retorno = _dataRequest.entity.id;
                            }
                        }
                        else
                            _Mensaje = _dataRequest.status.message;
                    }
                    catch (Exception ex) { _Mensaje = ex.Message; }
                }
                else
                    _Mensaje = "Por favor revisar, el código se encuentra duplicado.&s";
            }
            //StateHasChanged();
            //if (!isok && Crear)
            //    _lista.Remove(reg);
            return retorno;
        }

        public async Task insertingFila(EventArgs arg)
        {
            await helpGrid(arg, true);
        }

        public async Task updatingFila(EventArgs arg)
        {
            await helpGrid(arg, false);
        }

        public async Task<Boolean> helpGrid(EventArgs arg, Boolean Crear)
        {
            //var valores = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.TerceroTipo_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Usuario_data>)arg).Item;
            //item.type = _datoTipo;
            //item.terceroid = _datoPadre;
            String id = await setData(item, Crear ? true : false, Crear ? urlinsert : urlupdate);
            //StateHasChanged();
            if (id.Trim().Length == 0)
                return false;
            if (Crear && id.Trim().Length > 0)
            {
                item.id = id;
                _lista.Add(item);
            }
            return true;
        }
        #region Filtro
        public bool OnCustomFilter(Usuario_data model)
        {
            // We want to accept empty value as valid or otherwise
            // datagrid will not show anything.
            if (string.IsNullOrEmpty(customFilterValue))
                return true;

            return
                model.name?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true
                || model.user?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true
                || model.email?.Contains(customFilterValue, StringComparison.OrdinalIgnoreCase) == true;
                
        }
        #endregion
    }
}
