using AutoMapper;
using Business.Services.Abstracts;
using Core.Utilities.Results;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Policy;
using WebClient.Models.Apartment;

namespace WebClient.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly IApartmentService _apartmentService;
        private readonly IMapper _mapper;
        public ApartmentController(IApartmentService apartmentService, IMapper mapper)
        {
            _apartmentService = apartmentService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var result = _apartmentService.GetAll();
            if (result.Success)
            {
                IEnumerable<GetApartmentsViewModel> obj = _mapper.Map<IEnumerable<GetApartmentsViewModel>>(result.Data);
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
        public IActionResult Create(CreateApartmentViewModel createApartmentVM)
        {
            Apartment model = _mapper.Map<Apartment>(createApartmentVM);
            var result = _apartmentService.Create(model);
            TempData["alertType"] = "success";
            TempData["alertMessage"] = result.Message;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var result = _apartmentService.Delete(id);
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
            var result = _apartmentService.GetById(id);
            if (result.Success)
            {
                UpdateApartmentViewModel model = _mapper.Map<UpdateApartmentViewModel>(result.Data);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UpdateApartmentViewModel model)
        {
            Apartment mapObj = _mapper.Map<Apartment>(model);
            var result = _apartmentService.Update(id, mapObj);
            if (result.Success)
            {
                TempData["alertType"] = "success";
                TempData["alertMessage"] = result.Message;
                return RedirectToAction("Index");
            }
            TempData["alertType"] = "danger";
            TempData["alertMessage"] = result.Message;
            return View();
        }
    }
}
