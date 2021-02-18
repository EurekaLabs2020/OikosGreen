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
using OikosGreenPortal.Data.Personal;

namespace OikosGreenPortal.Helpers
{
    public class CustomAuthentication : AuthenticationStateProvider
    {
        private NavigationManager _navegacion { get; set; }
        private ILocalStorageService sesion;
        private ProtectedSessionStorage _storage { get; set; }



        public CustomAuthentication(ILocalStorageService _sesion, ProtectedSessionStorage storage, NavigationManager navegacion)
        {
            sesion = _sesion;
            _storage = storage;
            _navegacion = navegacion;
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
                var datosUsuario = await _storage.GetAsync<infoBrowser>("data");
                General.userLogueado = datosUsuario.Value;

                if (General.userLogueado != null && General.userLogueado.user.expiration < DateTime.Now)
                    MarkUserAsLoggedOut();
                else
                {
                    if (General.userLogueado != null)
                    {
                        identity = setClaims(General.userLogueado);
                    }
                }
                user = new ClaimsPrincipal(identity);
            }catch (Exception ex) { }
            return await Task.FromResult(new AuthenticationState(user));
        }

        public void MarKUserAsAuthenticated(infoBrowser _data)
        {
            var identity = setClaims(_data); 
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

        public void MarkUserAsLoggedOut()
        {
            _storage.DeleteAsync("data");
            var identity = new ClaimsIdentity();
            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
            _navegacion.NavigateTo("/", true);
        }

        private ClaimsIdentity setClaims(infoBrowser _data)
        {
            ClaimsIdentity identity = new ClaimsIdentity();
            if (_data != null)
            {
                identity = new ClaimsIdentity(new[] {
                            new Claim(ClaimTypes.Name, _data.user.nombrefull),
                            new Claim(ClaimTypes.SerialNumber, _data.user.user.ToString()),
                            new Claim(ClaimTypes.Email, _data.user.email),
                            new Claim(ClaimTypes.MobilePhone, _data.user.phone),
                            new Claim(ClaimTypes.NameIdentifier, _data.user.iduser),
                            new Claim(ClaimTypes.SerialNumber, _data.user.typedoc+"-"+_data.user.numdoc)
                    }, "apiauth_type");
                foreach(var reg in _data.roles)
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role, reg.rol));
                }
            }
            return identity;
        }


    }
}
