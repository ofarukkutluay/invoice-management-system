using System;

namespace WebClient.Models.Invoice
{
    public class CreateInvoiceViewModel
    {
        public int Id { get; set; }
        public int InvoiceTypeId { get; set; }
        public int HouseId { get; set; }
        public double Amount { get; set; }
        public bool Status { get; set; } = true;
        public DateTime InvoiceDate { get; set; }
        public int PayingPersonId { get; set; }
        public DateTime DueDate { get; set; }
    }
}
