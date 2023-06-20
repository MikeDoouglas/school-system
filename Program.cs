
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MySql.EntityFrameworkCore.Extensions;
using SchoolSystem.Data;
using SchoolSystem.Repositories;
using SchoolSystem.Repositories.Interfaces;

namespace SchoolSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<SchoolSystemDbContext>(options => options.UseMySQL(builder.Configuration.GetConnectionString("Default")));
            builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
            builder.Services.AddScoped<ISchoolRepository, SchoolRepository>();

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
    => Host.CreateDefaultBuilder(args)
        .ConfigureWebHostDefaults(
            webBuilder => webBuilder.UseStartup<Startup>());

        public class MysqlEntityFrameworkDesignTimeServices : IDesignTimeServices
        {
            public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
            {
                serviceCollection.AddEntityFrameworkMySQL();
                new EntityFrameworkRelationalDesignServicesBuilder(serviceCollection)
                    .TryAddCoreServices();
            }
        }

        public class Startup
        {
            public void ConfigureServices(IServiceCollection services)
                => services.AddDbContext<SchoolSystemDbContext>();

            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            {
            }
        }
    }
}
