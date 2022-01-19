using CreditCardServiceApi.DataAccess.Abstracts;
using CreditCardServiceApi.DataAccess.Base;
using CreditCardServiceApi.Entities;
using Microsoft.Extensions.Configuration;

namespace CreditCardServiceApi.DataAccess
{
    public class MongoDbPayDal : MongoDbBaseRepository<Pay> , IPayRepository
    {
        public MongoDbPayDal(IConfiguration Configuration) : base(Configuration)
        {
        }
    }
}
