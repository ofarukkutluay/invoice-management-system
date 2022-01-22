using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services.Abstracts;
using Business.Services.OutsideService.PaymentService;
using Core.Entities.Concretes;
using Entities.Concretes;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using WebClient.Models.Invoice;
using WebClient.Models.Payment;

namespace WebClient.Controllers
{
    [Authorize(Roles = OperationClaims.AdminOrUser)]
    public class PaymentController : BaseController
    {
        private readonly IPayInvoicePersonService _payInvoicePersonService;
        private readonly IMapper _mapper;

        
        public PaymentController(IPayInvoicePersonService payInvoicePersonService, IMapper mapper)
        {
            _payInvoicePersonService = payInvoicePersonService;
            _mapper = mapper;
        }

        public IActionResult Index(CreatePayOrderViewModel payOrder)
        {
            return View(payOrder);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> PayOrder(CreatePayOrderViewModel payOrder)
        {
            var postModel = _mapper.Map<PayOrderDto>(payOrder);
            string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            var result = await _payInvoicePersonService.PayInvoice(Int32.Parse(userId), postModel);
            if (result.Success)
            {
                SuccessAlert(result.Message);
                return RedirectToAction("Index", "Invoice");
            }
            DangerAlert(result.Message);
            return RedirectToAction("Index",routeValues:payOrder);
        }
    }
}
