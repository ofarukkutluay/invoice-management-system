using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Entities.Concretes;

namespace Business.Services.Abstracts
{
    public interface IInvoiceTypeService
    {
        IResult Create(InvoiceType entity);
        IResult Delete(int id);
        IResult Update(int id, InvoiceType entity);
        IDataResult<InvoiceType> GetById(int id);
        IDataResult<IEnumerable<InvoiceType>> GetAll();
    }
}
