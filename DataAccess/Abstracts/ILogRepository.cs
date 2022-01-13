using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Logging;
using Core.DataAccess;
using Core.Entities.Concretes;

namespace DataAccess.Abstracts
{
    public interface ILogRepository : IEntityRepository<Log>
    {
    }
}
