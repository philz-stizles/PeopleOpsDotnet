using PeopleOps.Application.Contracts.Repositories;
using PeopleOps.Domain.Entities;

namespace PeopleOps.Infrastructure.Persistence.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
