using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using NexPay.Api.ViewModels;
using NexPay.Domain.Entities;

namespace NexPay.Api.Mapping
{
    public class MappingProfile : MapperConfigurationExpression
    {
        public MappingProfile()
        {
            CreateMap<User, UserVM>().ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore());

            CreateMap<Transaction, TransactionVM>().ReverseMap()
                .ForMember(src => src.Id, opt => opt.Ignore());

        }
    }
}