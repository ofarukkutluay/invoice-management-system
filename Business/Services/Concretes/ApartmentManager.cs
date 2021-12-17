using AutoMapper;
using Business.Handlers.ViewModels;
using Business.Services.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concretes
{
    
    public class ApartmentManager : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;
        public ApartmentManager(IApartmentRepository apartmentRepository,IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }

        //[Authorize(Roles = "Admin")]
        public IResult Create(CreateApartmentVM createApartment)
        {
            var apartment = _apartmentRepository.Get(x=> x.Name== createApartment.Name);
            if (apartment is not null)
                return new Result("Bu isimde daire mevcut",false);
            apartment = _mapper.Map<Apartment>(createApartment);
            _apartmentRepository.Add(apartment);
            int result = _apartmentRepository.SaveChanges();
            if (result == 0)
                return new Result("Kayıt yapılamadı!",false);
            return new Result("Kayıt Edildi!",true);

        }

        public IResult Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<GetApartmentsVM>> GetAll()
        {
            var apartments = _apartmentRepository.GetList();
            IEnumerable<GetApartmentsVM> vmList = _mapper.Map<IEnumerable<GetApartmentsVM>>(apartments);
            return new DataResult<IEnumerable<GetApartmentsVM>>(vmList,true);
        }

        public IDataResult<GetApartmentVM> GetById(int id)
        {
            var apartment = _apartmentRepository.Get(x=>x.Id == id);
            if (apartment is null)
                return new DataResult<GetApartmentVM>(null,"Bu isimde daire bulunamadı!", false);
            GetApartmentVM vm = _mapper.Map<GetApartmentVM>(apartment);
            return new DataResult<GetApartmentVM>(vm,true);
        }

        public IResult Update(int id, UpdateApartmentVM updateApartment)
        {
            throw new NotImplementedException();
        }
    }
}
