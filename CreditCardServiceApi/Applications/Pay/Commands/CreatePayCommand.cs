using System;
using System.Linq;
using AutoMapper;
using CreditCardServiceApi.DataAccess.Abstracts;
using CreditCardServiceApi.Entities;

namespace CreditCardServiceApi.Applications.Pay.Commands
{
    public class CreatePayCommand : ICommandService<CreatePayViewModel>
    {
        public CreatePayViewModel Model { get; set; }
        private readonly IPayRepository _payRepository;
        private readonly ICreditCardRepository _creditCardRepository;
        private readonly IMapper _mapper;

        public CreatePayCommand(IPayRepository payRepository, ICreditCardRepository creditCardRepository, IMapper mapper)
        {
            _payRepository = payRepository;
            _creditCardRepository = creditCardRepository;
            _mapper = mapper;
        }
        public void Handle()
        {
            var ccModel = _mapper.Map<CreditCard>(Model.CreditCard);
            var pay = _mapper.Map<Entities.Pay>(Model);

            var cc = _creditCardRepository.SearchFor(x => x.CardNumber == Model.CreditCard.CardNumber)
                .SingleOrDefault();
            if (cc is null)
                _creditCardRepository.Insert(ccModel);

            pay.Status = true;
            pay.StatusCode = 200;
            pay.ResultMessage = $"{pay.Amount} TL ödeme alındı.";
            pay.CreditCardNumber = Model.CreditCard.CardNumber;
            _payRepository.Insert(pay);
        }
    }

    public class CreatePayViewModel
    {
        public CreateCreditCardVM CreditCard { get; set; }
        public string CompanyId { get; set; }
        public double Amount { get; set; }
        public DateTime PayTime { get; set; }

        public struct CreateCreditCardVM
        {
            public string CardHolderName { get; set; }
            public long CardNumber { get; set; }
            public int ExpirationMouth { get; set; }
            public int ExpirationYear { get; set; }
            public int CVCCode { get; set; }
        }
    }
}
