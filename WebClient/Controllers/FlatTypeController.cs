using AutoMapper;
using Business.Services.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebClient.Models.FlatType;

namespace WebClient.Controllers
{
    public class FlatTypeController : BaseController
    {
        private readonly IFlatTypeService _flatTypeService;
        private readonly IMapper _mapper;
        public FlatTypeController(IFlatTypeService flatTypeService, IMapper mapper)
        {
            _flatTypeService = flatTypeService;
            _mapper = mapper;
        }


        public IActionResult Index()
        {
            var result = _flatTypeService.GetAll();
            if (result.Success)
            {
                IEnumerable<GetFlatTypesViewModel> obj = _mapper.Map<IEnumerable<GetFlatTypesViewModel>>(result.Data);
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
        public IActionResult Create(CreateFlatTypeViewModel createFlatType)
        {
            FlatType model = _mapper.Map<FlatType>(createFlatType);
            var result = _flatTypeService.Create(model);
            SuccessAlert(result.Message);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var result = _flatTypeService.Delete(id);
            if (result.Success)
            {
                SuccessAlert(result.Message);
                return RedirectToAction("Index");
            }

            DangerAlert(result.Message);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var result = _flatTypeService.GetById(id);
            if (result.Success)
            {
                UpdateFlatTypeViewModel model = _mapper.Map<UpdateFlatTypeViewModel>(result.Data);
                return View(model);
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UpdateFlatTypeViewModel model)
        {
            FlatType mapObj = _mapper.Map<FlatType>(model);
            var result = _flatTypeService.Update(id, mapObj);
            if (result.Success)
            {
                SuccessAlert(result.Message);
                return RedirectToAction("Index");
            }
            DangerAlert(result.Message);
            return RedirectToAction("Index");
        }
    }
}
