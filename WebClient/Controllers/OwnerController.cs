using System.Collections.Generic;
using AutoMapper;
using Business.Services.Abstracts;
using Entities.Concretes;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models.Owner;

namespace WebClient.Controllers
{
    public class OwnerController : BaseController
    {
        private readonly IOwnerService _ownerService;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerService ownerService, IMapper mapper)
        {
            _ownerService = ownerService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var result = _ownerService.GetAll();
            var returnObj = _mapper.Map<IEnumerable<GetOwnersViewModel>>(result.Data);
            return View(returnObj);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateOwnerViewModel model)
        {
            var owner = _mapper.Map<Owner>(model);
            var result = _ownerService.Create(owner);
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
            var result = _ownerService.GetById(id);
            if (result.Success)
            {
                var returnObj = _mapper.Map<UpdateOwnerViewModel>(result.Data);
                return View(returnObj);
            }
            return BadRequest();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,UpdateOwnerViewModel model)
        {
            var owner = _mapper.Map<Owner>(model);
            var result = _ownerService.Update(id,owner);
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
            var result = _ownerService.Delete(id);
            if (result.Success)
            {
                SuccessAlert(result.Message);
                return RedirectToAction("Index");
            }
            DangerAlert(result.Message);
            return BadRequest();
        }

    }
}
