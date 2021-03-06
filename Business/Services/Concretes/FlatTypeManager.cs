using AutoMapper;
using Business.Services.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Concretes
{
    public class FlatTypeManager : IFlatTypeService
    {
        private readonly IFlatTypeRepository _flatTypeRepository;
        private readonly IMapper _mapper;
        public FlatTypeManager(IFlatTypeRepository flatTypeRepository, IMapper mapper)
        {
            _flatTypeRepository = flatTypeRepository;
            _mapper = mapper;
                
        }
        public IResult Create(FlatType entity)
        {
            var flatType = _flatTypeRepository.Get(x=> x.RoomCount == entity.RoomCount && x.LivingRoomCount==entity.LivingRoomCount);
            if(flatType is not null)
                return new Result("Daire tipi mevcut",false);
            _flatTypeRepository.Add(entity);
            var result = _flatTypeRepository.SaveChanges();
            if (result == 0)
                return new Result("Kayıt yapılamadı!", false);
            return new Result("Kayıt Edildi!", true);

        }

        public IResult Delete(int id)
        {
            var flatType = _flatTypeRepository.Get(x=>x.Id==id);
            if (flatType is null)
                return new Result("Daire tipi bulunamadı",false);
            _flatTypeRepository.Delete(flatType);
            var result = _flatTypeRepository.SaveChanges();
            if (result == 0)
                return new Result("Kayıt yapılamadı!", false);
            return new Result("Data silindi!", true);
        }

        public IDataResult<IEnumerable<FlatType>> GetAll()
        {
            var flatTypes = _flatTypeRepository.GetList();
            return new DataResult<IEnumerable<FlatType>>(flatTypes,true);
        }

        public IDataResult<FlatType> GetById(int id)
        {
            var flatType = _flatTypeRepository.Get(x => x.Id == id);
            if (flatType is null)
                return new DataResult<FlatType>(null,"Daire tipi bulunamadı", false);
            return new DataResult<FlatType>(flatType, true);
        }

        public IResult Update(int id, FlatType entity)
        {
            var flatType = _flatTypeRepository.Get(x => x.Id == id);
            if (flatType is null)
                return new DataResult<FlatType>(null, "Daire tipi bulunamadı", false);
            flatType.RoomCount = entity.RoomCount== default ? flatType.RoomCount : entity.RoomCount;
            flatType.LivingRoomCount = entity.LivingRoomCount== default ? flatType.LivingRoomCount : entity.LivingRoomCount;
            var result = _flatTypeRepository.SaveChanges();
            if (result == 0)
                return new Result("Kayıt yapılamadı!", false);
            return new Result("Data silindi!", true);

        }
    }
}
