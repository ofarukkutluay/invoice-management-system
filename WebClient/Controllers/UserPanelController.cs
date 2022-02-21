using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Business.Services.Abstracts;
using Core.Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models.UserPanel;

namespace WebClient.Controllers
{
    [Authorize(Roles = OperationClaims.AdminOrUser)]
    public class UserPanelController : Controller
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public UserPanelController(IInvoiceService invoiceService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Invoices()
        {
            var value = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (value != null)
            {
                int personId = Int32.Parse(value);
                var result = _invoiceService.GetAllUserInvoiceDetail(personId);
                IEnumerable<GetUserInvoicesViewModel> model =
                    _mapper.Map<IEnumerable<GetUserInvoicesViewModel>>(result.Data);
                return View(model);
            }
            return RedirectToAction("Login", "Auth");
        }

    }
}
