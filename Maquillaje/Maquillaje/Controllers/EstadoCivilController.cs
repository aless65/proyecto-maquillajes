using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Controllers
{
    public class EstadoCivilController : Controller
    {

        private readonly GralService _gralService;
        private readonly IMapper _mapper;

        public EstadoCivilController(GralService gralService, IMapper mapper)
        {
            _gralService = gralService;
            _mapper = mapper;
        }

        [HttpGet("/EstadoCivil/Listado")]
        public IActionResult Index()
        {
            var listado = _gralService.ListadoEstadosCivilesVista(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<VW_gral_tbEstadosCiviles_VW>>(listado);

            if (TempData["Script"] is string script)
            {
                TempData.Remove("Script");
                ViewBag.Script = script;
            }

            return View(listadoMapeado);
        }

        [HttpGet("/EstadoCivil/Details")]
        public IActionResult Details(int id)
        {
            var listado = _gralService.ListadoEstadosCivilesVista(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<VW_gral_tbEstadosCiviles_VW>>(listado).Where(X => X.estacivi_Id == id);
            return View(listadoMapeado);
        }

        [HttpPost("/EstadoCivil/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VW_gral_tbEstadosCiviles_VW item)
        {

            var insertar = _gralService.InsertarEstadoCivil(item);

            if (insertar == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido insertado con éxito');";
                TempData["Script"] = script;
            }
            else if (insertar == 2)
            {
                string script = "MostrarMensajeWarning('El registro ya existe'); AbrirModalCreate();";
                TempData["Script"] = script;
            }
            else
            {
                string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                TempData["Script"] = script;
            }

            return RedirectToAction("Index");
        }

        [HttpPost("/EstadoCivil/Edit")]
        public IActionResult Edit(VW_gral_tbEstadosCiviles_VW item)
        {

            var Editar = _gralService.EditarEstadoCivil(item);


            if (Editar == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido editado con éxito');";
                TempData["Script"] = script;
            }
            else if (Editar == 2)
            {
                string script = $"MostrarMensajeWarning('El registro ya existe'); AbrirModalEdit('{item.estacivi_Id},{item.estacivi_Nombre}') ";
                TempData["Script"] = script;
            }
            else
            {
                string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                TempData["Script"] = script;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var Eliminar = _gralService.EliminarEstadoCivil(id);

            if (Eliminar == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido eliminado con éxito');";
                TempData["Script"] = script;
            }
            else if (Eliminar == 2)
            {
                string script = $"MostrarMensajeWarning('El registro ya está siendo utilizado');";
                TempData["Script"] = script;
            }
            else
            {
                string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                TempData["Script"] = script;
            }

            return RedirectToAction("Index");
        }
    }
}