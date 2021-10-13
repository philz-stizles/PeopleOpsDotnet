using AutoMapper;
using PeopleOps.Application.Models;
using PeopleOps.Domain.Entities;

namespace PeopleOps.Application.Mappers
{
    public class LeaveProfile: Profile
    {
        public LeaveProfile()
        {
            CreateMap<LeaveType, LeaveTypeVM>().ReverseMap();
        }
    }
}
