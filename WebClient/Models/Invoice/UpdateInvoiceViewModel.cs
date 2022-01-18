﻿using System;

namespace WebClient.Models.Invoice
{
    public class UpdateInvoiceViewModel
    {
        public int Id { get; set; }
        public int InvoiceTypeId { get; set; }
        public int HouseId { get; set; }
        public double Amount { get; set; }
        public bool Status { get; set; }
        public DateTime InvoiceDate { get; set; }

    }
}
