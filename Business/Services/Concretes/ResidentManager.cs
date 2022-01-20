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

namespace Business.Services.Concretes
{
    public class ResidentManager : IResidentService
    {
        private readonly IResidentRepository _residentRepository;
        private readonly IMapper _mapper;

        public ResidentManager(IResidentRepository residentRepository, IMapper mapper)
        {
            _residentRepository = residentRepository;
            _mapper = mapper;
        }
        public IResult Create(Resident entity)
        {
            entity.CarPlate.ToUpper();
            _residentRepository.Add(entity);
            var result = _residentRepository.SaveChanges();
            if (result == 0)
                return new Result("Db ye kayıt ederken bir sorun oluştu", false);
            return new Result("Kayıt edildi!", true);
        }

        public IResult Delete(int id)
        {
            var resident = _residentRepository.Get(x => x.PersonId == id);
            if (resident is null)
                return new Result("Kullanıcı bulunamadı!", false);
            _residentRepository.Delete(resident);
            var result = _residentRepository.SaveChanges();
            if (result == 0)
                return new Result("Db ye kayıt ederken bir sorun oluştu", false);
            return new Result("Silindi!", true);
        }

        public IResult Update(int id, Resident entity)
        {
            var resident = _residentRepository.Get(x => x.PersonId == id);
            if (resident is null)
                return new Result("Kullanıcı bulunamadı!", false);

            resident.HouseId = entity.HouseId == default ? resident.HouseId : entity.HouseId;
            resident.CarPlate = entity.CarPlate == default ? resident.CarPlate : entity.CarPlate.ToUpper();
            resident.IsHirer = entity.IsHirer == default ? resident.IsHirer : entity.IsHirer;

            var result = _residentRepository.SaveChanges();
            if (result == 0)
                return new Result("Db ye kayıt ederken bir sorun oluştu", false);
            return new Result("Güncellendi!", true);
        }

        public IDataResult<Resident> GetById(int id)
        {
            var resident = _residentRepository.Get(x => x.PersonId == id);
            if (resident is null)
                return new DataResult<Resident>(null,"Kullanıcı bulunamadı!", false);
            return new DataResult<Resident>(resident, true);
        }

        public IDataResult<IEnumerable<Resident>> GetAll()
        {
            var residents = _residentRepository.GetList();
            return new DataResult<IEnumerable<Resident>>(residents, true);
        }
    }
}
