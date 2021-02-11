using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OikosGreenPortal.Helpers
{
    public class CustomAuthentication : AuthenticationStateProvider
    {
        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, "prueba"),
        }, "Fake authentication type");

            //var user = new ClaimsPrincipal(identity);
            var user = new ClaimsPrincipal();
            return Task.FromResult(new AuthenticationState(user));
        }
    }
}
