using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dtos;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfOwnerDal : EfEntityRepositoryBase<Owner, InvoiceManagementDbContext>, IOwnerRepository
    {
        public EfOwnerDal(InvoiceManagementDbContext context) : base(context)
        {
        }

        public IEnumerable<OwnerDto> GetAllDetails()
        {
            var result = from o in Context.Owners
                join p in Context.Persons on o.PersonId equals p.Id
                join h in Context.Houses on o.HouseId equals h.Id
                join a in Context.Apartments on h.ApartmentId equals a.Id
                select new OwnerDto()
                {
                    PersonId = o.PersonId,
                    PersonName = p.FullName,
                    House = $"{a.Name} no:{h.DoorNumber}"
                };

            return result;
        }
    }
}
