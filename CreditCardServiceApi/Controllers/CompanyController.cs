using System.Collections.Generic;
using System.Reflection;
using CreditCardServiceApi.Applications;
using CreditCardServiceApi.Applications.Company.Commands;
using CreditCardServiceApi.Applications.Company.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CreditCardServiceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private ICommandService<CreateCompanyViewModel> _createCommand;
        private IQueryService<IEnumerable<GetCompaniesViewModel>> _queryService;

        public CompanyController(ICommandService<CreateCompanyViewModel> createCommand,
            IQueryService<IEnumerable<GetCompaniesViewModel>> queryService)
        {
            _createCommand = createCommand;
            _queryService = queryService;
        }

        [HttpPost]
        public IActionResult Create(CreateCompanyViewModel model)
        {
            _createCommand.Model = model;
            _createCommand.Handle();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _queryService.Handle();
            return Ok(result);
        }
    }
}
