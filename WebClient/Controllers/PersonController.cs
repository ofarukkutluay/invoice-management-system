using System;
using System.Linq;
using System.Security.Claims;
using AutoMapper;
using Business.Services.Abstracts;
using Core.Entities.Concretes;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models.Person;

namespace WebClient.Controllers
{
    public class PersonController : BaseController
    {
        private readonly IPersonService _personService;
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;

        public PersonController(IPersonService personService, IAuthService authService, IMapper mapper)
        {
            _personService = personService;
            _authService = authService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var value = HttpContext.User.Claims.FirstOrDefault(x=>x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (value != null)
            {
                int personId = Int32.Parse(value);
                var person = _personService.GetByIdPerson(personId);
                GetPersonViewModel model = _mapper.Map<GetPersonViewModel>(person.Data);
                return View(model);
            }
            return RedirectToAction("Login", "Auth");
        }

        public IActionResult Edit(int id)
        {
            
                var person = _personService.GetByIdPerson(id);
                UpdatePersonViewModel model = _mapper.Map<UpdatePersonViewModel>(person.Data);
                return View(model);
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,UpdatePersonViewModel model)
        {
            Person person = _mapper.Map<Person>(model);
            var result = _personService.Update(id,person);
            SuccessAlert(result.Message);
            return RedirectToAction("Index");
        }
    }
}
