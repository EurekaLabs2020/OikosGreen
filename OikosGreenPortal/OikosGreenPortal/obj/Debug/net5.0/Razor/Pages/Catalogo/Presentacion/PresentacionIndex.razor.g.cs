#pragma checksum "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "263f3277c53f0946b0ba8a01d6c616ef93c534cb"
// <auto-generated/>
#pragma warning disable 1591
namespace OikosGreenPortal.Pages.Catalogo.Presentacion
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazorise;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazored.Menu;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazored.Modal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazored.Modal.Services;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using Blazorise.DataGrid;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Pages.Auth.login;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Pages.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.PersonalClass;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Data.Personal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Data.Request;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/catalogo/presentacion")]
    public partial class PresentacionIndex : PresentacionIndexBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<OikosGreenPortal.Pages.Shared.TituloComponent>(0);
            __builder.AddAttribute(1, "_titulo", "Presentación");
            __builder.CloseComponent();
            __builder.AddMarkupContent(2, "\r\n");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "container");
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "class", "row");
            __builder.OpenComponent<Blazorise.DataGrid.DataGrid<Presentacion_data>>(7);
            __builder.AddAttribute(8, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<Presentacion_data>>(
#nullable restore
#line 10 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                   _lista

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "ShowPager", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 10 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                                                      true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "Filterable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 11 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                              true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(11, "FilterMethod", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.DataGrid.DataGridFilterMethod>(
#nullable restore
#line 11 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                  DataGridFilterMethod.Contains

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(12, "PageSize", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 11 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                                           5

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(13, "Editable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 11 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                                                        true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(14, "EditMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.DataGrid.DataGridEditMode>(
#nullable restore
#line 12 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                            DataGridEditMode.Popup

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(15, "RowStyling", new System.Action<Presentacion_data, Blazorise.DataGrid.DataGridRowStyling>(
#nullable restore
#line 12 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                 estilofila

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(16, "SelectedRowStyling", new System.Action<Presentacion_data, Blazorise.DataGrid.DataGridRowStyling>(
#nullable restore
#line 12 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                                                  filaSeleccionada

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "RowInserting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Blazorise.DataGrid.CancellableRowChange<Presentacion_data, System.Collections.Generic.Dictionary<System.String, System.Object>>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Blazorise.DataGrid.CancellableRowChange<Presentacion_data, System.Collections.Generic.Dictionary<System.String, System.Object>>>(this, 
#nullable restore
#line 13 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                 insertaFila

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(18, "RowUpdating", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Blazorise.DataGrid.CancellableRowChange<Presentacion_data, System.Collections.Generic.Dictionary<System.String, System.Object>>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Blazorise.DataGrid.CancellableRowChange<Presentacion_data, System.Collections.Generic.Dictionary<System.String, System.Object>>>(this, 
#nullable restore
#line 14 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                updateFila

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(19, "RowRemoving", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Blazorise.DataGrid.CancellableRowChange<Presentacion_data>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Blazorise.DataGrid.CancellableRowChange<Presentacion_data>>(this, 
#nullable restore
#line 15 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                inactiveFila

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(20, "SelectedRow", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Presentacion_data>(
#nullable restore
#line 10 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                               _regActual

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(21, "SelectedRowChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Presentacion_data>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Presentacion_data>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _regActual = __value, _regActual))));
            __builder.AddAttribute(22, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Blazorise.DataGrid.DataGridCommandColumn<Presentacion_data>>(23);
                __builder2.AddAttribute(24, "NewCommandTemplate", (Microsoft.AspNetCore.Components.RenderFragment<Blazorise.DataGrid.CommandContext>)((context) => (__builder3) => {
                    __builder3.OpenComponent<Blazorise.Button>(25);
                    __builder3.AddAttribute(26, "Color", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.Color>(
#nullable restore
#line 19 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                       Color.Success

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(27, "Clicked", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 19 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                context.Clicked

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.AddAttribute(28, "class", "btn-create");
                    __builder3.AddAttribute(29, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(30, "Crear");
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.AddAttribute(31, "EditCommandTemplate", (Microsoft.AspNetCore.Components.RenderFragment<Blazorise.DataGrid.CommandContext<Presentacion_data>>)((context) => (__builder3) => {
                    __builder3.OpenComponent<Blazorise.Button>(32);
                    __builder3.AddAttribute(33, "Color", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.Color>(
#nullable restore
#line 22 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                       Color.Primary

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(34, "Clicked", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 22 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                context.Clicked

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.AddAttribute(35, "class", "edit-button");
                    __builder3.AddAttribute(36, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(37, "Editar");
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.AddAttribute(38, "DeleteCommandTemplate", (Microsoft.AspNetCore.Components.RenderFragment<Blazorise.DataGrid.CommandContext<Presentacion_data>>)((context) => (__builder3) => {
                    __builder3.OpenComponent<Blazorise.Button>(39);
                    __builder3.AddAttribute(40, "Color", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.Color>(
#nullable restore
#line 24 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                           Color.Danger

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(41, "Clicked", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 24 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                                   context.Clicked

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.AddAttribute(42, "class", "btn-active");
                    __builder3.AddAttribute(43, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(44, 
#nullable restore
#line 24 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                                                                         context.Item.active ? "Inactivar" : "Activar"

#line default
#line hidden
#nullable disable
                        );
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.AddAttribute(45, "ClearFilterCommandTemplate", (Microsoft.AspNetCore.Components.RenderFragment<Blazorise.DataGrid.CommandContext>)((context) => (__builder3) => {
                    __builder3.OpenElement(46, "span");
                    __builder3.AddAttribute(47, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 25 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                  context.Clicked

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddContent(48, "Limpiar Filtro");
                    __builder3.CloseElement();
                }
                ));
                __builder2.AddAttribute(49, "SaveCommandTemplate", (Microsoft.AspNetCore.Components.RenderFragment<Blazorise.DataGrid.CommandContext<Presentacion_data>>)((context) => (__builder3) => {
                    __builder3.OpenElement(50, "button");
                    __builder3.AddAttribute(51, "class", "btn btn-info");
                    __builder3.AddAttribute(52, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 26 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                                  context.Clicked

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddContent(53, "Grabar");
                    __builder3.CloseElement();
                }
                ));
                __builder2.AddAttribute(54, "CancelCommandTemplate", (Microsoft.AspNetCore.Components.RenderFragment<Blazorise.DataGrid.CommandContext<Presentacion_data>>)((context) => (__builder3) => {
                    __builder3.OpenElement(55, "button");
                    __builder3.AddAttribute(56, "class", "btn btn-danger btn-cancel");
                    __builder3.AddAttribute(57, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 27 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                                                 context.Clicked

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddContent(58, "Cancelar");
                    __builder3.CloseElement();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(59, "\r\n\r\n                ");
                __builder2.OpenComponent<Blazorise.DataGrid.DataGridColumn<Presentacion_data>>(60);
                __builder2.AddAttribute(61, "Field", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 30 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                  nameof(Presentacion_data.id)

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(62, "Caption", "Id");
                __builder2.AddAttribute(63, "Sortable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 30 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                                                                       false

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(64, "\r\n                ");
                __builder2.OpenComponent<Blazorise.DataGrid.DataGridColumn<Presentacion_data>>(65);
                __builder2.AddAttribute(66, "Field", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 31 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                  nameof(Presentacion_data.name)

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(67, "Caption", "Nombre");
                __builder2.AddAttribute(68, "Validator", new System.Action<Blazorise.ValidatorEventArgs>(
#nullable restore
#line 31 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                                                                               validaName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(69, "Editable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 31 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                                                                                                     true

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(70, "\r\n                ");
                __builder2.OpenComponent<Blazorise.DataGrid.DataGridCheckColumn<Presentacion_data>>(71);
                __builder2.AddAttribute(72, "Field", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 32 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                       nameof(Presentacion_data.active)

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(73, "Caption", "Activo");
                __builder2.AddAttribute(74, "Editable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 32 "E:\EK\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\Presentacion\PresentacionIndex.razor"
                                                                                                                                    false

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.AddAttribute(75, "FirstPageButtonTemplate", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(76, "<span>Prim</span>");
            }
            ));
            __builder.AddAttribute(77, "PreviousPageButtonTemplate", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(78, "<span>Ant</span>");
            }
            ));
            __builder.AddAttribute(79, "NextPageButtonTemplate", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(80, "<span>Sig</span>");
            }
            ));
            __builder.AddAttribute(81, "LastPageButtonTemplate", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(82, "<span>Ult</span>");
            }
            ));
            __builder.AddAttribute(83, "PopupTitleTemplate", (Microsoft.AspNetCore.Components.RenderFragment<Blazorise.DataGrid.PopupTitleContext<Presentacion_data>>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(84, "<span>Registro</span>");
            }
            ));
            __builder.AddAttribute(85, "EmptyTemplate", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(86, "<div class=\"box\"> No hay información...!!</div>");
            }
            ));
            __builder.AddAttribute(87, "LoadingTemplate", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(88, "<div class=\"box\"><progress class=\"progress is-small is-primary\" max=\"100\"></progress></div>");
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
