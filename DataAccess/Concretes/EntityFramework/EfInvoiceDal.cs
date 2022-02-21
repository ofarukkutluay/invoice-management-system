using Core.DataAccess.EntityFramework;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace DataAccess.Concretes.EntityFramework
{
    public class EfInvoiceDal : EfEntityRepositoryBase<Invoice, InvoiceManagementDbContext>, IInvoiceRepository
    {
        public EfInvoiceDal(InvoiceManagementDbContext context) : base(context)
        {
        }

        public IEnumerable<InvoiceDto> GetAllUserInvoiceDetail(int personId)
        {
            var result = from i in Context.Invoices
                join it in Context.InvoiceTypes on i.InvoiceTypeId equals it.Id
                join h in Context.Houses on i.HouseId equals h.Id
                join a in Context.Apartments on h.ApartmentId equals a.Id
                join res in Context.Residents on h.Id equals res.HouseId
                where res.PersonId == personId
                select new InvoiceDto()
                {
                    Id = i.Id,
                    House = $"{a.Name} no: {h.DoorNumber}",
                    InvoiceType = it.Name,
                    Amount = i.Amount,
                    InvoiceDate = i.InvoiceDate,
                    Status = i.Status
                };
            return result;
        }

        public IEnumerable<InvoiceDto> GetAllInvoiceDetail()
        {
            var result = from i in Context.Invoices
                join it in Context.InvoiceTypes on i.InvoiceTypeId equals it.Id
                join h in Context.Houses on i.HouseId equals h.Id
                join a in Context.Apartments on h.ApartmentId equals a.Id
                select new InvoiceDto()
                {
                    Id = i.Id,
                    House = $"{a.Name} no: {h.DoorNumber}",
                    InvoiceType = it.Name,
                    Amount = i.Amount,
                    InvoiceDate = i.InvoiceDate,
                    Status = i.Status
                };
            return result;
        }

        public InvoiceDto GetInvoiceDetail(int id)
        {
            var result = from i in Context.Invoices
                join it in Context.InvoiceTypes on i.InvoiceTypeId equals it.Id
                join h in Context.Houses on i.HouseId equals h.Id
                join a in Context.Apartments on h.ApartmentId equals a.Id
                where i.Id == id
                select new InvoiceDto()
                {
                    Id = i.Id,
                    House = $"{a.Name} no: {h.DoorNumber}",
                    InvoiceType = it.Name,
                    Amount = i.Amount,
                    InvoiceDate = i.InvoiceDate,
                    Status = i.Status
                };
            return result.SingleOrDefault();
        }
    }
}
