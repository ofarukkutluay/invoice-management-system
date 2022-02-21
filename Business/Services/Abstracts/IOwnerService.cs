using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business.Services;
using Core.Utilities.Results;
using Entities.Concretes;
using Entities.Dtos;

namespace Business.Services.Abstracts
{
    public interface IOwnerService : IBaseCrudService<Owner>
    {
        IDataResult<IEnumerable<OwnerDto>> GetAllDetails();
    }
}
