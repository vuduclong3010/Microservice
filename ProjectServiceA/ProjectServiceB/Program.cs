
using Hangfire;
using Hangfire.Dashboard;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProjectServiceB.Entity;
using ProjectServiceB.Service;

namespace ProjectServiceB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //Hangfire
            builder.Services.AddHangfire(configuration => configuration
                                                            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
                                                            .UseSimpleAssemblyNameTypeSerializer()
                                                            .UseRecommendedSerializerSettings()
                                                            .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnectionHangfire")));
            builder.Services.AddHangfireServer();

            builder.Services.AddDbContext<DatabaseContext>(db => db.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);

            builder.Services.AddTransient<IInsertOrUpdateService, InsertOrUpdateService>();

 
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseHangfireDashboard("/HangFireDashboard", new DashboardOptions
            {
                Authorization = Enumerable.Empty<IDashboardAuthorizationFilter>()
            });
            app.MapHangfireDashboard();

            app.MapControllers();

            app.Run();
        }
    }
}
