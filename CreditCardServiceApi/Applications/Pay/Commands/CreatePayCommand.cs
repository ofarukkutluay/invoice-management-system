using System;
using System.Linq;
using System.Net;
using AutoMapper;
using CreditCardServiceApi.Common.Utility.Results;
using CreditCardServiceApi.DataAccess.Abstracts;
using CreditCardServiceApi.Entities;

namespace CreditCardServiceApi.Applications.Pay.Commands
{
    public class CreatePayCommand
    {
        public CreatePayViewModel Model { get; set; }
        private readonly IPayRepository _payRepository;
        private readonly IMapper _mapper;

        public CreatePayCommand(IPayRepository payRepository, IMapper mapper)
        {
            _payRepository = payRepository;
            _mapper = mapper;
        }
        public IResult Handle()
        {
            var pay = _mapper.Map<Entities.Pay>(Model);
            pay.CreditCard = _mapper.Map<CreditCard>(Model);
            _payRepository.Insert(pay);
            return new Result(true, (int)HttpStatusCode.Created, $"{pay.Amount} TL ödeme alındı.");
        }
    }

    public class CreatePayViewModel
    {
        public string CompanyId { get; set; }
        public double Amount { get; set; }
        public string CardHolderName { get; set; }
        public long CardNumber { get; set; }
        public int ExpirationMouth { get; set; }
        public int ExpirationYear { get; set; }
        public int CVCCode { get; set; }

    }
}
