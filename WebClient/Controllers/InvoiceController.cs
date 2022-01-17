using System.Collections.Generic;
using AutoMapper;
using Business.Services.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models.Invoice;

namespace WebClient.Controllers
{
    public class InvoiceController : BaseController
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IMapper _mapper;

        public InvoiceController(IInvoiceService invoiceService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var result = _invoiceService.GetAll();
            IEnumerable<GetInvoicesViewModel> model = _mapper.Map<IEnumerable<GetInvoicesViewModel>>(result.Data);
            if (result.Success)
            {
                return View(model);
            }
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateInvoiceViewModel model)
        {
            var invoice = _mapper.Map<Invoice>(model);
            var result = _invoiceService.Create(invoice);
            if (result.Success)
            {
                SuccessAlert(result.Message);
                return RedirectToAction("Index");
            }
            DangerAlert(result.Message);
            return View();
        }
        public IActionResult Edit(int id)
        {
            var data = _invoiceService.GetById(id);
            var returnObj = _mapper.Map<UpdateInvoiceViewModel>(data.Data);
            return View(returnObj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UpdateInvoiceViewModel model)
        {
            var invoice = _mapper.Map<Invoice>(model);
            var result = _invoiceService.Update(id, invoice);
            if (result.Success)
            {
                SuccessAlert(result.Message);
                return RedirectToAction("Index");
            }
            DangerAlert(result.Message);
            return View();
        }


        public IActionResult Delete(int id)
        {
            var result = _invoiceService.Delete(id);
            SuccessAlert(result.Message);
            return RedirectToAction("Index");
        }
    }
}
