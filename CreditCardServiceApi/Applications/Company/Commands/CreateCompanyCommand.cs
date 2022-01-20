using System;
using System.Linq;
using AutoMapper;
using CreditCardServiceApi.DataAccess.Abstracts;

namespace CreditCardServiceApi.Applications.Company.Commands
{
    public class CreateCompanyCommand
    {
        public CreateCompanyViewModel Model { get; set; }
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CreateCompanyCommand(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public void Handle()
        {
            var company = _companyRepository.SearchFor(x => x.TaxNumber == Model.TaxNumber).SingleOrDefault();
            if (company is not null)
                throw new InvalidOperationException($"{Model.TaxNumber} vergi numaralı kayıt bulunmaktadır.");
            company = _mapper.Map<Entities.Company>(Model);
            _companyRepository.Insert(company);
        }

    }

    public class CreateCompanyViewModel
    {
        public string Name { get; set; }
        public long TaxNumber { get; set; }
        public string TaxAdministrator { get; set; }
    }
}
