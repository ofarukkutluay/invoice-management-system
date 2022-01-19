using CreditCardServiceApi.DataAccess.Abstracts;
using CreditCardServiceApi.DataAccess.Base;
using CreditCardServiceApi.Entities;
using Microsoft.Extensions.Configuration;

namespace CreditCardServiceApi.DataAccess
{
    public class MongoDbCompanyDal : MongoDbBaseRepository<Company>, ICompanyRepository
    {
        public MongoDbCompanyDal(IConfiguration Configuration) : base(Configuration)
        {
        }
    }
}
