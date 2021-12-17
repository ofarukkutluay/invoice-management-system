using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfInvoiceTypeDal : EfEntityRepositoryBase<InvoiceType, InvoiceManagementDbContext>, IInvoiceTypeRespository
    {
        public EfInvoiceTypeDal(InvoiceManagementDbContext context) : base(context)
        {
        }
    }
}
