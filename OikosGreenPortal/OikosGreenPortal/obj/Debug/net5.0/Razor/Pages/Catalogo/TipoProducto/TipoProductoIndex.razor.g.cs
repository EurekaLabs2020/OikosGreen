#pragma checksum "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b97e42ad71d2605bd08b4b7e5b0057281e82fc2b"
// <auto-generated/>
#pragma warning disable 1591
namespace OikosGreenPortal.Pages.Catalogo.TipoProducto
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
#line 21 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Pages.Auth.login;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.PersonalClass;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Data.Personal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Data.Request;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/catalogo/tipoproducto")]
    public partial class TipoProductoIndex : TipoProductoIndexBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "container");
            __builder.AddMarkupContent(2, "<div class=\"row\"><div class=\"col-md-10\"><h2> Tipo Producto </h2></div>\r\n            <div class=\"col-md-2\"><button class=\"btn btn-success btn-block\"> Crear</button></div></div>\r\n        ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "row");
            __builder.OpenComponent<Blazorise.DataGrid.DataGrid<TipoProducto_data>>(5);
            __builder.AddAttribute(6, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<TipoProducto_data>>(
#nullable restore
#line 17 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                             _lista

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "Filterable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 19 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                  true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "FilterMethod", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.DataGrid.DataGridFilterMethod>(
#nullable restore
#line 20 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                    DataGridFilterMethod.StartsWith

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "ShowPager", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 21 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                 true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "PageSize", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 22 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                1

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(11, "SelectedRow", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<TipoProducto_data>(
#nullable restore
#line 18 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                          _regActual

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(12, "SelectedRowChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<TipoProducto_data>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<TipoProducto_data>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _regActual = __value, _regActual))));
            __builder.AddAttribute(13, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Blazorise.DataGrid.DataGridCommandColumn<TipoProducto_data>>(14);
                __builder2.AddAttribute(15, "NewCommandTemplate", (Microsoft.AspNetCore.Components.RenderFragment<Blazorise.DataGrid.CommandContext>)((context) => (__builder3) => {
                    __builder3.OpenComponent<Blazorise.Button>(16);
                    __builder3.AddAttribute(17, "Color", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.Color>(
#nullable restore
#line 25 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                       Color.Success

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(18, "Clicked", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 25 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                context.Clicked

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.AddAttribute(19, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(20, "Nuevo");
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.AddAttribute(21, "EditCommandTemplate", (Microsoft.AspNetCore.Components.RenderFragment<Blazorise.DataGrid.CommandContext<TipoProducto_data>>)((context) => (__builder3) => {
                    __builder3.OpenComponent<Blazorise.Button>(22);
                    __builder3.AddAttribute(23, "Color", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.Color>(
#nullable restore
#line 28 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                       Color.Primary

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(24, "Clicked", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 28 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                context.Clicked

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.AddAttribute(25, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(26, "Editar");
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(27, "\r\n                ");
                __builder2.OpenComponent<Blazorise.DataGrid.DataGridColumn<TipoProducto_data>>(28);
                __builder2.AddAttribute(29, "Field", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 31 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                  nameof(TipoProducto_data.id)

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(30, "Caption", "#");
                __builder2.AddAttribute(31, "Sortable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 31 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                                                                      false

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(32, "\r\n                ");
                __builder2.OpenComponent<Blazorise.DataGrid.DataGridColumn<TipoProducto_data>>(33);
                __builder2.AddAttribute(34, "Field", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 32 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                  nameof(TipoProducto_data.name)

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(35, "Caption", "Nombre");
                __builder2.AddAttribute(36, "Editable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 32 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                                                                             true

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(37, "\r\n                ");
                __builder2.OpenComponent<Blazorise.DataGrid.DataGridColumn<TipoProducto_data>>(38);
                __builder2.AddAttribute(39, "Field", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 33 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                  nameof(TipoProducto_data.active)

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(40, "Caption", "Activo");
                __builder2.AddAttribute(41, "Editable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 33 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                                                                               true

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
