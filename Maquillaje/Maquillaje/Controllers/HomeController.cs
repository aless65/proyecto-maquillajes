using AutoMapper;
using Maquillaje.BusinessLogic.Services;
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
            HttpContext.Session.SetString("user_Id", "");
            HttpContext.Session.SetString("user_NombreUsuario", "");
            HttpContext.Session.SetString("user_EsAdmin", "");
            HttpContext.Session.SetString("role_Id", "");
            HttpContext.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
            HttpContext.Response.Headers.Add("Pragma", "no-cache");
            HttpContext.Response.Headers.Add("Expires", "0");

            return RedirectToAction("Index", "Login");
        }

        public IActionResult Index()
        {
            string user_Id = HttpContext.Session.GetString("user_Id");
            if (user_Id == null || user_Id == "")
            {
                HttpContext.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
                HttpContext.Response.Headers.Add("Pragma", "no-cache");
                HttpContext.Response.Headers.Add("Expires", "0");
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewBag.user_Id = HttpContext.Session.GetString("user_Id");
                ViewBag.user_EsAdmin = HttpContext.Session.GetString("user_EsAdmin");
                ViewBag.role_Id = HttpContext.Session.GetString("role_Id");
                HttpContext.Response.Headers.Add("Cache-Control", "no-cache, no-store, must-revalidate");
                HttpContext.Response.Headers.Add("Pragma", "no-cache");
                HttpContext.Response.Headers.Add("Expires", "0");
            }
            return View();
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
