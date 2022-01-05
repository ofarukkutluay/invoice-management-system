using AutoMapper;
using Business.Services.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;

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
        public IResult Create(Apartment createApartment)
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
            var apartment = _apartmentRepository.Get(x=> x.Id==id);
            if (apartment is null)
                return new Result("Daire bulunamadı!",false);
            _apartmentRepository.Delete(apartment);
            int result = _apartmentRepository.SaveChanges();
            if (result == 0)
                return new Result("DB ye kaydederken bir hata oluştu!", false);
            return new Result(true);
        }

        public IDataResult<IEnumerable<Apartment>> GetAll()
        {
            var apartments = _apartmentRepository.GetList();
            return new DataResult<IEnumerable<Apartment>>(apartments,true);
        }

        public IDataResult<Apartment> GetById(int id)
        {
            var apartment = _apartmentRepository.Get(x=>x.Id == id);
            if (apartment is null)
                return new DataResult<Apartment>(null,"Bu isimde daire bulunamadı!", false);
            return new DataResult<Apartment>(apartment,true);
        }

        public IResult Update(int id, Apartment updateApartment)
        {
            var apartment = _apartmentRepository.Get(x=> x.Id==id);
            if (apartment is null)
                return new Result("Bu isimde daire bulunamadı!", false);
            apartment.Name = updateApartment.Name == default ? apartment.Name : updateApartment.Name;
            apartment.TotalFloors = updateApartment.TotalFloors == default ? apartment.TotalFloors : updateApartment.TotalFloors;
            
            int result = _apartmentRepository.SaveChanges();
            if (result == 0)
                return new Result("DB ye kaydederken bir hata oluştu!", false);
            return new Result(true);
        }
    }
}
