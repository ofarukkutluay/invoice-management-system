using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Services.Abstracts;
using Core.Entities.Concretes;
using Entities.Concretes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebClient.Models.Resident;

namespace WebClient.Controllers
{
    [Authorize(Roles = OperationClaims.Admin)]
    public class ResidentController : BaseController
    {
        private readonly IResidentService _residentService;
        private readonly IPersonService _personService;
        private readonly IHouseService _houseService;
        private readonly IMapper _mapper;

        public ResidentController(IResidentService residentService, IPersonService personService, IHouseService houseService, IMapper mapper)
        {
            _residentService = residentService;
            _personService = personService;
            _houseService = houseService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var result = _residentService.GetAllDetails();
            var returnObj = _mapper.Map<IEnumerable<GetResidentsViewModel>>(result.Data);
            return View(returnObj);
        }

        public IActionResult Create()
        {
            SelectItemInitialize();
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
            SelectItemInitialize();
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

        private void SelectItemInitialize()
        {
            IEnumerable<SelectListItem> selectApartments = _houseService.GetAllHouseDetail().Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = $"{x.ApartmentName} no: {x.DoorNumber}"
            });
            IEnumerable<SelectListItem> selectPersons = _personService.GetAllPerson().Data.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.FullName
            });

            ViewData.Add("Houses", selectApartments);
            ViewData.Add("Persons", selectPersons);
        }
    }
}
