using AutoMapper;
using BankingApp.Domain;
using BankingApp.Dto;
using System.Collections.Generic;

namespace BankingApp.Infrastructure.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Account, AccountDto>();

            CreateMap<Customer, CustomerDto>()
                .ForMember(destination => destination.RegistrationDate, opt =>
                    opt.MapFrom(destination =>  destination.Created))
                .ForMember(destination => destination.Account, opt =>
                    opt.MapFrom(source => source.Account ?? new List<Account>()));

            CreateMap<Transaction, TransactionDto>().ReverseMap();
        }
    }
}