using AutoMapper;
using Business.Services.OutsideService.PaymentService;
using Entities.Dtos;

namespace Business.Helpers
{
    public class BusinessAutoMapperHelper : Profile
    {
        public BusinessAutoMapperHelper()
        {
            CreateMap<PayOrderDto, PaymentOrder>();

        }
    }
}
