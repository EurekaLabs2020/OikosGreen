using Blazored.Modal;
using Blazored.Modal.Services;
using OikosGreenPortal.Data.Request;
using OikosGreenPortal.Pages.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.PersonalClass
{
    public static class General
    {

        public static LoginRequest userLogueado { get; set; }


        public static async Task MensajeModal(String _titulo, String _mensaje, IModalService _modal)
        {
            var parameters = new ModalParameters();
            parameters.Add(nameof(ModalMensaje.titulo), _titulo);
            parameters.Add(nameof(ModalMensaje.contenido), _mensaje);
            var formModal = _modal.Show<ModalMensaje>("", parameters);
            var result = await formModal.Result;
        }




    }
}
