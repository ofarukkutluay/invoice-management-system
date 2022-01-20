using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using CreditCardServiceApi.DataAccess.Abstracts;

namespace CreditCardServiceApi.Applications.Pay.Queries
{
    public class GetPaysQuery
    {
        public string CompanyId { get; set; }

        private readonly IPayRepository _payRepository;
        private readonly IMapper _mapper;

        public GetPaysQuery(IPayRepository payRepository, IMapper mapper)
        {
            _payRepository = payRepository;
            _mapper = mapper;
        }

        public IEnumerable<GetPaysViewModel> Handle()
        {
            var pays = _payRepository.SearchFor(x => x.CompanyId == CompanyId);
            IEnumerable<GetPaysViewModel> rtnObj = _mapper.Map<IEnumerable<GetPaysViewModel>>(pays);
            
            return rtnObj;
        }
    }

    public class GetPaysViewModel
    {
        public string Id { get; set; }
        public double Amount { get; set; }
        public DateTime PayTime { get; set; }
        public CreateCreditCardVM CreditCard { get; set; }
        public struct CreateCreditCardVM
        {
            public string CardHolderName { get; set; }
            public long CardNumber { get; set; }
            public int ExpirationMouth { get; set; }
            public int ExpirationYear { get; set; }
            public int CVCCode { get; set; }
        }
        public bool Status { get; set; }
        public int StatusCode { get; set; }
        public string ResultMessage { get; set; }
    }

}
