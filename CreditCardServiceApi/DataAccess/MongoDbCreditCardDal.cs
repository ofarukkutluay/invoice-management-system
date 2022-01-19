using CreditCardServiceApi.DataAccess.Abstracts;
using CreditCardServiceApi.DataAccess.Base;
using CreditCardServiceApi.Entities;
using Microsoft.Extensions.Configuration;

namespace CreditCardServiceApi.DataAccess
{
    public class MongoDbCreditCardDal : MongoDbBaseRepository<CreditCard>, ICreditCardRepository
    {
        public MongoDbCreditCardDal(IConfiguration Configuration) : base(Configuration)
        {
        }
    }
}
