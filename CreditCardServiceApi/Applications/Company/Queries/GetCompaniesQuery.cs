using System.Collections.Generic;
using AutoMapper;
using CreditCardServiceApi.DataAccess.Abstracts;

namespace CreditCardServiceApi.Applications.Company.Queries
{
    public class GetCompaniesQuery
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public GetCompaniesQuery(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        public IEnumerable<GetCompaniesViewModel> Handle()
        {
            var companies = _companyRepository.GetAll();
            var vmModel = _mapper.Map<IEnumerable<GetCompaniesViewModel>>(companies);
            return vmModel;
        }

    }

    public class GetCompaniesViewModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public long TaxNumber { get; set; }
        public string TaxAdministrator { get; set; }
    }
}
