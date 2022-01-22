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
        public decimal Amount { get; set; }
        public bool Status { get; set; } = true;
        public DateTime InvoiceDate { get; set; }

    }
}
