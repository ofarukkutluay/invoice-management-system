using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Abstracts;

namespace Entities.Concretes
{
    public class PayInvoicePerson : IEntity
    {
        public int InvoiceId { get; set; }
        public int PersonId { get; set; }
        public decimal PayingAmount { get; set; }
        public DateTime DueDate { get; set; } = DateTime.Now;
    }
}
