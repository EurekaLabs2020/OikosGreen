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

namespace OikosGreenPortal.Pages.Catalogo.Documentos
{
    public class DocumentosBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] NavigationManager _nav { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Documento_data> _lista { get; set; }
        public List<Lista_data> _listaSecundaria { get; set; }
        public List<TipoProducto_data> _listaTipoProducto { get; set; }
        public Documento_data _regActual { get; set; }
        public List<String> _listaTipo { get; set; }
        public List<String> _listaClase { get; set; }
        public List<String> _listaAfecte { get; set; }
        public List<String> _listaTerceroTipo { get; set; }

        public Int64 _datoPadre { get; set; }
        public String _datoTipo
        {
            get { return datoTipo; }
            set
            {
                datoTipo = value;
                _datoPadre = 0;
            }
        }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }

        private infoBrowser _dataStorage { get; set; }
        private String datoTipo { get; set; }
        private Boolean isok { get; set; } = false;
        private String urlgetall { get; set; } = Urls.urldocumento_getall;
        private String urlinsert { get; set; } = Urls.urldocumento_insert;
        private String urlupdate { get; set; } = Urls.urldocumento_update;
        private String urlinactive { get; set; } = Urls.urldocumento_inactive;
        private String urlgetcode { get; set; } = Urls.urldocumento_getbycode;


        protected async override Task OnInitializedAsync()
        {
            _lista = new List<Documento_data>();
            _listaSecundaria = null;
            _listaTipoProducto = null;
            _datoPadre = 0;
            _Mensaje = "";
            _regActual = new Documento_data();

            TipoDocumento tipo = new TipoDocumento();
            _listaTipo = tipo.tiposDocumentos();
            ClaseDocumento clase = new ClaseDocumento();
            _listaClase = clase.clasesDocumentos();
            AfecteDocumento afecte = new AfecteDocumento();
            _listaAfecte = afecte.afectesDocumentos();
            TipoTerceroTipo tipoterc = new TipoTerceroTipo();
            _listaTerceroTipo = tipoterc.tiposTerceroTipo();

            DocumentosRequest _dataRequest = new DocumentosRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", urlgetall, "");
                _dataRequest = JsonConvert.DeserializeObject<DocumentosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities;
                if (_lista != null)
                {
                    foreach (var x in _lista)
                    {
                        x.idlist = x.listid == null ? 0 : x.listid.Value;
                        x.nature = x.nature == null ? "0" : x.nature;
                        x.thirdtype = x.thirdtype==null ? "0": x.thirdtype;
                    }
                }
                // Obtenemos la Lista Ciudad
                try
                {
                    var resultadoLista = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urllista_getall, "");
                    ListasRequest _dataRequestLista = JsonConvert.DeserializeObject<ListasRequest>(resultadoLista.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestLista != null && _dataRequestLista.entities != null && _dataRequestLista.entities.Count > 0)
                        _listaSecundaria = _dataRequestLista.entities.ToList();
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }

                try
                {
                    var resultadoTipoProducto = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urltipoproducto_getall, "");
                    TipoProductosRequest _dataRequestTipoProducto = JsonConvert.DeserializeObject<TipoProductosRequest>(resultadoTipoProducto.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestTipoProducto != null && _dataRequestTipoProducto.entities != null && _dataRequestTipoProducto.entities.Count > 0)
                        _listaTipoProducto = _dataRequestTipoProducto.entities.ToList();
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }

        #region Presentación
        public void estilofila(Documento_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Documento_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion


        public Boolean validaDatos(Documento_data _paraValidar)
        {
            _Mensaje = "";
            _mensajeIsDanger = "alert-danger";
            if (_paraValidar.name == null)
                _Mensaje += "Por favor diligenciar el NOMBRE, es un campo obligatorio.&s";
            if (_paraValidar.code == null)
                _Mensaje += "Por favor diligenciar el CODIGO, es un campo obligatorio.&s";
            if (_paraValidar.type == null)
                _Mensaje += "Por favor diligenciar el TIPO, es un campo obligatorio.&s";

            if (_Mensaje.Trim().Length > 0)
                return false;
            return true;
        }

        public void iniciaDatos(Documento_data data)
        {
            _datoPadre = 0;
            _datoTipo = "0";
            _Mensaje = "";
            data.active = true;
            data.hasthird = false;
            data.affect = data.thirdtype = data.nature= "0";
            data.code = data.name = data.type = data.typeclass= data.usercreate= data.usermodify= "";
            data.idlist = data.consecutive = data.typeproductid= data.copie= 0;
            data.datemodify = data.datecreate = DateTime.Now;            
        }

        public async Task insertFila(SavedRowItem<Documento_data, Dictionary<String, object>> e)
        {
            //e.Item.id = await setData(e.Item, true, urlinsert);
        }

        public async Task updateFila(SavedRowItem<Documento_data, Dictionary<String, object>> e)
        {
            //await setData(e.Item, false, urlupdate);
        }

        public async Task inactiveFila(Documento_data item)
        {
            item.active = !item.active;
            try
            {
                var resultado = await General.solicitudUrl<Documento_data>(_dataStorage.user.token, "POST", urlinactive, item);
                DocumentoRequest _dataRequest = JsonConvert.DeserializeObject<DocumentoRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest == null || _dataRequest.entity == null || _dataRequest.entity.id == 0)
                    item.active = !item.active;
            }
            catch (Exception) { item.active = !item.active; }
        }

        private void datosAdicionales(Boolean isNuevo, ref Documento_data item)
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

        private async Task<Int64> setData(Documento_data Item, Boolean Crear, String Url)
        {
            Int64 retorno = 0;
            isok = false;
            Documento_data reg = Item;
            datosAdicionales(Crear, ref reg);
            if (validaDatos(Item))
            {
                var resultadoCode = await General.solicitudUrl<Documento_data>(_dataStorage.user.token, "POST", urlgetcode, reg);
                DocumentoRequest _dataRequestCode = JsonConvert.DeserializeObject<DocumentoRequest>(resultadoCode.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequestCode != null && (_dataRequestCode.status.code != 200 || !Crear))
                {
                    try
                    {
                        var resultado = await General.solicitudUrl<Documento_data>(_dataStorage.user.token, "POST", Url, reg);
                        DocumentoRequest _dataRequest = JsonConvert.DeserializeObject<DocumentoRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
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
                    _Mensaje = "Por favor revisar, el código se encuentra duplicado.&s";
            }
            //if (!isok && Crear)
                //_lista.Remove(reg);
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
            var valores = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Documento_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Documento_data>)arg).Item;
            item.listid = item.idlist = Convert.ToInt64(valores["idlist"].ToString());
            item.name = valores["name"].ToString();
            item.thirdtype = valores["thirdtype"].ToString();
            if (Crear)
            {
                item.nature = valores["nature"].ToString();
                item.hasthird =Convert.ToBoolean( valores["hasthird"].ToString());
                item.type = valores["type"].ToString();
                item.typeclass = valores["typeclass"].ToString();
                item.affect = valores["affect"].ToString();
                item.typeproductid = Convert.ToInt64(valores["typeproductid"].ToString());
                try
                {
                    item.consecutive = Convert.ToInt64(valores["consecutive"].ToString());
                }
                catch { item.consecutive = 0; }
            }
            item.code = valores["code"].ToString();             
            item.namelist = _listaSecundaria.Where(w => w.id == item.idlist).Select(s => s.name).FirstOrDefault();
            Int64 id = await setData(item, Crear ? true : false, Crear ? urlinsert : urlupdate);           
            StateHasChanged();
            if (id == 0)
                return false;
            if (Crear && id > 0)
            {
                item.id = id;
                _lista.Add(item);
            }
            return true;
        }


    }
}
