using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OikosGreenPortal.Pages.Auth.login
{
    public class LoginBase: ComponentBase
    {
        private Task<AuthenticationState> authenticationStateTask { get; set; }

        private string _authMessage;

        private async Task LogUsername()
        {
            var authState = await authenticationStateTask;
            var user = authState.User;

            if (user.Identity.IsAuthenticated)
            {
                _authMessage = $"{user.Identity.Name} is authenticated.";
            }
            else
            {
                _authMessage = "The user is NOT authenticated.";
            }
        }
    }
}
