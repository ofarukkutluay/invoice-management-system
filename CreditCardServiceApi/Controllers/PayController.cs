using System.Collections.Generic;
using System.Net;
using AutoMapper;
using CreditCardServiceApi.Applications;
using CreditCardServiceApi.Applications.Pay.Commands;
using CreditCardServiceApi.Applications.Pay.Queries;
using CreditCardServiceApi.DataAccess.Abstracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private readonly IPayRepository _payRepository;
        private readonly IMapper _mapper;

        public PayController(IPayRepository payRepository, IMapper mapper)
        {
            _payRepository = payRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult Create(CreatePayViewModel model)
        {
            CreatePayCommand command = new CreatePayCommand(_payRepository, _mapper);
            command.Model = model;
            var result = command.Handle();
            return Ok(result);
        }

        [HttpGet("[action]/{companyId}")]
        public IActionResult GetCompanyId(string companyId)
        {
            GetPaysQuery query = new GetPaysQuery(_payRepository, _mapper);
            query.CompanyId = companyId;
            var result = query.Handle();
            return Ok(result);
        }

    }
}
