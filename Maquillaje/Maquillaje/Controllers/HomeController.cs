using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.Entities.Entities;
using Maquillaje.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AcceService _acceService;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger,AcceService aceeService, IMapper mapper)
        {
            _logger = logger;
            _acceService = aceeService;
            _mapper = mapper;
        }

        public IActionResult Logout()
        {
            HttpContext.Session.SetInt32("user_Id", 0);
            HttpContext.Session.SetString("user_NombreUsuario", "");
            HttpContext.Session.SetString("user_EsAdmin", "");
            HttpContext.Session.SetString("role_Id", "");
            HttpContext.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Response.Headers.Add("Pragma", "no-cache");
            HttpContext.Response.Headers.Add("Expires", "0");

            return RedirectToAction("Index", "Login");
        }

        public IActionResult Index(tbPantallas item)
        {
            string user_Id = HttpContext.Session.GetString("user_Id");
            if (user_Id == null || user_Id == "")
            {
                HttpContext.Session.SetInt32("user_Id", 0);
                HttpContext.Session.SetString("user_NombreUsuario", "");
                HttpContext.Session.SetString("user_EsAdmin", "");
                HttpContext.Session.SetInt32("role_Id", 0);
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.user_Id = HttpContext.Session.GetInt32("user_Id");
                ViewBag.user_EsAdmin = HttpContext.Session.GetString("user_EsAdmin");
                ViewBag.role_Id = HttpContext.Session.GetInt32("role_Id");
                ViewBag.username = HttpContext.Session.GetString("user_NombreUsuario");
                try
                {
                    item.role_Id = ViewBag.role_Id;
                    item.esAdmin = Convert.ToBoolean(ViewBag.user_EsAdmin);
                }
                catch
                {
                    return RedirectToAction("Index", "Login");
                }
                HttpContext.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
                HttpContext.Response.Headers.Add("Pragma", "no-cache");
                HttpContext.Response.Headers.Add("Expires", "0");
            }
            return View();
        }

        public IActionResult PantallasMenu(tbPantallas item)
        {
            item.role_Id = (int)HttpContext.Session.GetInt32("role_Id");
            item.esAdmin = Convert.ToBoolean(HttpContext.Session.GetString("user_EsAdmin"));

            var pantallas = _acceService.PantallasMenu(item);

            return Json(pantallas);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
