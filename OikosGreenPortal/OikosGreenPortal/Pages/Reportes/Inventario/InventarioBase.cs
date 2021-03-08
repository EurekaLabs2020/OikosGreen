﻿using Blazored.Modal.Services;
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

namespace OikosGreenPortal.Pages.Reportes.Inventario
{
    public class InventarioBase : ComponentBase
    {
        [Inject] IModalService _modal { get; set; }
        [Inject] NavigationManager _nav { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<SaldoProducto_data> _lista { get; set; }
        public List<Producto_data> _listaSecundaria { get; set; }
        public String _Mensaje { get; set; }
        public String _mensajeIsDanger { get; set; }
        public DateTime _fechaini { get; set; }
        public DateTime _fechafin { get; set; }
        public Int64 _datoPadre { get; set; }
        public Boolean mostrar { get; set; }


        private infoBrowser _dataStorage { get; set; }
        private Boolean isok { get; set; } = false;


        protected async override Task OnInitializedAsync()
        {
            _lista = new List<SaldoProducto_data>();
            _listaSecundaria = null;
            _Mensaje = "";
            _datoPadre = 0;
            mostrar = false;
            SaldoProductosRequest _dataRequest = new SaldoProductosRequest();
            try
            {
                _dataStorage = null;
                do
                {
                    var _resultado = await _storage.GetAsync<infoBrowser>("data");
                    _dataStorage = _resultado.Value;
                } while (_dataStorage == null);

                var resultado = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlsaldoproducto_getall, "");
                _dataRequest = JsonConvert.DeserializeObject<SaldoProductosRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());
                if (_dataRequest != null && _dataRequest.entities != null && _dataRequest.entities.Count > 0)
                    _lista = _dataRequest.entities.OrderByDescending(o => o.period).ToList();
                //Obtenemos la Tabla de Productos
                try
                {
                    var resultadoProd = await General.solicitudUrl<String>(_dataStorage.user.token, "GET", Urls.urlproducto_getall, "");
                    ProductosRequest _dataRequestProd = JsonConvert.DeserializeObject<ProductosRequest>(resultadoProd.Content.ReadAsStringAsync().Result.ToString());
                    if (_dataRequestProd != null && _dataRequestProd.entities != null && _dataRequestProd.entities.Count > 0)
                        _listaSecundaria = _dataRequestProd.entities.OrderBy(o => o.code).ToList();
                }
                catch (Exception ex) { await General.MensajeModal("ERROR", ex.Message, _modal, _nav); }
            }
            catch (Exception ex)
            {
                await General.MensajeModal("ERROR", ex.Message, _modal, _nav);
            }
        }

        #region Presentación
        public void estilofila(SaldoProducto_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(SaldoProducto_data reg, DataGridRowStyling style)
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
            _lista = new List<SaldoProducto_data>();
            if (_datoPadre > 0 && _fechaini <= _fechafin)
            {
                Transaccion_data envio = new Transaccion_data();
                envio.terceroid = _datoPadre;
                envio.dateinitial = _fechaini;
                envio.datefinal = _fechafin;

                //try
                //{
                //    var resultado = await General.solicitudUrl<Transaccion_data>(_dataStorage.user.token, "POST", Urls.urltransaccion_getbyfecha, envio);
                //    _dataRequest = JsonConvert.DeserializeObject<TransaccionRequest>(resultado.Content.ReadAsStringAsync().Result.ToString());

                //    if (_dataRequest != null && _dataRequest.entities != null)
                //    {
                //        _lista = _dataRequest.entities.OrderByDescending(o => o.date).OrderBy(o2 => o2.numberdocument).OrderBy(o3 => o3.detline).OrderBy(o4 => o4.code).ToList();
                //        foreach (var reg in _lista)
                //            reg.points = reg.points * (reg.affect == "S" ? -1 : (reg.affect == "E" ? 1 : 0));
                //    }
                //}
                //catch
                //{
                //    _lista = new List<Transaccion_data>();
                //}
            }
        }



    }
}
