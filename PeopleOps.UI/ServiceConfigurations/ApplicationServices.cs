using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PeopleOps.Application.Contracts.Services;
using PeopleOps.Application.Mappers;
using PeopleOps.Infrastructure.Persistence.Repositories;
using PeopleOps.Infrastructure.Services.Security;

namespace PeopleOps.UI.ServiceConfigurations
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddApplicationServices(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddAutoMapper(typeof(LeaveProfile));

            services.AddScoped<ICashAdvanceService, CashAdvanceService>();
            services.AddScoped<IUserAccessor, UserAccessor>();
            services.AddScoped<ILeaveTypeService, LeaveTypeService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<INotificationService, NotificationService>();
           /* services.AddScoped<IAuditRepository, AuditRepository>();*/

            return services;
        }
    }
}
