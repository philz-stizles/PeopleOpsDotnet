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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NotificationService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<NotificationVM>> GetAllAsync()
        {
            var notifications = await _unitOfWork.Notifications.FindAllAsync();
            return _mapper.Map<IReadOnlyList<NotificationVM>>(notifications);
        }

        public async Task<NotificationVM> AddAsync(NotificationCreateVM vm)
        {
            var newNotification = _mapper.Map<Notification>(vm);
            await _unitOfWork.Notifications.CreateAsync(newNotification);
            await _unitOfWork.SaveAsync();
            return _mapper.Map<NotificationVM>(vm);
        }
    }
}
