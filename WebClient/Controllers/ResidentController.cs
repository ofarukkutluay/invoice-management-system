using System.Collections.Generic;
using AutoMapper;
using Business.Services.Abstracts;
using Core.Entities.Concretes;
using Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models.Resident;

namespace WebClient.Controllers
{
    [Authorize(Roles = OperationClaims.Admin)]
    public class ResidentController : BaseController
    {
        private readonly IResidentService _residentService;
        private readonly IMapper _mapper;

        public ResidentController(IResidentService residentService, IMapper mapper)
        {
            _residentService = residentService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var result = _residentService.GetAll();
            var returnObj = _mapper.Map<IEnumerable<GetResidentsViewModel>>(result.Data);
            return View(returnObj);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateResidentViewModel model)
        {
            var resident = _mapper.Map<Resident>(model);
            var result = _residentService.Create(resident);
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
            var result = _residentService.GetById(id);
            if (result.Success)
            {
                var returnObj = _mapper.Map<UpdateResidentViewModel>(result.Data);
                return View(returnObj);
            }
            return BadRequest();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UpdateResidentViewModel model)
        {
            var resident = _mapper.Map<Resident>(model);
            var result = _residentService.Update(id, resident);
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
            var result = _residentService.Delete(id);
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
