using System;

namespace WebClient.Models.Invoice
{
    public class CreateInvoiceViewModel
    {
        public int InvoiceTypeId { get; set; }
        public int HouseId { get; set; }
        public decimal Amount { get; set; }
        public DateTime InvoiceDate { get; set; }

    }
}
