using MongoDB.Bson.Serialization.Attributes;

namespace CreditCardServiceApi.Entities
{
    public abstract class EntityBase
    {
        [BsonId]
        public string Id { get; set; }
    }
}
