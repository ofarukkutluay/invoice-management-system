using Core.Entities.Concretes;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Abstracts
{
    public interface IPersonService
    {
        IDataResult<List<Person>> GetAll();
        Person GetByEmail(string email);
        IResult Add(Person person);

    }
}
