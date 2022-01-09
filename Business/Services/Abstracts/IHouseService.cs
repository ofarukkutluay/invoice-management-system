using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos;

namespace Business.Services.Abstracts
{
    public interface IHouseService 
    {
        IResult Create(House entity);
        IResult Delete(int id);
        IResult Update(int id, House entity);
        IDataResult<House> GetById(int id);
        IDataResult<IEnumerable<House>> GetAll();
        IDataResult<IEnumerable<HouseDto>> GetAllHouseDetail();
        IDataResult<HouseDto> GetHouseDetail(int id);

    }
}
