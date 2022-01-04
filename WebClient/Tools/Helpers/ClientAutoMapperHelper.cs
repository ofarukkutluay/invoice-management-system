using AutoMapper;
using Business.Helpers;
using Entities.Concretes;
using WebClient.Models.Apartment;

namespace WebClient.Helpers.Mapper
{
    public class ClientAutoMapperHelper : Profile
    {
        public ClientAutoMapperHelper()
        {   
            CreateMap<Apartment,GetApartmentsViewModel>();
            CreateMap<Apartment,GetApartmentViewModel>();
            CreateMap<Apartment,UpdateApartmentViewModel>();
            CreateMap<CreateApartmentViewModel,Apartment>();
            CreateMap<UpdateApartmentViewModel,Apartment>();
        }
    }
}
