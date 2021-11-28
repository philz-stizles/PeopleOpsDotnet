using AspNetCoreHero.ToastNotification;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeopleOps.Application.Contracts.Repositories;
using PeopleOps.Infrastructure.Persistence;
using PeopleOps.Infrastructure.Persistence.Repositories;
using StackExchange.Redis;

namespace PeopleOps.UI.ServiceConfigurations
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(
                     configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<IConnectionMultiplexer>(c => {
                var config = ConfigurationOptions.Parse(configuration.GetConnectionString("Redis"), true);
                return ConnectionMultiplexer.Connect(config);
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            services.AddScoped<ILeaveHistoryRepository, LeaveHistoryRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<IAuditRepository, AuditRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            // services.Configure<EmailSettings>(c => configuration.GetSection("EmailSettings"));
            // services.AddTransient<IEmailService, EmailService>();
            services.AddNotyf(config => { config.DurationInSeconds = 10; config.IsDismissable = true; config.Position = NotyfPosition.BottomRight; });

            return services;
        }
    }
}
