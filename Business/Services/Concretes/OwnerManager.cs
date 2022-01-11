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
    public class OwnerManager :IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public OwnerManager(IOwnerRepository ownerRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }

        public IResult Create(Owner entity)
        {
            _ownerRepository.Add(entity);
            var result = _ownerRepository.SaveChanges();
            if (result == 0)
                return new Result("Db ye kayıt ederken bir sorun oluştu", false);
            return new Result("Kayıt edildi!", true);
        }

        public IResult Delete(int id)
        {
            var owner = _ownerRepository.Get(x => x.PersonId == id);
            if (owner is null)
                return new Result("Kayıt bulunamadı", false);
            _ownerRepository.Delete(owner);
            var result = _ownerRepository.SaveChanges();
            if (result == 0)
                return new Result("Db ye kayıt ederken bir sorun oluştu", false);
            return new Result("Silindi!", true);
        }

        public IResult Update(int id, Owner entity)
        {
            var owner = _ownerRepository.Get(x => x.PersonId == id);
            if (owner is null)
                return new Result("Kayıt bulunamadı", false);
            _ownerRepository.Update(entity);
            var result = _ownerRepository.SaveChanges();
            if (result == 0)
                return new Result("Db ye kayıt ederken bir sorun oluştu", false);
            return new Result("Kayıt güncellendi!", true);
        }

        public IDataResult<Owner> GetById(int id)
        {
            var owner = _ownerRepository.Get(x => x.PersonId == id);
            if (owner is null)
                return new DataResult<Owner>(null,"Kayıt bulunamadı", false);
            return new DataResult<Owner>(owner, true);
        }

        public IDataResult<IEnumerable<Owner>> GetAll()
        {
            var owners = _ownerRepository.GetList();
            return new DataResult<IEnumerable<Owner>>(owners, true);
        }
    }
}
