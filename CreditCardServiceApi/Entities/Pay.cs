using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CreditCardServiceApi.Entities
{
    public class Pay : EntityBase
    {

        public CreditCard CreditCard { get; set; }
        public string CompanyId { get; set; }
        public double Amount { get; set; }
        
        [BsonDateTimeOptions(DateOnly = true)]
        public DateTime PayTime { get; set; } = DateTime.Now;
        

    }
}
