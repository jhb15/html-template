using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;
using LayoutService.Models;
using LayoutService.Repositories;
using System.Net;
using Microsoft.AspNetCore.HttpOverrides;

namespace LayoutService
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IConfigurationSection appConfig;
        private readonly IHostingEnvironment environment;

        public Startup(IConfiguration config, IHostingEnvironment env)
        {
            Configuration = config;
            appConfig = Configuration.GetSection("LayoutService");
            environment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IAppLinkRepository, AppLinkRepository>();
            services.AddScoped<IAppSubLinkRepository, AppSubLinkRepository>();

            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false; // We only use essential cookies
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            })
            .AddCookie("Cookies")
            .AddOpenIdConnect("oidc", options =>
            {
                options.SignInScheme = "Cookies";
                options.Authority = appConfig.GetValue<string>("GatekeeperUrl");
                options.ClientId = appConfig.GetValue<string>("ClientId");
                options.ClientSecret = appConfig.GetValue<string>("ClientSecret");
                options.ResponseType = "code id_token";
                options.SaveTokens = true;
                options.GetClaimsFromUserInfoEndpoint = true;
                options.Scope.Add("profile");
                options.Scope.Add("offline_access");
                options.ClaimActions.MapJsonKey("locale", "locale");
                options.ClaimActions.MapJsonKey("user_type", "user_type");
            });

            services.AddDbContext<LayoutServiceContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("LayoutServiceContext")));

            services.AddAuthorization(options =>
            {
                options.AddPolicy("Administrator", pb => pb.RequireClaim("user_type", "administrator"));
            });

            if (!environment.IsDevelopment())
            {
                services.Configure<ForwardedHeadersOptions>(options =>
                {
                    var proxyHost = appConfig.GetValue<string>("ReverseProxyHostname", "http://nginx");
                    var proxyAddresses = Dns.GetHostAddresses(proxyHost);
                    foreach (var ip in proxyAddresses)
                    {
                        options.KnownProxies.Add(ip);
                    }
                });
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                var pathBase = appConfig.GetValue<string>("PathBase", "/layout-service");
                RunMigrations(app);
                app.UsePathBase(pathBase);
                app.Use((context, next) =>
                {
                    context.Request.PathBase = new PathString(pathBase);
                    return next();
                });
                app.UseForwardedHeaders(new ForwardedHeadersOptions
                {
                    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
                });
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=AppLinksManagement}/{action=Index}/{id?}");
            });
        }

        private void RunMigrations(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var serviceProvider = serviceScope.ServiceProvider;
                var dbContext = serviceProvider.GetService<LayoutServiceContext>();
                dbContext.Database.Migrate();
            }
        }
    }
}
