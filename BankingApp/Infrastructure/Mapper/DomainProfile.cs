using AutoMapper;
using BankingApp.Domain;
using BankingApp.Dto;

namespace BankingApp.Infrastructure.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(destination => destination.RegistrationDate, opt =>
                    opt.MapFrom(destination => destination.Created.ToShortDateString()));
        }
    }
}