using CreditCardServiceApi.DataAccess.Base;
using CreditCardServiceApi.Entities;

namespace CreditCardServiceApi.DataAccess.Abstracts
{
    public interface ICreditCardRepository : IMongoDbBaseRepository<CreditCard>
    {
    }
}
