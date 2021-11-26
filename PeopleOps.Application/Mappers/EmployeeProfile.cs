using AutoMapper;
using PeopleOps.Application.Models;
using PeopleOps.Domain.Entities;

namespace PeopleOps.Application.Mappers
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeVM>().ReverseMap();
            CreateMap<EmployeeModel, Employee>();
            CreateMap<EmployeeModel, EmployeeVM>();
        }
    }
}
