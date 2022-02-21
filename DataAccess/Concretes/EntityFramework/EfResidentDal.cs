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
    public class EfResidentDal : EfEntityRepositoryBase<Resident, InvoiceManagementDbContext>, IResidentRepository
    {
        public EfResidentDal(InvoiceManagementDbContext context) : base(context)
        {
        }

        public IEnumerable<ResidentDto> GetAllDetails()
        {
            var result = from r in Context.Residents
                join p in Context.Persons on r.PersonId equals p.Id
                join h in Context.Houses on r.HouseId equals h.Id
                join a in Context.Apartments on h.ApartmentId equals a.Id
                select new ResidentDto()
                {
                    PersonId = r.PersonId,
                    PersonName = p.FullName,
                    House = $"{a.Name} no:{h.DoorNumber}",
                    CarPlate = r.CarPlate,
                    IsHirer = r.IsHirer
                };

            return result;
        }
    }
}
