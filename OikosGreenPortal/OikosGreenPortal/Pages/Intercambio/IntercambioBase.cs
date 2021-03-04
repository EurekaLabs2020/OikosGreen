using Blazored.Modal.Services;
using Blazorise;
using Blazorise.DataGrid;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using OikosGreenPortal.Data.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Pages.Intercambio
{
    public class IntercambioBase : ComponentBase
    {
        [Inject] public IModalService _modal { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }
        [Inject] public NavigationManager _navigation { get; set; }

        public List<Transaccion_data> _lista { get; set; }



        #region Presentación
        public void estilofila(Transaccion_data reg, DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }

        public void filaSeleccionada(Transaccion_data reg, DataGridRowStyling style)
        {
            style.Style = "color: blue; font-size: 15px;";
            style.Color = Color.Success;
        }
        #endregion


    }
}
