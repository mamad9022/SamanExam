using AutoMapper;
using Saman.Test.Backend.Application.Command;
using Saman.Test.Backend.Application.Responses;
using Saman.Test.Backend.Common.Dto;
using Saman.Test.Backend.Common.Request;
using Saman.Test.Backend.Domain.Models;

namespace Saman.Test.Backend.Application.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CardTransationCommand, CardTransactionRequest>();
            CreateMap<BankTransactionDto, CardTransactionResponse > ();
            CreateMap<Transaction, TransactionResponse>()
               .ForMember(x => x.Date, opt => opt.MapFrom(des => des.CreatedAt));
        }
    }
}
