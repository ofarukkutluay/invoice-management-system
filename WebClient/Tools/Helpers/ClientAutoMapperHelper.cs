using AutoMapper;
using Business.Helpers;
using Core.Entities.Concretes;
using Entities.Concretes;
using Entities.Dtos;
using WebClient.Models.Apartment;
using WebClient.Models.Auth;
using WebClient.Models.FlatType;
using WebClient.Models.House;
using WebClient.Models.Invoice;
using WebClient.Models.InvoiceType;
using WebClient.Models.Owner;
using WebClient.Models.Payment;
using WebClient.Models.Person;
using WebClient.Models.Resident;
using WebClient.Models.UserPanel;

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

            CreateMap<HouseDto, GetHousesDetailViewModel>();
            CreateMap<CreateHouseViewModel, House>();
            CreateMap<House, UpdateHouseViewModel>();
            CreateMap<UpdateHouseViewModel, House>();

            CreateMap<InvoiceType, GetInvoiceTypesViewModel>();
            CreateMap<InvoiceType, UpdateInvoiceTypeViewModel>();
            CreateMap<CreateInvoiceTypeViewModel, InvoiceType>();
            CreateMap<UpdateInvoiceTypeViewModel, InvoiceType>();

            CreateMap<OwnerDto, GetOwnersViewModel>();
            CreateMap<Owner, UpdateOwnerViewModel>();
            CreateMap<CreateOwnerViewModel, Owner>();
            CreateMap<UpdateOwnerViewModel, Owner>();

            CreateMap<ResidentDto, GetResidentsViewModel>();
            CreateMap<Resident, UpdateResidentViewModel>();
            CreateMap<CreateResidentViewModel, Resident>();
            CreateMap<UpdateResidentViewModel, Resident>();

            CreateMap<LoginPersonViewModel, LoginPersonDto>();
            CreateMap<RegisterPersonViewModel, RegisterPersonDto>();

            CreateMap<Invoice, GetInvoiceViewModel>();
            CreateMap<InvoiceDto, GetInvoicesViewModel>();
            CreateMap<Invoice, UpdateInvoiceViewModel>();
            CreateMap<CreateInvoiceViewModel, Invoice>();
            CreateMap<UpdateInvoiceViewModel, Invoice>();

            CreateMap<CreatePayOrderViewModel, PayOrderDto>();

            CreateMap<PersonDto, GetPersonViewModel>();
            CreateMap<PersonDto, UpdatePersonViewModel>();
            CreateMap<UpdatePersonViewModel, Person>();

            CreateMap<InvoiceDto, GetUserInvoicesViewModel>();
        }
    }
}
