using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazorise;
using Blazorise.Material;
using Blazorise.Icons.Material;
using Blazored.Modal;
using Microsoft.AspNetCore.Components.Authorization;
using OikosGreenPortal.Helpers;
using System.Net.Http;
using Blazored.LocalStorage;

namespace OikosGreenPortal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            #region Blazorise
            services
              .AddBlazorise(options =>
              {
                  options.ChangeTextOnKeyPress = true; // optional
              })
              .AddMaterialProviders()
              .AddMaterialIcons();
            #endregion
            services.AddRazorPages();
            services.AddServerSideBlazor();
            #region BlazorModal
            services.AddBlazoredModal();
            #endregion
            #region Autenticacion Personalizada
            services.AddScoped<AuthenticationStateProvider, CustomAuthentication>();
            #endregion
            #region HttpClient
            services.AddScoped<HttpClient>();
            #endregion
            #region LocalStorage
            services.AddBlazoredLocalStorage();
            services.AddBlazoredLocalStorage(Config => Config.JsonSerializerOptions.WriteIndented = true);
            #endregion

        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            #region Blazorise
            app.ApplicationServices
              .UseMaterialProviders()
              .UseMaterialIcons();
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
