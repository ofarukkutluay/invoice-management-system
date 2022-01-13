using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.CrossCuttingConcerns.Logging;
using Core.DataAccess.EntityFramework;
using Core.Entities.Concretes;
using DataAccess.Abstracts;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfLogDal : EfEntityRepositoryBase<Log,InvoiceManagementDbContext> , ILogRepository
    {
        public EfLogDal(InvoiceManagementDbContext context) : base(context)
        {
        }
    }
}
