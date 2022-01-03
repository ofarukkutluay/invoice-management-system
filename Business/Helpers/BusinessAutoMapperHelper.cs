using AutoMapper;
using Business.Handlers.ViewModels;
using Core.Entities.Concretes;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public class BusinessAutoMapperHelper : Profile
    {
        public BusinessAutoMapperHelper()
        {
            CreateMap<Person,GetPersonsVM>();
            CreateMap<RegisterPersonVM,Person>();
            CreateMap<CreateApartmentVM,Apartment>();
            CreateMap<Apartment,GetApartmentsVM>();
            CreateMap<Apartment, GetApartmentVM>();
            
        }
    }
}
