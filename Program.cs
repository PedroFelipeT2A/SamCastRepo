using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Painel.Data;
using System.Globalization;

namespace Painel
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var path = "sti.key";
            //Stimulsoft.Base.StiLicense.LoadFromFile(path);

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<ctxContext>(options =>
                options.UseMySQL(builder.Configuration.GetConnectionString("ctxContext") ?? throw new InvalidOperationException("Connection string 'ctxContext' not found.")));

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.Limits.MaxConcurrentConnections = 100;
                serverOptions.Limits.MaxConcurrentUpgradedConnections = 100;
                serverOptions.Limits.MaxRequestBodySize = 10 * 1024 * 1024;
                serverOptions.Limits.MinRequestBodyDataRate = new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
                serverOptions.Limits.MinResponseDataRate = new MinDataRate(bytesPerSecond: 100, gracePeriod: TimeSpan.FromSeconds(10));
                serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(200);
                serverOptions.Limits.RequestHeadersTimeout = TimeSpan.FromMinutes(100);
            })
            .UseKestrel()
            //.UseWebRoot("wwwroot")
            .UseUrls("http://*:2600");
            builder.Services.AddSession();

            builder.Services.AddControllersWithViews();

            builder.Services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.Name = ".auth.Session"; // <--- Add line
                options.Cookie.IsEssential = true;
            });

            builder.Services.AddAuthentication("auth").AddCookie("auth", config => {
                config.Cookie.Name = "AppUserLoginCookie";
                config.LoginPath = "/Revendas/Login";
                config.LogoutPath = "/Revendas/Login";
            });

            builder.Services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[] { "pt-BR" };
                options.SetDefaultCulture(supportedCultures[0])
                    .AddSupportedCultures(supportedCultures)
                    .AddSupportedUICultures(supportedCultures);
            });

            builder.Services.AddCors(options => {
                options.AddDefaultPolicy(builder => builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
            });

            //builder.Services.AddProgressiveWebApp();

            var app = builder.Build();

            var defaultDateCulture = "pt-BR";
            var ci = new CultureInfo(defaultDateCulture);
            ci.NumberFormat.NumberDecimalSeparator = ".";
            ci.NumberFormat.CurrencyDecimalSeparator = ".";

            var supportedCultures = new[] { new CultureInfo("pt-BR") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });

            app.UseCors(option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                //app.UseHsts();
            }
            //app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseAuthentication();

            app.UseSession();

            app.UseAuthentication();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
