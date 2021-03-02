using Blazored.Modal.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Pages.Transacciones
{
    public class TransaccionesBase : ComponentBase
    {
        [Inject] public IModalService _modal { get; set; }
        [Inject] public ProtectedSessionStorage _storage { get; set; }

        public List<>



    }
}
