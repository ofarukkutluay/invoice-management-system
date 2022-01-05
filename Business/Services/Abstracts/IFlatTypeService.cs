using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstracts
{
    public interface IFlatTypeService
    {
        IResult Create(FlatType entity);
        IResult Delete(int id);
        IResult Update(int id, FlatType entity);
        IDataResult<FlatType> GetById(int id);
        IDataResult<IEnumerable<FlatType>> GetAll();
    }
}
