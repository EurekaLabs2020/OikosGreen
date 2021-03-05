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

namespace OikosGreenPortal.Pages.Catalogo.Categorias
{
    public class CategoriasBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] NavigationManager _nav { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Categoria_data> _lista { get; set; }
        public List<Categoria_data> _listaSecundaria { get; set; }
        public Categoria_data _regActual { get; set; }
        public List<String> _listaTipoUbicacion { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }

        private infoBrowser _dataStorage { get; set; }
        private String datoTipoUbicacion { get; set; }
        private Boolean isok { get; set; } = false;
        private String urlgetall { get; set; } = Urls.urlcategoria_getall;
        private String urlinsert { get; set; } = Urls.urlcategoria_insert;
        private String urlupdate { get; set; } = Urls.urlcategoria_update;
        private String urlinactive { get; set; } = Urls.urlcategoria_inactive;
        private String urlgetcode { get; set; } = Urls.urlcategoria_getbycode;


        protected async override Task OnInitializedAsync()
        {
            _lista = new List<Categoria_data>();
            _listaSecundaria = null;
            _Mensaje = "";
            _regActual = new Categoria_data();
            CategoriasRequest _dataRequest = new CategoriasRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", urlgetall, "");
                _dataRequest = JsonConvert.DeserializeObject<CategoriasRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _listaSecundaria= _dataRequest.entities;

            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }

        #region Presentación
        public void estilofila(Categoria_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Categoria_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion


        public Boolean validaDatos(Categoria_data _paraValidar)
        {
            _Mensaje = "";
            _mensajeIsDanger = "alert-danger";
            if (_paraValidar.name == null)
                _Mensaje += "Por favor diligenciar el NOMBRE, es un campo obligatorio.&s";


            if (_Mensaje.Trim().Length > 0)
                return false;
            return true;
        }

        public void iniciaDatos(Categoria_data data)
        {
            data.parent = 0;            
            _Mensaje = "";
        }

        public async Task insertFila(SavedRowItem<Categoria_data, Dictionary<String, object>> e)
        {
            e.Item.id = await setData(e.Item, true, urlinsert);
        }

        public async Task updateFila(SavedRowItem<Categoria_data, Dictionary<String, object>> e)
        {
            await setData(e.Item, false, urlupdate);
        }

        public async Task inactiveFila(Categoria_data item)
        {
            item.active = !item.active;
            try
            {
                var resultado = await General.solicitudUrl<Categoria_data>(_dataStorage.user.token, "POST", urlinactive, item);
                CategoriaRequest _dataRequest = JsonConvert.DeserializeObject<CategoriaRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest == null || _dataRequest.entity == null || _dataRequest.entity.id == 0)
                    item.active = !item.active;
            }
            catch (Exception) { item.active = !item.active; }
        }

        private void datosAdicionales(Boolean isNuevo, ref Categoria_data item)
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

        private async Task<Int64> setData(Categoria_data Item, Boolean Crear, String Url)
        {
            Int64 retorno = 0;
            isok = false;                        
            Item.nameparent = _lista.Where(w => w.id == Item.parent).Select(s => s.name).FirstOrDefault();
            Item.name = Item.name.ToUpper();
            Categoria_data reg = Item;
            datosAdicionales(Crear, ref reg);
            if (validaDatos(Item))
            {
                var resultadoCode = await General.solicitudUrl<Categoria_data>(_dataStorage.user.token, "POST", urlgetcode, reg);
                CategoriaRequest _dataRequestCode = JsonConvert.DeserializeObject<CategoriaRequest>(resultadoCode.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestCode != null && (_dataRequestCode.status.code != 200 || !Crear))
                {
                    try
                    {
                        var resultado = await General.solicitudUrl<Categoria_data>(_dataStorage.user.token, "POST", Url, reg);
                        CategoriaRequest _dataRequest = JsonConvert.DeserializeObject<CategoriaRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                        if (_dataRequest != null && _dataRequest.status != null && _dataRequest.status.code == 200)
                        {
                            if (_dataRequest.entity != null && _dataRequest.entity.id > 0)
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
                    _Mensaje = "Por favor revisar, el registro se encuentra duplicado.&s";
            }
            StateHasChanged();
            if (!isok && Crear)
                _lista.Remove(reg);
            return retorno;
        }


    }
}
