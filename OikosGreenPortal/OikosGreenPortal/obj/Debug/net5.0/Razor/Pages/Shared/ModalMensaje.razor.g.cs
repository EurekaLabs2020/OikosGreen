#pragma checksum "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Shared\ModalMensaje.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "347729ddc98ab356d13496c3fbbf2af6657e5c7d"
// <auto-generated/>
#pragma warning disable 1591
namespace OikosGreenPortal.Pages.Shared
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazorise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazored.Menu;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazorise.DataGrid;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Pages.Auth.login;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Pages.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.PersonalClass;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Data.Personal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Data.Request;

#line default
#line hidden
#nullable disable
    public partial class ModalMensaje : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "pop-up-form");
            __builder.OpenElement(2, "div");
            __builder.OpenElement(3, "label");
            __builder.OpenElement(4, "h3");
            __builder.AddContent(5, 
#nullable restore
#line 4 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Shared\ModalMensaje.razor"
                    titulo

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(6, "\r\n    ");
            __builder.OpenElement(7, "div");
            __builder.OpenElement(8, "p");
#nullable restore
#line 8 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Shared\ModalMensaje.razor"
             foreach (var linea in contenido.Split("&s"))
            {
                

#line default
#line hidden
#nullable disable
            __builder.AddContent(9, 
#nullable restore
#line 10 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Shared\ModalMensaje.razor"
                 linea

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(10, "<br>");
#nullable restore
#line 12 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Shared\ModalMensaje.razor"
            }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 15 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Shared\ModalMensaje.razor"
     if (titulo.ToUpper().Trim() == "CONFIRMACION")
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "row");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "class", "col-md-6");
            __builder.OpenElement(15, "button");
            __builder.AddAttribute(16, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 19 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Shared\ModalMensaje.razor"
                                  BlazoredModal.CloseAsync

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "class", "btn btn-warning btn-block");
            __builder.AddContent(18, "SI");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(19, "\r\n            ");
            __builder.OpenElement(20, "div");
            __builder.AddAttribute(21, "class", "col-md-6");
            __builder.OpenElement(22, "button");
            __builder.AddAttribute(23, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 22 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Shared\ModalMensaje.razor"
                                  BlazoredModal.CancelAsync

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(24, "class", "btn btn-danger btn-block");
            __builder.AddContent(25, "NO");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 25 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Shared\ModalMensaje.razor"
    }
    else
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(26, "button");
            __builder.AddAttribute(27, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 28 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Shared\ModalMensaje.razor"
                          BlazoredModal.CloseAsync

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(28, "class", "btn btn-success btn-block");
            __builder.AddContent(29, "OK");
            __builder.CloseElement();
#nullable restore
#line 29 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Shared\ModalMensaje.razor"
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Shared\ModalMensaje.razor"
     if (!String.IsNullOrEmpty(Mensaje))
    {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(30, "div");
            __builder.AddAttribute(31, "class", "row");
            __builder.AddAttribute(32, "style", "text-align:left; font-weight:bold");
            __builder.OpenElement(33, "span");
#nullable restore
#line 34 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Shared\ModalMensaje.razor"
                 foreach (String mensaje in Mensaje.Split("&s"))
                {
                    

#line default
#line hidden
#nullable disable
            __builder.AddContent(34, 
#nullable restore
#line 36 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Shared\ModalMensaje.razor"
                     mensaje

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(35, "<br>");
#nullable restore
#line 38 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Shared\ModalMensaje.razor"
                }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
#nullable restore
#line 41 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Shared\ModalMensaje.razor"
    }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 44 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Shared\ModalMensaje.razor"
       
    [CascadingParameter] BlazoredModalInstance BlazoredModal { get; set; }
    [Parameter] public String titulo { get; set; }
    [Parameter] public String contenido { get; set; }
    private String Mensaje { get; set; } = "";

    protected override void OnInitialized()
    {
        base.OnInitialized();
    }


#line default
#line hidden
#nullable disable
    }
}
#pragma warning restore 1591
