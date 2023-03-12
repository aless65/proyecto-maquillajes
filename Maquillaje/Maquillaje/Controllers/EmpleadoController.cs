using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.Entities.Entities;
using Maquillaje.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly MaquService _maquService;
        private readonly IMapper _mapper;

        public EmpleadoController(MaquService maquService, IMapper mapper)
        {
            _maquService = maquService;
            _mapper = mapper;
        }

        [HttpGet("/Empleados/Listado")]
        public IActionResult Index()
        {
            var listado = _maquService.ListadoEmpleados(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<EmpleadoViewModel>>(listado);

            if (String.IsNullOrEmpty(error))
                ModelState.AddModelError("", error);

            return View(listadoMapeado);
        }

        [HttpGet("Empleados/Create")]
        public IActionResult Create()
        {
            var prueba = new SelectList(_maquService.GetMunicipios(), "muni_Id", "muni_Nombre"); 
            ViewBag.muni_Id = new SelectList(_maquService.GetMunicipios(), "muni_Id", "muni_Nombre");

            return View();
        }

        [HttpPost("Empleados/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmpleadoViewModel item)
        {
            var empleado = _mapper.Map<tbEmpleados>(item);
            var insertar = _maquService.InsertEmpleado(empleado);

            try
            {
                if (insertar == 1)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
