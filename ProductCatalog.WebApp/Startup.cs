using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProductCatalog.WebApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();

            services.AddHttpClient("ProductCatalogApi", config =>
            {
                config.BaseAddress = new Uri(Configuration["ServiceHosts:ProductCatalogApiHost"]);
                config.Timeout = new TimeSpan(0, 0, 60);
                config.DefaultRequestHeaders.Authorization = new("Bearer", new HttpContextAccessor().HttpContext.Request.Cookies["token"].ToString());
            });

            services.AddHttpClient("Auth", config =>
            {
                config.BaseAddress = new Uri(Configuration["ServiceHosts:ProductCatalogApiHost"]);
                config.Timeout = new TimeSpan(0, 0, 60);
                config.DefaultRequestHeaders.Clear();
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Account/Login");
                    options.AccessDeniedPath = new PathString("/Account/Login");
                });

            services.AddMvc()
                .AddJsonOptions(x =>
                {
                    x.JsonSerializerOptions.PropertyNameCaseInsensitive = false;
                    x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Account}/{action=Login}/{id?}");
            });
        }
    }
}
