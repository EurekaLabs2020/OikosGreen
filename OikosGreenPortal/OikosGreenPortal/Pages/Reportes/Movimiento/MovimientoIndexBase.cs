using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Pages.Reportes.Movimiento
{
    public class MovimientoIndexBase : ComponentBase
    {

        public string selectedTab = "profile";

        public void OnSelectedTabChanged(string name)
        {
            selectedTab = name;
        }





    }
}
