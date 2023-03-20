using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Controllers
{
    public class LoginController : Controller
    {

        private readonly AcceService _acceService;
        private readonly IMapper _mapper;

        public LoginController(AcceService aceeService, IMapper mapper)
        {
            _acceService = aceeService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string usuario, string contrasena)
        {
            if(usuario != "" && contrasena != "")
            {
                var login = _acceService.Login(usuario, contrasena);

                if (login.Count() > 0)
                {
                    foreach (var item in login)
                    {
                        HttpContext.Session.SetInt32("user_Id", item.user_Id);
                        HttpContext.Session.SetString("user_NombreUsuario",item.user_NombreUsuario);
                        HttpContext.Session.SetString("user_EsAdmin", item.user_EsAdmin.ToString());
                    }
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    ModelState.AddModelError("Validacion", "El usuario o contrasena son incorrectos");
                }
            }
            else
            {
                ModelState.AddModelError("Validacion1", "Rellene los campos");
            }
          
            return View();
        }

        [HttpGet("/Login/Recover")]
        public IActionResult Recover()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Recover(string usuario, string contrasena)
        {
            if (usuario != "" && contrasena != "")
            {
                var login = _acceService.Recover(usuario, contrasena);

                if (login == 1)
                {
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Validacion", "El usuario o contrasena son incorrectos");
                }
            }
            else
            {
                ModelState.AddModelError("Validacion1", "Rellene los campos");
            }

            return View();
        }
    }
}
