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
            CreateMap<LeaveType, LeaveTypeModel>().ReverseMap();
            CreateMap<LeaveTypeModel, LeaveType>();
            CreateMap<LeaveRequest, LeaveRequestVM>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestModel>().ReverseMap();
            CreateMap<LeaveRequestModel, LeaveRequest>();
        }
    }
}
