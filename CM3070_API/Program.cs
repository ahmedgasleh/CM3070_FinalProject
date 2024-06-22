
using CM3070.DbContextCore;
using CM3070.DbRepositoryCore;
using Microsoft.EntityFrameworkCore;

namespace CM3070_API
{
    public class Program
    {
        public static void Main ( string [] args )
        {
            var builder = WebApplication.CreateBuilder(args);

            //configuration
            var configuration = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            // Add services to the container.

            var dbConnection = builder.Configuration.GetConnectionString("CM3070DbConnection");

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddDbContext<CM3070DbContext>(options => options.UseSqlServer(dbConnection));

            builder.Services.AddTransient<IRepositoryCore, RepositoryCore>();

            builder.Services.AddCors(config =>
                config.AddPolicy("AllowAll", p =>
                p.WithOrigins(configuration ["API:ClientUrl"].ToString()).AllowAnyMethod().AllowAnyHeader()));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("AllowAll");

            //app.UseAuthentication();
            //app.UseAuthorization();



            app.MapControllers();

           

            app.Run();
        }
    }
}
