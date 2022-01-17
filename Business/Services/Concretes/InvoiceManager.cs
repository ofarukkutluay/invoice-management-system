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
    public class InvoiceManager : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        private readonly IMapper _mapper;

        public InvoiceManager(IInvoiceRepository invoiceRepository, IMapper mapper)
        {
            _invoiceRepository = invoiceRepository;
            _mapper = mapper;
        }

        public IResult Create(Invoice entity)
        {
            _invoiceRepository.Add(entity);
            var result = _invoiceRepository.SaveChanges();
            if (result == 0)
                return new Result("DB ye kayıt ederken bir hata oluştu", false);
            return new Result("Kayıt yapıldı",true);
        }

        public IResult Delete(int id)
        {
            var invoice = _invoiceRepository.Get(x => x.Id == id);
            if (invoice is null)
                return new Result("Fatura bulunamadı!", false);
            _invoiceRepository.Delete(invoice);
            var result = _invoiceRepository.SaveChanges();
            if (result == 0)
                return new Result("DB ye kayıt ederken bir hata oluştu", false);
            return new Result("Silindi", true);
        }

        public IResult Update(int id, Invoice entity)
        {
            var invoice = _invoiceRepository.Get(x => x.Id == id);
            if (invoice is null)
                return new Result("Fatura bulunamadı!", false);
            _invoiceRepository.Update(invoice);
            var result = _invoiceRepository.SaveChanges();
            if (result == 0)
                return new Result("DB ye kayıt ederken bir hata oluştu", false);
            return new Result("Güncellendi", true);
        }

        public IDataResult<Invoice> GetById(int id)
        {
            var invoice = _invoiceRepository.Get(x => x.Id == id);
            if (invoice is null)
                return new DataResult<Invoice>(null,"Fatura bulunamadı!", false);
            return new DataResult<Invoice>(invoice, true);
        }

        public IDataResult<IEnumerable<Invoice>> GetAll()
        {
            var invoices = _invoiceRepository.GetList();
            return new DataResult<IEnumerable<Invoice>>(invoices, true);
        }
    }
}
