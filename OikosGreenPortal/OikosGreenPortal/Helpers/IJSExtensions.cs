using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Helpers
{
    public static class IJSExtensions
    {
        public static Task GuardarComo(this IJSRuntime js, String _name, byte[] _file)
        {
            return js.InvokeAsync<object>("saveAsFile", _name, Convert.ToBase64String(_file)).AsTask();
        }

    }
}
