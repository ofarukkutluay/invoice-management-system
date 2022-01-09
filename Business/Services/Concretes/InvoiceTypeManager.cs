using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Abstracts;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Services.Concretes
{
    public class InvoiceTypeManager : IInvoiceTypeService
    {
        private readonly IInvoiceTypeRespository _invoiceTypeRespository;
        private readonly IMapper _mapper;
        public InvoiceTypeManager(IInvoiceTypeRespository invoiceTypeRespository,IMapper mapper)
        {
            _invoiceTypeRespository = invoiceTypeRespository;
            _mapper = mapper;
        }
        public IResult Create(InvoiceType entity)
        {
            _invoiceTypeRespository.Add(entity);
            var result = _invoiceTypeRespository.SaveChanges();
            if (result == 0)
                return new Result("Db ye kayıt ederken bir hata oluştu!", false);
            return new Result("Kayıt Edildi!", true);
        }

        public IResult Delete(int id)
        {
            var invoiceType = _invoiceTypeRespository.Get(x => x.Id == id);
            if (invoiceType is null)
                return new Result("Data bulunamadı!", false);
            _invoiceTypeRespository.Delete(invoiceType);
            var result = _invoiceTypeRespository.SaveChanges();
            if (result == 0)
                return new Result("Db ye kayıt ederken bir hata oluştu!", false);
            return new Result("Silindi!", true);
        }

        public IResult Update(int id, InvoiceType entity)
        {
            var invoiceType = _invoiceTypeRespository.Get(x => x.Id == id);
            if (invoiceType is null)
                return new Result("Data bulunamadı!", false);
            invoiceType.Name = entity.Name == default ? invoiceType.Name : entity.Name;
            var result = _invoiceTypeRespository.SaveChanges();
            if (result == 0)
                return new Result("Db ye kayıt ederken bir hata oluştu!", false);
            return new Result("Güncellendi!", true);
        }

        public IDataResult<InvoiceType> GetById(int id)
        {
            var invoiceType = _invoiceTypeRespository.Get(x => x.Id == id);
            if (invoiceType is null)
                return new DataResult<InvoiceType>(null,"Data bulunamadı!", false);
            return new DataResult<InvoiceType>(invoiceType, true);
        }

        public IDataResult<IEnumerable<InvoiceType>> GetAll()
        {
            var invoiceTypes = _invoiceTypeRespository.GetList();
            return new DataResult<IEnumerable<InvoiceType>>(invoiceTypes, true);
        }
    }
}
