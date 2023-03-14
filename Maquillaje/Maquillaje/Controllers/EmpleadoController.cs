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

            ViewBag.depa_Id = new SelectList(listado, "depa_Id", "depa_Nombre");

            var listadoEstadosCiviles = _maquService.ListadoEstadosCiviles(out string error1).ToList();
            ViewBag.estacivi_Id = new SelectList(listadoEstadosCiviles, "estacivi_Id", "estacivi_Nombre");
            return View();
        }

        [HttpPost("/Empleados/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmpleadoViewModel item)
        {

            var listado = _maquService.ListadoDepartamento(out string error).ToList();

            ViewBag.depa_Id = new SelectList(listado, "depa_Id", "depa_Nombre");

            var listadoEstadosCiviles = _maquService.ListadoEstadosCiviles(out string error1).ToList();
            ViewBag.estacivi_Id = new SelectList(listadoEstadosCiviles, "estacivi_Id", "estacivi_Nombre");

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

        [HttpGet("/Empleados/Update")]
        public IActionResult Update(int id)
        {
            var listado = _maquService.ObtenerIDEmpleado(id);

            var listadoEstadosCiviles = _maquService.ListadoEstadosCiviles(out string error1).ToList();
            ViewBag.estacivi_Id = new SelectList(listadoEstadosCiviles, "estacivi_Id", "estacivi_Nombre");

            var listadoDepa = _maquService.ListadoDepartamento(out string error).ToList();
            ViewBag.depa_Id = new SelectList(listadoDepa, "depa_Id", "depa_Nombre");

            if (listado != null)
            {
                return View(listado);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


        [HttpPost("/Empleados/Update")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(tbEmpleados item)
        {
            var update = _maquService.UpdateEmpelado(item);

            var listadoEstadosCiviles = _maquService.ListadoEstadosCiviles(out string error1).ToList();
            ViewBag.estacivi_Id = new SelectList(listadoEstadosCiviles, "estacivi_Id", "estacivi_Nombre");

            var listadoDepa = _maquService.ListadoDepartamento(out string error).ToList();
            ViewBag.depa_Id = new SelectList(listadoDepa, "depa_Id", "depa_Nombre");

            if (update == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }

        public IActionResult Delete(int id)
        {
            var delete = _maquService.DeleteEmpleado(id);

            if (delete == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult CargarMunicipios(string id)
        {
            var cargarmunicipios = _maquService.GetMunicipiosPorDepartamento(id);
            return Json(cargarmunicipios);
        }

        public IActionResult CargarMunicipiosEmpleado(int id)
        {
            var cargarmunicipioselected = _maquService.UpdateEmpleadosMuniDDL(id);
            return Json(cargarmunicipioselected);
        }
    }
}
