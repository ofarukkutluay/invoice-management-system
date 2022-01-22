using AutoMapper;
using CreditCardServiceApi.Applications.Company.Commands;
using CreditCardServiceApi.Applications.Company.Queries;
using CreditCardServiceApi.Applications.Pay.Commands;
using CreditCardServiceApi.Applications.Pay.Queries;
using CreditCardServiceApi.Entities;

namespace CreditCardServiceApi.Common.Utility.Mapper
{
    public class AutomapperMappingProfile : Profile
    {
        public AutomapperMappingProfile()
        {
            CreateMap<CreateCompanyViewModel, Company>();
            CreateMap<Company, GetCompaniesViewModel>();
            
            CreateMap<CreatePayViewModel, CreditCard>();
            CreateMap<CreatePayViewModel, Pay>();
            
            CreateMap<Pay, GetPaysViewModel>();
            CreateMap<CreditCard,GetPaysViewModel.CreateCreditCardVM>();

        }
    }
}
