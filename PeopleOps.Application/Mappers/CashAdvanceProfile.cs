using AutoMapper;
using PeopleOps.Application.Models;
using PeopleOps.Domain.Entities;

namespace PeopleOps.Application.Mappers
{
    public class CashAdvanceProfile : Profile
    {
        public CashAdvanceProfile()
        {
            CreateMap<CashAdvance, CashAdvanceVM>().ReverseMap();
            CreateMap<CashAdvanceCreateVM, CashAdvance>();
        }
    }
}
