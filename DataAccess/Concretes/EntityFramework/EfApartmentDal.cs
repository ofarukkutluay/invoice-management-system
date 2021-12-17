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
    public class EfApartmentDal : EfEntityRepositoryBase<Apartment, InvoiceManagementDbContext>, IApartmentRepository
    {
        public EfApartmentDal(InvoiceManagementDbContext context) : base(context)
        {
        }
    }
}
