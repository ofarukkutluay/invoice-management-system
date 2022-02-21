using Core.DataAccess;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dtos;

namespace DataAccess.Abstracts
{
    public interface IResidentRepository : IEntityRepository<Resident>
    {
        IEnumerable<ResidentDto> GetAllDetails();
    }

}
