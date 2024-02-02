using AutoMapper;
using Hangfire;
using Hangfire.Dashboard;
using Microsoft.EntityFrameworkCore;
using ProjectServiceB.Entity;
using ProjectServiceB.Mapper;
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

            builder.Services.AddTransient<IHandleDatabaseService, HandleDatabaseService>();

            var mapperConfig = new MapperConfiguration(
                                    mc => { mc.AddProfile(new MapperConfig()); }
                                );

            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

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

            RecurringJob.AddOrUpdate<IHandleDatabaseService>("InsertOrUpdateDatabase", x => x.HandleDatabaseTable("http://localhost:5095/api/Homes/GetDatabase"), Cron.Minutely);

            app.MapControllers();

            app.Run();
        }
    }
}
