using System;

namespace CreditCardServiceApi.Entities
{
    public class Pay : EntityBase
    {

        public long CreditCardNumber { get; set; }
        public string CompanyId { get; set; }
        public double Amount { get; set; }
        public DateTime PayTime { get; set; } = DateTime.Now;
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string  ResultMessage { get; set; }

    }
}
