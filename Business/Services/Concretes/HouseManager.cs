using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Dtos;

namespace Business.Services.Concretes
{
    public class HouseManager : IHouseService
    {
        private readonly IHouseRepository _houseRepository;
        private readonly IMapper _mapper;
        public HouseManager(IHouseRepository houseRepository,IMapper mapper)
        {
            _houseRepository = houseRepository;
            _mapper = mapper;
        }
        public IResult Create(House entity)
        {
            var house = _houseRepository.Get(x =>
                x.ApartmentId == entity.ApartmentId && x.DoorNumber == entity.DoorNumber && x.FloorLocation == entity.FloorLocation );
            if (house is not null)
                return new Result("Bu ev mevcut!", false);

            var apartment = _houseRepository.GetApartment(entity.ApartmentId);
            if (apartment.TotalFloors < entity.FloorLocation)
                return new Result("Seçtiğiniz apartmanın toplam kat sayısının üstünde kat numarası girdiniz!", false);

            _houseRepository.Add(entity);

            var result = _houseRepository.SaveChanges();
            if (result==0) 
                return new Result("Db ye kayıt ederken hata oluştu!", false);
            return new Result("Kayıt edildi.", true);
        }

        public IResult Delete(int id)
        {
            var house = _houseRepository.Get(x => x.Id == id);
            if (house is null)
                return new Result("Ev bulunamadı!", false);
            _houseRepository.Delete(house);
            var result = _houseRepository.SaveChanges();
            if (result == 0)
                return new Result("Db ye kayıt ederken hata oluştu!", false);
            return new Result("Data silindi", true);
        }

        public IResult Update(int id, House entity)
        {
            var house = _houseRepository.Get(x => x.Id == id);
            if (house is null)
                return new Result("Ev bulunamadı!", false);
            house.ApartmentId = entity.ApartmentId == default ? house.ApartmentId : entity.ApartmentId;
            house.DoorNumber = entity.DoorNumber == default ? house.DoorNumber : entity.DoorNumber;
            house.FloorLocation = entity.FloorLocation == default ? house.FloorLocation : entity.FloorLocation;
            house.FlatTypeId = entity.FlatTypeId == default ? house.FlatTypeId : entity.FlatTypeId;

            var apartment = _houseRepository.GetApartment(entity.ApartmentId);
            if (apartment.TotalFloors < entity.FloorLocation)
                return new Result("Seçtiğiniz apartmanın kat sayısının üstünde kat numarası girdiniz!", false);

            var result = _houseRepository.SaveChanges();
            if (result == 0)
                return new Result("Db ye kayıt ederken hata oluştu!", false);
            return new Result("Güncelleme yapıldı.", true);

        }

        public IDataResult<House> GetById(int id)
        {
            var house = _houseRepository.Get(x => x.Id == id);
            if (house is null)
                return new DataResult<House>(null,"Ev bulunamadı!", false);
            return new DataResult<House>(house, true);
        }

        public IDataResult<IEnumerable<House>> GetAll()
        {
            var houses = _houseRepository.GetList();
            if (houses is null)
                return new DataResult<IEnumerable<House>>(null, "Evler bulunamadı!", false);
            return new DataResult<IEnumerable<House>>(houses, true);
        }

        public IDataResult<IEnumerable<HouseDto>> GetAllHouseDetail()
        {
            var houses = _houseRepository.GetAllHouseDetail();
            if (houses is null)
                return new DataResult<IEnumerable<HouseDto>>(null, "Evler bulunamadı!", false);
            return new DataResult<IEnumerable<HouseDto>>(houses, true);
        }

        public IDataResult<HouseDto> GetHouseDetail(int id)
        {
            var house = _houseRepository.GetHouseDetail(id);
            if (house is null)
                return new DataResult<HouseDto>(null, "Ev bulunamadı!", false);
            return new DataResult<HouseDto>(house, true);
        }
    }
}
