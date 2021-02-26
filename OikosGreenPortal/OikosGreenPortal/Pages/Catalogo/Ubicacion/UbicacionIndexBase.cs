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

namespace OikosGreenPortal.Pages.Catalogo.Ubicacion
{
    public class UbicacionIndexBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Ubicacion_data> _lista { get; set; }
        public List<Ubicacion_data> _listaSecundaria { get; set; }
        public Ubicacion_data _regActual { get; set; }
        public List<String> _listaTipoUbicacion { get; set; }
        public Int64 _datoPadre { get; set; }
        public String _datoTipoUbicacion
        {
            get { return datoTipoUbicacion; }
            set
            {
                datoTipoUbicacion = value;
                _datoPadre = 0;
                if (datoTipoUbicacion == _listaTipoUbicacion[0] || datoTipoUbicacion=="0")
                    _listaSecundaria = null;
                else if (datoTipoUbicacion == _listaTipoUbicacion[1])
                    _listaSecundaria = _lista.Where(w => w.type.Trim().ToUpper() == _listaTipoUbicacion[0]).ToList();
                else
                    _listaSecundaria = _lista.Where(w => w.type.Trim().ToUpper() == _listaTipoUbicacion[1]).ToList();
            }
        }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }
        
        private infoBrowser _dataStorage { get; set; }
        private String datoTipoUbicacion { get; set; }
        private Boolean isok { get; set; } = false;



        protected async override Task OnInitializedAsync()
        {
            _lista = new List<Ubicacion_data>();
            _listaSecundaria = null;
            _datoPadre = 0;
            _Mensaje = "";
            _regActual = new Ubicacion_data();
            TipoUbicacion tipoUbica = new TipoUbicacion();
            _listaTipoUbicacion = tipoUbica.tiposUbicaciones();
            UbicacionesRequest _dataRequest = new UbicacionesRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlubicacion_getall, "");
                _dataRequest = JsonConvert.DeserializeObject<UbicacionesRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities;

            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal);
            }
        }


        public void estilofila(Ubicacion_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Ubicacion_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }


        

        public async Task insertaFila_(EventArgs arg)
        {
            // Evaluar que si vengan con información
            Boolean isok = false;
            var valores = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Ubicacion_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Ubicacion_data, System.Collections.Generic.Dictionary<string, object>>)arg).Item;

            try{
                ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Ubicacion_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values.Remove("type");
                ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Ubicacion_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values.Remove("nameparent");
                ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Ubicacion_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values.Add("type", _datoTipoUbicacion);
                ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Ubicacion_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values.Add("nameparent", _lista.Where(w => w.id == _datoPadre).Select(s => s.name).FirstOrDefault());
            }catch (Exception ex){}

            //if (validaDatos(valores))
            //{
                var nombre = valores.Where(w => w.Key == "name").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
                var code = valores.Where(w => w.Key == "code").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
                item.name = nombre;
                item.code = code;
                item.active = true;
                item.parent = _datoPadre;
                item.nameparent = _lista.Where(w => w.id == _datoPadre).Select(s => s.name).FirstOrDefault();
                item.type = _datoTipoUbicacion;
                item.usercreate = _dataStorage.user.user;
                item.datecreate = DateTime.Now;
                item.usermodify = _dataStorage.user.user;
                item.datemodify = DateTime.Now;
                try
                {
                    var resultado = await General.solicitudUrl<Ubicacion_data>(_dataStorage.user.token, "POST", Urls.urlubicacion_insert, item);
                    UbicacionRequest _dataRequest = JsonConvert.DeserializeObject<UbicacionRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity.id > 0)
                    {
                        item.id = _dataRequest.entity.id;
                        _lista.Add(item);
                        //_mensajeIsDanger = "lert-success";
                        //_Mensaje = "REGISTRO ALMACENADO CON EXITO!!!";
                        isok = true;
                        StateHasChanged();
                    }
                }
                catch (Exception ex) { item = new Ubicacion_data();  _Mensaje = ex.Message; }
            //}
            if (!isok)
                ((System.ComponentModel.CancelEventArgs)arg).Cancel = true;
        }

        public async Task updateFila_(EventArgs arg)
        {
            Boolean isok = false;
            var valores = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Ubicacion_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values;
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Ubicacion_data, System.Collections.Generic.Dictionary<string, object>>)arg).Item;

            try
            {
                ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Ubicacion_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values.Remove("type");
                ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Ubicacion_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values.Remove("nameparent");
                ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Ubicacion_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values.Add("type", _datoTipoUbicacion);
                ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Ubicacion_data, System.Collections.Generic.Dictionary<string, object>>)arg).Values.Add("nameparent", _lista.Where(w => w.id == _datoPadre).Select(s => s.name).FirstOrDefault());
            }
            catch (Exception ex) { }

            //if (validaDatos(valores))
            //{
                var nombre = valores.Where(w => w.Key == "name").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
                var code = valores.Where(w => w.Key == "code").Select(s => s.Value.ToString().ToUpper()).FirstOrDefault();
                item.name = nombre;
                item.code = code;
                item.parent = _datoPadre;
                item.nameparent = _lista.Where(w => w.id == _datoPadre).Select(s => s.name).FirstOrDefault();
                item.type = _datoTipoUbicacion;
                item.usermodify = _dataStorage.user.user;
                item.datemodify = DateTime.Now;
                try
                {
                    var resultado = await General.solicitudUrl<Ubicacion_data>(_dataStorage.user.token, "POST", Urls.urlubicacion_update, item);
                    UbicacionRequest _dataRequest = JsonConvert.DeserializeObject<UbicacionRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity.id > 0)
                    {
                        item.id = _dataRequest.entity.id;
                        isok = true;
                    }

                }
                catch (Exception) { item = new Ubicacion_data(); }
            //}
            if (!isok)
                ((System.ComponentModel.CancelEventArgs)arg).Cancel = true;
            _datoPadre = 0;
            _datoTipoUbicacion = "0";
        }

        public async Task inactiveFila_(EventArgs arg)
        {
            var item = ((Blazorise.DataGrid.CancellableRowChange<OikosGreenPortal.Data.Request.Ubicacion_data>)arg).Item;
            item.active = !item.active;
            item.usermodify = _dataStorage.user.user;
            item.datemodify = DateTime.Now;
            ((System.ComponentModel.CancelEventArgs)arg).Cancel = true;
            try
            {
                var resultado = await General.solicitudUrl<Ubicacion_data>(_dataStorage.user.token, "POST", Urls.urlubicacion_inactive, item);
                UbicacionRequest _dataRequest = JsonConvert.DeserializeObject<UbicacionRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entity != null && _dataRequest.entity.id > 0)
                    item.id = _dataRequest.entity.id;
            }
            catch (Exception) { }
        }

        public Boolean validaDatos(Ubicacion_data _paraValidar)
        {
            _Mensaje = "";
            _mensajeIsDanger = "alert-danger";
            if (_paraValidar.name==null)
                _Mensaje += "Por favor diligenciar el NOMBRE, es un campo obligatorio.&s";
            if (_paraValidar.code==null)
                _Mensaje += "Por favor diligenciar el CODIGO, es un campo obligatorio.&s";
            if (_paraValidar.type==null)
                _Mensaje += "Por favor diligenciar el TIPO, es un campo obligatorio.&s";
            else if(_paraValidar.type != _listaTipoUbicacion[0])
                 if (_paraValidar.nameparent==null)
                    _Mensaje += "Por favor diligenciar el PADRE, es un campo obligatorio.&s";


            if (_Mensaje.Trim().Length > 0)
                return false;
            return true;
        }

        public void iniciaDatos(Ubicacion_data data)
        {
            _datoPadre = 0;
            _datoTipoUbicacion = "0";
        }

        public async Task insertFila(SavedRowItem<Ubicacion_data, Dictionary<String, object>> e)
        {
            isok = false;
            e.Item.type = _datoTipoUbicacion;
            e.Item.parent = _datoPadre;
            e.Item.nameparent = _lista.Where(w => w.id == _datoPadre).Select(s => s.name).FirstOrDefault();
            e.Item.name = e.Item.name.ToUpper();
            Ubicacion_data reg = e.Item;
            datosAdicionales(true, ref reg);
            if (validaDatos(e.Item))
            {
                try
                {
                    var resultado = await General.solicitudUrl<Ubicacion_data>(_dataStorage.user.token, "POST", Urls.urlubicacion_insert, reg);
                    UbicacionRequest _dataRequest = JsonConvert.DeserializeObject<UbicacionRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequest!=null && _dataRequest.status!=null && _dataRequest.status.code == 200)
                    {
                        if (_dataRequest.entity != null && _dataRequest.entity.id > 0)
                        {
                            e.Item.id = _dataRequest.entity.id;
                            isok = true;
                        }
                    }
                    else
                        _Mensaje = _dataRequest.status.message;
                }
                catch (Exception ex) { _Mensaje = ex.Message; }
            }
            StateHasChanged();
            if (isok) 
                _lista.Add(reg);
            //else
            //    await General.MensajeModal("Error Insertando", _Mensaje, _modal);
            
        }



        public async Task updateFila(SavedRowItem<Ubicacion_data, Dictionary<String, object>> e)
        {

        }

        public async Task inactiveFila(Ubicacion_data e)
        {

        }
        
        private void datosAdicionales(Boolean isNuevo, ref Ubicacion_data item)
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

    }
}
