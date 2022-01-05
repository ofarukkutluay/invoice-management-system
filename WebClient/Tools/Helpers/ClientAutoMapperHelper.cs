using AutoMapper;
using Business.Helpers;
using Entities.Concretes;
using WebClient.Models.Apartment;
using WebClient.Models.FlatType;

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

            CreateMap<FlatType,GetFlatTypesViewModel>();
            CreateMap<FlatType,UpdateFlatTypeViewModel>();
            CreateMap<CreateFlatTypeViewModel,FlatType>();
            CreateMap<UpdateFlatTypeViewModel,FlatType>();
        }
    }
}
