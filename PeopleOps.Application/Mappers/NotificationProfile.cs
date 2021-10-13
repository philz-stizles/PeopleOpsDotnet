using AutoMapper;
using PeopleOps.Application.Models;
using PeopleOps.Domain.Entities;

namespace PeopleOps.Application.Mappers
{
    public class NotificationProfile : Profile
    {
        public NotificationProfile()
        {
            CreateMap<Notification, NotificationVM>().ReverseMap();
        }
    }
}
