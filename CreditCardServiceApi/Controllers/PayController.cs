using System.Collections.Generic;
using CreditCardServiceApi.Applications;
using CreditCardServiceApi.Applications.Pay.Commands;
using CreditCardServiceApi.Applications.Pay.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayController : ControllerBase
    {
        private ICommandService<CreatePayViewModel> _commandService;
        private IQueryService<IEnumerable<GetPaysViewModel>> _queryService;

        public PayController(ICommandService<CreatePayViewModel> commandService, IQueryService<IEnumerable<GetPaysViewModel>> queryService)
        {
            _commandService = commandService;
            _queryService = queryService;
        }

        [HttpPost]
        public IActionResult Create(CreatePayViewModel model)
        {
            _commandService.Model = model;
            _commandService.Handle();
            return Ok("Ödeme başarılı");
        }

        [HttpGet("[action]")]
        public IActionResult GetCompanyId(string companyId)
        {
            _queryService.CompanyId = companyId;
            var result = _queryService.Handle();
            return Ok(result);
        }

    }
}
