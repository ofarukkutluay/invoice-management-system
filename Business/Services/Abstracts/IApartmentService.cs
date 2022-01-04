using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstracts
{
    public interface IApartmentService
    {
        IResult Create(Apartment entity);
        IResult Delete(int id);
        IResult Update(int id, Apartment entity);
        IDataResult<Apartment> GetById(int id);
        IDataResult<IEnumerable<Apartment>> GetAll();
    }
}
