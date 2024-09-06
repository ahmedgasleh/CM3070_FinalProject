using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CM3070_Client_IDP;
using CM3070_Client_IDP.Data;

var seed = args.Contains("/seed");
if (seed)
{
    args = args.Except(new[] { "/seed" }).ToArray();
}

var builder = WebApplication.CreateBuilder(args);

var assembly = typeof(Program).Assembly.GetName().Name;
var defaultConnString = builder.Configuration.GetConnectionString("CM3070DbIDPConnection");

//if (seed)
//{
//    SeedData.EnsureSeedData(defaultConnString);
//}

//builder.Services.AddDbContext<AspNetIdentityDbContext>(options =>
//    options.UseSqlServer(defaultConnString,
//        b => b.MigrationsAssembly(assembly)));

builder.Services.AddDbContext<AspNetIdentityDbContext>(options =>
    options.UseMySql(defaultConnString, ServerVersion.AutoDetect(defaultConnString),
        b => b.MigrationsAssembly(assembly)));

builder.Services.AddIdentity<IdentityUser, IdentityRole>( opt =>
{
    opt.Password.RequiredLength = 8;
    opt.Password.RequireDigit = true;   
    opt.Password.RequireUppercase = true;

})
 .AddEntityFrameworkStores<AspNetIdentityDbContext>();

builder.Services.AddIdentityServer()
    .AddAspNetIdentity<IdentityUser>()
    .AddConfigurationStore(options =>
    {
        options.ConfigureDbContext = b =>
        b.UseSqlServer(defaultConnString, opt => opt.MigrationsAssembly(assembly));
    })
    .AddOperationalStore(options =>
    {
        options.ConfigureDbContext = b =>
        b.UseSqlServer(defaultConnString, opt => opt.MigrationsAssembly(assembly));
    })
    .AddDeveloperSigningCredential();

builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseIdentityServer();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
	endpoints.MapDefaultControllerRoute();
});

app.Run();
