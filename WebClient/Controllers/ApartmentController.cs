using AutoMapper;
using Business.Handlers.ViewModels;
using Business.Services.Abstracts;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebClient.Models;

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
            CreateApartmentVM model = _mapper.Map<CreateApartmentVM>(createApartmentVM);
            var result = _apartmentService.Create(model);
            Console.WriteLine(result.Message);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var result = _apartmentService.Delete(id);
            if (result.Success)
                return RedirectToAction("Index");
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var result = _apartmentService.GetById(id);
            if (result.Success)
            {
                GetApartmentViewModel model = _mapper.Map<GetApartmentViewModel>(result.Data);
                return View(model);
            }
            return View();
        }
    }
}
