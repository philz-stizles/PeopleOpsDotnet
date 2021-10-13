using PeopleOps.Application.Contracts.Repositories;
using PeopleOps.Domain.Entities;

namespace PeopleOps.Infrastructure.Persistence.Repositories
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        public NotificationRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
