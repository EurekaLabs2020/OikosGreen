using Blazored.Modal;
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

namespace OikosGreenPortal.Pages.Shared
{
    public class SugerenciaTruequeSharedBase : ComponentBase
    {

        [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<Producto_data> _listProducto { get; set; }
        public List<ProductoCategoria_data> _listProdCateg { get; set; }
        public List<Producto_data> _listMostrar { get; set; }
        public Producto_data _regActual { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }
        public Decimal _puntos { get; set; }
        public Int64 _categoria { get; set; }
        public List<Categoria_data> _listCategoria { get; set; }

        private infoBrowser _dataStorage { get; set; }


        protected async override Task OnInitializedAsync()
        {
            _puntos = _categoria= 0;
            _listCategoria = new List<Categoria_data>();
            _listMostrar = new List<Producto_data>();
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
                    var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlproducto_getall, "");
                    ProductosRequest _dataRequest = JsonConvert.DeserializeObject<ProductosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                        _listProducto = _dataRequest.entities.ToList();
                }
                catch (Exception ex) { }

                try
                {
                    var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlcategoria_getall, "");
                    CategoriasRequest _dataRequest = JsonConvert.DeserializeObject<CategoriasRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                        _listCategoria = _dataRequest.entities.ToList();
                }
                catch (Exception ex) { }

                try
                {
                    var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlproductocategoria_getall, "");
                    ProductoCategoriasRequest _dataRequest = JsonConvert.DeserializeObject<ProductoCategoriasRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                        _listProdCateg = _dataRequest.entities.ToList();
                }
                catch (Exception ex) { }

            }
            catch (Exception ex)
            {
            }
        }


        public async Task cerrarModal()
        {
            await BlazoredModal.CloseAsync();
        }


        public async Task buscarData()
        {
            _listMostrar = new List<Producto_data>();
            if (_puntos != null && _puntos > 0)
                _listMostrar = _listProducto.Where(w => w.points <= _puntos).ToList();
            else if (_categoria != null && _categoria > 0)
            {
                var lista = _listProdCateg.Where(w => w.categoryid == _categoria).ToList();
                _listMostrar = (from w in _listProducto
                               join l in lista on w.id equals l.productid
                               select w).ToList();
            }
                
        }


    }
}
