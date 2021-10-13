using AutoMapper;
using PeopleOps.Application.Contracts.Repositories;
using PeopleOps.Application.Contracts.Services;
using PeopleOps.Application.Models;
using PeopleOps.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PeopleOps.Infrastructure.Persistence.Repositories
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly IMapper _mapper;
        public NotificationService(INotificationRepository notificationRepository, IMapper mapper)
        {
            _notificationRepository = notificationRepository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<NotificationVM>> GetAllAsync()
        {
            var notifications = await _notificationRepository.GetAllAsync();
            return _mapper.Map<IReadOnlyList<NotificationVM>>(notifications);
        }

        public async Task<NotificationVM> AddAsync(NotificationCreateVM vm)
        {
            var newNotification = _mapper.Map<Notification>(vm);
            var notification = await _notificationRepository.AddAsync(newNotification);
            return _mapper.Map<NotificationVM>(notification);
        }
    }
}
