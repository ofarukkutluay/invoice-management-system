using AutoMapper;
using Business.Handlers.ViewModels;
using Business.Helpers;
using WebClient.Models;

namespace WebClient.Helpers.Mapper
{
    public class ClientAutoMapperHelper : Profile
    {
        public ClientAutoMapperHelper()
        {   
            CreateMap<GetApartmentsVM,GetApartmentsViewModel>();
            CreateMap<GetApartmentVM, GetApartmentViewModel>();
            CreateMap<CreateApartmentViewModel,CreateApartmentVM>();
        }
    }
}
