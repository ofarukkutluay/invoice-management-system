using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CreditCardServiceApi.Entities
{
    public class Pay : EntityBase
    {

        public CreditCard CreditCard { get; set; }
        public string CompanyId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PayTime { get; set; } = DateTime.Now;
        

    }
}
