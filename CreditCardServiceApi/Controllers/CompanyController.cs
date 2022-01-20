using System.Collections.Generic;
using System.Reflection;
using AutoMapper;
using CreditCardServiceApi.Applications;
using CreditCardServiceApi.Applications.Company.Commands;
using CreditCardServiceApi.Applications.Company.Queries;
using CreditCardServiceApi.DataAccess.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyRepository companyRepository, IMapper mapper)
        {
            _companyRepository = companyRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreateCompanyViewModel model)
        {
            CreateCompanyCommand command = new CreateCompanyCommand(_companyRepository, _mapper);
            command.Model = model;
            command.Handle();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            GetCompaniesQuery query = new GetCompaniesQuery(_companyRepository, _mapper);
            
            var result = query.Handle();
            return Ok(result);
        }
    }
}
