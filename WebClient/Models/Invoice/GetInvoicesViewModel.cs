﻿using System;

namespace WebClient.Models.Invoice
{
    public class GetInvoicesViewModel
    {
        public int Id { get; set; }
        public int InvoiceTypeId { get; set; }
        public int HouseId { get; set; }
        public double Amount { get; set; }
        public bool Status { get; set; }
        public DateTime InvoiceDate { get; set; }

    }
}
