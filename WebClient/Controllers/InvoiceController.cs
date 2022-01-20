using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Services.Abstracts;
using Core.Entities.Concretes;
using Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebClient.Models.Invoice;

namespace WebClient.Controllers
{
    [Authorize(Roles = OperationClaims.Admin)]
    public class InvoiceController : BaseController
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IInvoiceTypeService _invoiceTypeService;
        private readonly IHouseService _houseService;
        private readonly IMapper _mapper;

        public InvoiceController(IInvoiceService invoiceService, IInvoiceTypeService invoiceTypeService, IHouseService houseService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _invoiceTypeService = invoiceTypeService;
            _houseService = houseService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var result = _invoiceService.GetAllDetails();
            IEnumerable<GetInvoicesViewModel> model = _mapper.Map<IEnumerable<GetInvoicesViewModel>>(result.Data);
            if (result.Success)
            {
                return View(model);
            }
            return View();
        }

        public IActionResult Create()
        {
            SelectItemInitialize();
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
            SelectItemInitialize();
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

        private void SelectItemInitialize()
        {
            IEnumerable<SelectListItem> selectHouses = _houseService.GetAllHouseDetail().Data.Select(x =>
            {
                return new SelectListItem
                {
                    Value = x.Id.ToString(),
                    Text = $"{x.ApartmentName} no {x.DoorNumber}"
                };
            });
            IEnumerable<SelectListItem> selectInvoiceTypes = _invoiceTypeService.GetAll().Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Name
            });
            ViewData.Add("Houses", selectHouses);
            ViewData.Add("InvoiceTypes", selectInvoiceTypes);
        }
    }
}
