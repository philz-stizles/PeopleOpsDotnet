using PeopleOps.Application.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleOps.Application.Contracts.Services
{
    public interface INotificationService
    {
        Task<IReadOnlyList<NotificationVM>> GetAllAsync();

        Task<NotificationVM> AddAsync(NotificationCreateVM vm);
    }
}
