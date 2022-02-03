using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Services.Abstracts;
using Core.Entities.Concretes;
using Entities.Concretes;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebClient.Models.Owner;

namespace WebClient.Controllers
{
    [Authorize(Roles = OperationClaims.Admin)]
    public class OwnerController : BaseController
    {
        private readonly IOwnerService _ownerService;
        private readonly IPersonService _personService;
        private readonly IHouseService _houseService;
        private readonly IMapper _mapper;

        public OwnerController(IOwnerService ownerService, IPersonService personService, IHouseService houseService, IMapper mapper)
        {
            _ownerService = ownerService;
            _personService = personService;
            _houseService = houseService;
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
            SelectItemInitialize();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateOwnerViewModel model)
        {
            Owner owner = _mapper.Map<Owner>(model);

            var result = _ownerService.Create(owner);
            if (result.Success)
            {
                SuccessAlert(result.Message);
                return RedirectToAction("Index");
            }

            DangerAlert(result.Message);
            return RedirectToAction("Create");
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
