﻿using System.Collections.Generic;
using AutoMapper;
using Business.Services.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models.InvoiceType;

namespace WebClient.Controllers
{
    public class InvoiceTypeController : Controller
    {
        private readonly IInvoiceTypeService _invoiceTypeService;
        private readonly IMapper _mapper;
        public InvoiceTypeController(IInvoiceTypeService invoiceTypeService, IMapper mapper)
        {
            _invoiceTypeService = invoiceTypeService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var result = _invoiceTypeService.GetAll();
            if (result.Success)
            {
                IEnumerable<GetInvoiceTypesViewModel> obj = _mapper.Map<IEnumerable<GetInvoiceTypesViewModel>>(result.Data);
                return View(obj);
            }
            return View();

        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateInvoiceTypeViewModel createFlatType)
        {
            InvoiceType model = _mapper.Map<InvoiceType>(createFlatType);
            var result = _invoiceTypeService.Create(model);
            TempData["alertType"] = "success";
            TempData["alertMessage"] = result.Message;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var result = _invoiceTypeService.Delete(id);
            if (result.Success)
            {
                TempData["alertType"] = "success";
                TempData["alertMessage"] = result.Message;
                return RedirectToAction("Index");
            }
            TempData["alertType"] = "danger";
            TempData["alertMessage"] = result.Message;

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var result = _invoiceTypeService.GetById(id);
            if (result.Success)
            {
                UpdateInvoiceTypeViewModel model = _mapper.Map<UpdateInvoiceTypeViewModel>(result.Data);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UpdateInvoiceTypeViewModel model)
        {
            InvoiceType mapObj = _mapper.Map<InvoiceType>(model);
            var result = _invoiceTypeService.Update(id, mapObj);
            if (result.Success)
            {
                TempData["alertType"] = "success";
                TempData["alertMessage"] = result.Message;
                return RedirectToAction("Index");
            }
            TempData["alertType"] = "danger";
            TempData["alertMessage"] = result.Message;
            return RedirectToAction("Index");
        }
    }
}
