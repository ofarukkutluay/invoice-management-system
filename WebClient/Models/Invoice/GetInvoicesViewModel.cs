using System;

namespace WebClient.Models.Invoice
{
    public class GetInvoicesViewModel
    {
        public int Id { get; set; }
        public string InvoiceType { get; set; }
        public string House { get; set; }
        public decimal Amount { get; set; }
        public bool Status { get; set; }
        public DateTime InvoiceDate { get; set; }

    }
}
