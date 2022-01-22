using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Abstracts;
using Business.Services.OutsideService.PaymentService;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using Entities.Dtos;

namespace Business.Services.Concretes
{
    public class PayInvoicePersonManager : IPayInvoicePersonService
    {
        private readonly IPayInvoicePersonRepository _payInvoicePersonRepository;
        private readonly IPaymentService _paymentService;
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public PayInvoicePersonManager(IPayInvoicePersonRepository payInvoicePersonRepository, IPaymentService paymentService, IInvoiceService invoiceService, IMapper mapper)
        {
            _payInvoicePersonRepository = payInvoicePersonRepository;
            _paymentService = paymentService;
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        public async Task<IResult> PayInvoice(int personId, PayOrderDto payOrder)
        {
            PaymentOrder paymentOrder = _mapper.Map<PaymentOrder>(payOrder);
            var psResult = await _paymentService.PayOrder(paymentOrder);
            if (!psResult.Status)
            {
                return new Result($"{psResult.StatusCode} - {psResult.Message}", psResult.Status);
            }
            PayInvoicePerson pip = new PayInvoicePerson
            {
                PersonId = personId,
                InvoiceId = payOrder.InvoiceId,
                PayingAmount = payOrder.Amount
            };
            _payInvoicePersonRepository.Add(pip);
            var result = _payInvoicePersonRepository.SaveChanges();
            if (result == 0)
                return new Result("Ödeme db ye kayıt edilirken hata alındı", false);
            var inResult = _invoiceService.PaySuccess(payOrder.InvoiceId);
            if (!inResult.Success)
                return new Result("Fatura db güncellenirken hata alındı", false);
            return new Result(psResult.Message, psResult.Status);

        }


        public IDataResult<PayInvoicePerson> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IEnumerable<PayInvoicePerson>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
