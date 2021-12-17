using Core.DataAccess.EntityFramework;
using Core.Entities.Concretes;
using DataAccess.Abstracts;


namespace DataAccess.Concretes.EntityFramework
{
    public class EfPersonDal : EfEntityRepositoryBase<Person, InvoiceManagementDbContext>, IPersonRepository
    {
        public EfPersonDal(InvoiceManagementDbContext context) : base(context)
        {
        }
    }
}
