using Business.Handlers.ViewModels;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstracts
{
    public interface IApartmentService
    {
        IResult Create(CreateApartmentVM createApartment);
        IResult Delete(int id);
        IResult Update(int id, UpdateApartmentVM updateApartment);
        IDataResult<GetApartmentVM> GetById(int id);
        IDataResult<IEnumerable<GetApartmentsVM>> GetAll();
    }
}
