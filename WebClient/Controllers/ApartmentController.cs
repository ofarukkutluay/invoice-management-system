using Business.Handlers.ViewModels;
using Business.Services.Abstracts;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace WebClient.Controllers
{
    public class ApartmentController : Controller
    {
        private readonly IApartmentService _apartmentService;
        public ApartmentController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }
        
  
        public IActionResult Index()
        {
            IDataResult<IEnumerable<GetApartmentsVM>> result = _apartmentService.GetAll();
           
            return View(result);
        }


        public IActionResult Create(CreateApartmentVM createApartmentVM)
        {
            if (createApartmentVM.Name == null)
                return View();
            var result = _apartmentService.Create(createApartmentVM);
            Console.WriteLine(result.Message);
            return View();
        }
    }
}
