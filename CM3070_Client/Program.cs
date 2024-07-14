
using System.Data.Common;
using System.IdentityModel.Tokens.Jwt;
using CM3070.DbContextCore;
using CM3070.DbRepositoryCore;
using IdentityModel;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;


namespace CM3070_Client
{
    public class Program
    {
        public static void Main ( string [] args )
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

                     
            
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddHttpClient();
            JwtSecurityTokenHandler.DefaultMapInboundClaims = false;

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                //options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                //JwtBearerDefaults.AuthenticationScheme;
                //options.DefaultChallengeScheme = "oidc";
            }).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
            {
                options.AccessDeniedPath = "/Authorization/AccessDenied";
            }).AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, options =>
            {
                options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.SignOutScheme = OpenIdConnectDefaults.AuthenticationScheme;
                options.Authority = builder.Configuration ["App:IDPUri"];   //IDP
                options.ClientId = builder.Configuration ["App:ClientId"];
                options.RequireHttpsMetadata = false;
                options.ResponseType = OpenIdConnectResponseType.Code;
                options.AuthenticationMethod = OpenIdConnectRedirectBehavior.RedirectGet;
                options.Scope.Add("openid");   //these are in defualt no needed here
                options.Scope.Add("profile");
                options.Scope.Add("email");  //adding to scope and deleting from claim down below
                options.Scope.Add("role");                
                options.UsePkce = true;
               
                options.SaveTokens = true;
                options.ClientSecret = builder.Configuration ["App:ClientSecret"];
                options.GetClaimsFromUserInfoEndpoint = true;
            });

            var dbConnection = builder.Configuration.GetConnectionString("CM3070DbConnection");

            builder.Services.AddDbContext<CM3070DbContext>(options => options.UseSqlServer(dbConnection));
            builder.Services.AddTransient<IRepositoryCore, RepositoryCore>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            //app.MapDefaultControllerRoute();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapDefaultControllerRoute()
            //    .RequireAuthorization().RequireAuthorization();
            //});

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}
