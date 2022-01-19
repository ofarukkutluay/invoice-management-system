using CreditCardServiceApi.DataAccess.Base;
using CreditCardServiceApi.Entities;

namespace CreditCardServiceApi.DataAccess.Abstracts
{
    public interface ICompanyRepository : IMongoDbBaseRepository<Company>
    {
    }
}
