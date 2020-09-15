using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO.ViewModels;
using BLL.Services;
using DataAccessLayer.Contexts;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace DataEncryptor.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserContext _userContext;
        private readonly IMapper _mapper;

        public AccountController(UserContext userContext, IMapper mapper)
        {
            _userContext = userContext;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)//Переписать контроллер в сервисы
        {
            if (ModelState.IsValid)
            {
                var user = _userContext.Users.FirstOrDefault(u => u.Email == loginModel.Email && u.Password == loginModel.Password);
                if (user!=null)
                {
                    await Authenticate(loginModel.Email);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль.");
            }
            return View(loginModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userContext.Users.FirstOrDefault(r => r.Email == registerModel.Email);
                if (user==null)
                {
                    var newRegisterModel = 
                        _mapper.Map<DataUser>(
                            new UserDTO 
                            { 
                                Email = registerModel.Email, 
                                Password = registerModel.Password 
                            });

                    _userContext.Users.Add(newRegisterModel);
                    await _userContext.SaveChangesAsync();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                }
                
            }
            return View(registerModel);
        }


        public async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultIssuer, userName)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }


    }
}
