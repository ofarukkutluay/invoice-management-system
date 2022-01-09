using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfHouseDal : EfEntityRepositoryBase<House, InvoiceManagementDbContext>, IHouseRepository
    {
        public EfHouseDal(InvoiceManagementDbContext context) : base(context)
        {
        }

        public IEnumerable<HouseDto> GetAllHouseDetail()
        {
            var result = from h in Context.Houses
                join a in Context.Apartments on h.ApartmentId equals a.Id
                join ft in Context.FlatTypes on h.FlatTypeId equals ft.Id
                select new HouseDto
                {
                    Id = h.Id,
                    ApartmentName = a.Name,
                    DoorNumber = h.DoorNumber,
                    FloorLocation = h.FloorLocation,
                    FlatType =  $"{ft.RoomCount} + {ft.LivingRoomCount}"
                };
            return result;
        }
        public HouseDto GetHouseDetail(int id)
        {
            var result = from h in Context.Houses
                join a in Context.Apartments on h.ApartmentId equals a.Id
                join ft in Context.FlatTypes on h.FlatTypeId equals ft.Id
                where ft.Id == id
                select new HouseDto
                {
                    Id = h.Id,
                    ApartmentName = a.Name,
                    DoorNumber = h.DoorNumber,
                    FloorLocation = h.FloorLocation,
                    FlatType = $"{ft.RoomCount} + {ft.LivingRoomCount}"
                };
            return result.SingleOrDefault();
        }

        public Apartment GetApartment(int apartmentId)
        {
            var result = from a in Context.Apartments
                where a.Id == apartmentId
                select new Apartment
                {
                    Id = a.Id,
                    Name = a.Name,
                    TotalFloors = a.TotalFloors
                };
            return result.SingleOrDefault();
        }
    }
}
