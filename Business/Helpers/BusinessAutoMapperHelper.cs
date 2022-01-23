using AutoMapper;
using Business.Services.OutsideService.PaymentService;
using Core.Entities.Concretes;
using Entities.Dtos;

namespace Business.Helpers
{
    public class BusinessAutoMapperHelper : Profile
    {
        public BusinessAutoMapperHelper()
        {
            CreateMap<PayOrderDto, PaymentOrder>();
            CreateMap<Person, PersonDto>();
        }
    }
}
