using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using OikosGreenPortal.PersonalClass;
using OikosGreenPortal.Data.Request;

namespace OikosGreenPortal.Helpers
{
    public class CustomAuthentication : AuthenticationStateProvider
    {
        private ILocalStorageService sesion;
        private ProtectedSessionStorage _storage { get; set; }


        public CustomAuthentication(ILocalStorageService _sesion, ProtectedSessionStorage storage)
        {
            sesion = _sesion;
            _storage = storage;
        }

        public CustomAuthentication()
        {
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            ClaimsIdentity identity = new ClaimsIdentity();
            ClaimsPrincipal user = new ClaimsPrincipal();
            try
            {
                var datosUsuario = await _storage.GetAsync<LoginRequest>("data");
                General.userLogueado = datosUsuario.Value;

                if (General.userLogueado != null && General.userLogueado.expiration < DateTime.Now)
                    MarkUserAsLoggedOut();
                else
                {
                    if (General.userLogueado != null)
                    {
                        identity = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name, General.userLogueado.nombrefull),
                        new Claim(ClaimTypes.SerialNumber, General.userLogueado.user),
                        new Claim(ClaimTypes.Email, General.userLogueado.email),
                        new Claim(ClaimTypes.MobilePhone, General.userLogueado.phone),
                        new Claim(ClaimTypes.NameIdentifier, General.userLogueado.iduser),
                        new Claim(ClaimTypes.SerialNumber, General.userLogueado.typedoc+"-"+General.userLogueado.numdoc)
                    }, "apiauth_type");
                    }
                }
                user = new ClaimsPrincipal(identity);
            }catch (Exception ex) { }
            return await Task.FromResult(new AuthenticationState(user));
        }

        public void MarKUserAsAuthenticated(String _user)
        {
            var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, _user), }, "apiauth_type");
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }


        public void MarKUserAsAuthenticated(LoginRequest _user)
        {
            var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, _user.nombrefull),
                    new Claim(ClaimTypes.SerialNumber, _user.user.ToString()),
                    new Claim(ClaimTypes.Email, _user.email),
                    new Claim(ClaimTypes.MobilePhone, _user.phone),
                    new Claim(ClaimTypes.NameIdentifier, _user.iduser),
                    new Claim(ClaimTypes.SerialNumber, _user.typedoc+"-"+_user.numdoc)
            }, "apiauth_type");
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void MarkUserAsLoggedOut()
        {
            _storage.DeleteAsync("data");
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }


    }
}
