using Core.Entities.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Invoice : IEntity
    {
        public int Id { get; set; }
        public int InvoiceTypeId { get; set; }
        public int HouseId { get; set; }
        public double Amount { get; set; }
        public bool Status { get; set; } = false;
        public DateTime InvoiceDate { get; set; }
        public int PayingPersonId { get; set; }
        public DateTime DueDate { get; set; }
    }
}
