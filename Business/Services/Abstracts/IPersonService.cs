using Core.Entities.Concretes;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business.Services;
using Entities.Dtos;

namespace Business.Services.Abstracts
{
    public interface IPersonService : IBaseCrudService<Person>
    {
        IDataResult<PersonDto> GetByIdPerson(int id);
        IDataResult<Person> GetByEmail(string email);
        IResult AddRefreshToken(int id ,string refreshToken , DateTime expirationTime);

    }
}
