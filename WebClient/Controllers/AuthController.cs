using System.Diagnostics.Eventing.Reader;
using AutoMapper;
using Business.Services.Abstracts;
using Entities.Dtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models.Auth;

namespace WebClient.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly IMapper _mapper;


        public AuthController(IAuthService authService, IMapper mapper)
        {
            _authService = authService;
            _mapper = mapper;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginPersonViewModel model)
        {
            var loginPerson = _mapper.Map<LoginPersonDto>(model);
            var result = _authService.LoginPerson(loginPerson);
            if (result.Success)
            {
                HttpContext.Session.SetString("Token", result.Data.AccessToken);
                HttpContext.Session.SetString("UserMail",model.Email);
                SuccessAlert(result.Message);
                
                return RedirectToAction("Index","Home");
            }
            DangerAlert(result.Message);
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterPersonViewModel model)
        {
            var registerPerson = _mapper.Map<RegisterPersonDto>(model);
            var result = _authService.RegisterPerson(registerPerson);
            if (result.Success)
            {
                SuccessAlert(result.Message);
                return RedirectToAction("Login");
            }
            DangerAlert(result.Message);
            return View();
        }

        public IActionResult LogOut()
        {
            HttpContext.Session.Remove("Token");
            HttpContext.Session.Remove("UserMail");
            return RedirectToAction("Index","Home");
        }
    }
}
