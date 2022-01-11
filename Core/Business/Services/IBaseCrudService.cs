using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Core.Business.Services
{
    public interface IBaseCrudService<T>
    {
        IResult Create(T entity);
        IResult Delete(int id);
        IResult Update(int id, T entity);
        IDataResult<T> GetById(int id);
        IDataResult<IEnumerable<T>> GetAll();
    }
}
