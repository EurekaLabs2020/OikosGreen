#pragma checksum "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5c6c5dd6d04581a7a7478aebcffa04434abf8834"
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
#line 22 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Pages.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.PersonalClass;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Data.Personal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Helpers;

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\_Imports.razor"
using OikosGreenPortal.Data.Request;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
           [Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/catalogo/tipoproducto")]
    public partial class TipoProductoIndex : TipoProductoIndexBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<OikosGreenPortal.Pages.Shared.TituloComponent>(0);
            __builder.AddAttribute(1, "_titulo", "Tipo Producto");
            __builder.CloseComponent();
            __builder.AddMarkupContent(2, "\r\n");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "container");
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "class", "row");
            __builder.OpenComponent<Blazorise.DataGrid.DataGrid<TipoProducto_data>>(7);
            __builder.AddAttribute(8, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.Generic.IEnumerable<TipoProducto_data>>(
#nullable restore
#line 10 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                   _lista

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "ShowPager", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 10 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                                                      true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "Filterable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 11 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                              true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(11, "FilterMethod", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.DataGrid.DataGridFilterMethod>(
#nullable restore
#line 11 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                  DataGridFilterMethod.Contains

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(12, "PageSize", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 11 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                                           5

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(13, "Editable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 11 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                                                        true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(14, "EditMode", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.DataGrid.DataGridEditMode>(
#nullable restore
#line 12 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                            DataGridEditMode.Popup

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(15, "RowStyling", new System.Action<TipoProducto_data, Blazorise.DataGrid.DataGridRowStyling>(
#nullable restore
#line 12 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                 estilofila

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(16, "SelectedRowStyling", new System.Action<TipoProducto_data, Blazorise.DataGrid.DataGridRowStyling>(
#nullable restore
#line 12 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                                                  filaSeleccionada

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "RowInserting", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Blazorise.DataGrid.CancellableRowChange<TipoProducto_data, System.Collections.Generic.Dictionary<System.String, System.Object>>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Blazorise.DataGrid.CancellableRowChange<TipoProducto_data, System.Collections.Generic.Dictionary<System.String, System.Object>>>(this, 
#nullable restore
#line 13 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                 insertaFila

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(18, "RowUpdating", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Blazorise.DataGrid.CancellableRowChange<TipoProducto_data, System.Collections.Generic.Dictionary<System.String, System.Object>>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Blazorise.DataGrid.CancellableRowChange<TipoProducto_data, System.Collections.Generic.Dictionary<System.String, System.Object>>>(this, 
#nullable restore
#line 14 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                updateFila

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(19, "RowRemoving", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Blazorise.DataGrid.CancellableRowChange<TipoProducto_data>>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Blazorise.DataGrid.CancellableRowChange<TipoProducto_data>>(this, 
#nullable restore
#line 15 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                inactiveFila

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(20, "SelectedRow", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<TipoProducto_data>(
#nullable restore
#line 10 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                               _regActual

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(21, "SelectedRowChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<TipoProducto_data>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<TipoProducto_data>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _regActual = __value, _regActual))));
            __builder.AddAttribute(22, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<Blazorise.DataGrid.DataGridCommandColumn<TipoProducto_data>>(23);
                __builder2.AddAttribute(24, "NewCommandTemplate", (Microsoft.AspNetCore.Components.RenderFragment<Blazorise.DataGrid.CommandContext>)((context) => (__builder3) => {
                    __builder3.OpenComponent<Blazorise.Button>(25);
                    __builder3.AddAttribute(26, "Color", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.Color>(
#nullable restore
#line 19 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                       Color.Success

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(27, "Clicked", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 19 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
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
                __builder2.AddAttribute(31, "EditCommandTemplate", (Microsoft.AspNetCore.Components.RenderFragment<Blazorise.DataGrid.CommandContext<TipoProducto_data>>)((context) => (__builder3) => {
                    __builder3.OpenComponent<Blazorise.Button>(32);
                    __builder3.AddAttribute(33, "Color", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Blazorise.Color>(
#nullable restore
#line 22 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                       Color.Primary

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(34, "Clicked", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, 
#nullable restore
#line 22 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
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
                __builder2.AddAttribute(38, "DeleteCommandTemplate", (Microsoft.AspNetCore.Components.RenderFragment<Blazorise.DataGrid.CommandContext<TipoProducto_data>>)((context) => (__builder3) => {
                }
                ));
                __builder2.AddAttribute(39, "ClearFilterCommandTemplate", (Microsoft.AspNetCore.Components.RenderFragment<Blazorise.DataGrid.CommandContext>)((context) => (__builder3) => {
                    __builder3.OpenElement(40, "span");
                    __builder3.AddAttribute(41, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 25 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                  context.Clicked

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddContent(42, "Limpiar Filtro");
                    __builder3.CloseElement();
                }
                ));
                __builder2.AddAttribute(43, "SaveCommandTemplate", (Microsoft.AspNetCore.Components.RenderFragment<Blazorise.DataGrid.CommandContext<TipoProducto_data>>)((context) => (__builder3) => {
                    __builder3.OpenElement(44, "button");
                    __builder3.AddAttribute(45, "class", "btn btn-info");
                    __builder3.AddAttribute(46, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 26 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                                  context.Clicked

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddContent(47, "Grabar");
                    __builder3.CloseElement();
                }
                ));
                __builder2.AddAttribute(48, "CancelCommandTemplate", (Microsoft.AspNetCore.Components.RenderFragment<Blazorise.DataGrid.CommandContext<TipoProducto_data>>)((context) => (__builder3) => {
                    __builder3.OpenElement(49, "button");
                    __builder3.AddAttribute(50, "class", "btn btn-danger btn-cancel");
                    __builder3.AddAttribute(51, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 27 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                                                 context.Clicked

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddContent(52, "Cancelar");
                    __builder3.CloseElement();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(53, "\r\n\r\n                ");
                __builder2.OpenComponent<Blazorise.DataGrid.DataGridColumn<TipoProducto_data>>(54);
                __builder2.AddAttribute(55, "Field", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 30 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                  nameof(TipoProducto_data.id)

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(56, "Caption", "Id");
                __builder2.AddAttribute(57, "Sortable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 30 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                                                                       false

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(58, "\r\n                ");
                __builder2.OpenComponent<Blazorise.DataGrid.DataGridColumn<TipoProducto_data>>(59);
                __builder2.AddAttribute(60, "Field", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 31 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                  nameof(TipoProducto_data.name)

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(61, "Caption", "Nombre");
                __builder2.AddAttribute(62, "Validator", new System.Action<Blazorise.ValidatorEventArgs>(
#nullable restore
#line 31 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                                                                                validaName

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(63, "Editable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 31 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                                                                                                      true

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(64, "\r\n                ");
                __builder2.OpenComponent<Blazorise.DataGrid.DataGridCheckColumn<TipoProducto_data>>(65);
                __builder2.AddAttribute(66, "Field", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 32 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                       nameof(TipoProducto_data.active)

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(67, "Caption", "Activo");
                __builder2.AddAttribute(68, "Editable", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 32 "D:\Negocio\OikosGreen\OikosGreen\OikosGreen\OikosGreenPortal\OikosGreenPortal\Pages\Catalogo\TipoProducto\TipoProductoIndex.razor"
                                                                                                                                    true

#line default
#line hidden
#nullable disable
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.AddAttribute(69, "FirstPageButtonTemplate", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(70, "<span>Prim</span>");
            }
            ));
            __builder.AddAttribute(71, "PreviousPageButtonTemplate", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(72, "<span>Ant</span>");
            }
            ));
            __builder.AddAttribute(73, "NextPageButtonTemplate", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(74, "<span>Sig</span>");
            }
            ));
            __builder.AddAttribute(75, "LastPageButtonTemplate", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(76, "<span>Ult</span>");
            }
            ));
            __builder.AddAttribute(77, "PopupTitleTemplate", (Microsoft.AspNetCore.Components.RenderFragment<Blazorise.DataGrid.PopupTitleContext<TipoProducto_data>>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(78, "<span>Registro</span>");
            }
            ));
            __builder.AddAttribute(79, "EmptyTemplate", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(80, "<div class=\"box\"> No hay información...!!</div>");
            }
            ));
            __builder.AddAttribute(81, "LoadingTemplate", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(82, "<div class=\"box\"><progress class=\"progress is-small is-primary\" max=\"100\"></progress></div>");
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
