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
            var listado = _maquService.ListadoDepartamento(out string error).ToList();
            var seleccioneUnaOpcion = new tbDepartamentos { depa_Id = "0000", depa_Nombre = "--Seleccioene un Departamento--" };
            listado.Insert(0, seleccioneUnaOpcion);
            ViewBag.depa_Id = new SelectList(listado, "depa_Id", "depa_Nombre");

            var listadoEstadosCiviles = _maquService.ListadoEstadosCiviles(out string error1).ToList();
            ViewBag.estacivi_Id = new SelectList(listadoEstadosCiviles, "estacivi_Id", "estacivi_Nombre");
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

        public IActionResult CargarMunicipios(string id)
        {
            var cargarmunicipios = _maquService.GetMunicipiosPorDepartamento(id);
            return Json(cargarmunicipios);
        }
    }
}
