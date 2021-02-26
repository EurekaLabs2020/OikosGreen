using Blazored.Modal;
using Blazored.Modal.Services;
using OikosGreenPortal.Data.Request;
using OikosGreenPortal.Pages.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using OikosGreenPortal.Data.Personal;
using Blazorise.DataGrid;

namespace OikosGreenPortal.PersonalClass
{
    public static class General
    {

        public static infoBrowser userLogueado { get; set; }
        public static List<infoMenu> _retMenu { get; set; }
        public static List<infoRoles> _retRol { get; set; }

        /// <summary>
        /// Metodo que muestra una ventana emergente para mostrar mensajes o confirmaciones
        /// </summary>
        /// <param name="_titulo">Es el titulo que se muestra en la ventana</param>
        /// <param name="_mensaje">Es el contenido de la ventana. Si son varias lineas se debe escribir &s para que 
        ///                        realice un saldo de linea.
        /// </param>
        /// <param name="_modal"> Es el servicio ImodalService que se necesita para que la ventana sea emergente</param>
        /// <returns></returns>
        public static async Task MensajeModal(String _titulo, String _mensaje, IModalService _modal)
        {
            var parameters = new ModalParameters();
            parameters.Add(nameof(ModalMensaje.titulo), _titulo);
            parameters.Add(nameof(ModalMensaje.contenido), _mensaje);
            var formModal = _modal.Show<ModalMensaje>("", parameters);
            var result = await formModal.Result;
        }

        public static void estilofila(DataGridRowStyling style)
        {
            style.Background = Blazorise.Background.Light;
            style.Style = "font-size: 13px;";
        }


        public static async Task<HttpResponseMessage> solicitudUrl<T>(String _token, String _metodo, String _url, T _datos)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            try
            {
                using (var solicitud = new HttpClient())
                {
                    if (_token.Trim().Length > 0)
                        solicitud.DefaultRequestHeaders.Add("Authorization", $"Bearer {_token}");
                    solicitud.BaseAddress = new Uri(_url);
                    switch (_metodo)
                    {
                        case "POST":
                            if (_datos == null)
                                response = await solicitud.PostAsync("", null);
                            else
                                response = await solicitud.PostAsJsonAsync("", _datos);
                            break;
                        case "GET":
                            response = await solicitud.GetAsync("");
                            break;
                        case "PATCH":
                            response = await solicitud.PatchAsync("", null);
                            break;
                    }

                }
            }catch(Exception ex)
            {
            }
            return response;
        }


        public static async Task organizaMenu(List<Permission> _menu)
        {
            if(_menu!=null && _menu.Count > 0)
            {
                _retMenu = new List<infoMenu>();
                _retRol = new List<infoRoles>();
                foreach( var reg in _menu.Where(w=>w.option.Trim().Length>0).GroupBy(g=> g.code))
                {
                    infoMenu nuevo = new infoMenu();
                    nuevo.code = reg.Key;
                    nuevo.icono = reg.FirstOrDefault().icono;
                    nuevo.id = reg.FirstOrDefault().id;
                    nuevo.idparent = reg.FirstOrDefault().idparent;
                    nuevo.type = reg.FirstOrDefault().type;
                    nuevo.url = reg.FirstOrDefault().url;
                    nuevo.option = reg.FirstOrDefault().option;
                    nuevo.state = _menu.Any(w => w.code == reg.Key && w.state == 1) ? 1 : 0;
                    nuevo.permission = _menu.Any(w => w.code == reg.Key && w.permission.Substring(0, 1) == "1") ? "1" : "0";
                    nuevo.permission += _menu.Any(w => w.code == reg.Key && w.permission.Substring(1, 1) == "1") ? "1" : "0";
                    nuevo.permission += _menu.Any(w => w.code == reg.Key && w.permission.Substring(2, 1) == "1") ? "1" : "0";
                    nuevo.permission += _menu.Any(w => w.code == reg.Key && w.permission.Substring(3, 1) == "1") ? "1" : "0";                    
                    _retMenu.Add(nuevo);
                }
                foreach (var reg in _menu.GroupBy(g => new { rol = g.rol, user = g.user }))
                {
                    infoRoles nuevo = new infoRoles();
                    nuevo.user = reg.Key.user;
                    nuevo.rol = reg.Key.rol;
                    _retRol.Add(nuevo);
                }
            }
        }


    }
}
