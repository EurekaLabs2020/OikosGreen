using Blazorise;
using Blazorise.Material;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Blazorise.Icons.Material;

namespace OikosGreenWeb
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            builder.Services.AddBlazorise(options => {
                options.ChangeTextOnKeyPress = true;
            }).AddMaterialProviders().AddMaterialIcons();

            var host = builder.Build();

            host.Services
              .UseMaterialProviders().UseMaterialIcons();

            await builder.Build().RunAsync();
        }
    }
}
