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
    public class MunicipioController : Controller
    {

        private readonly GralService _gralService;
        private readonly IMapper _mapper;

        public MunicipioController(GralService gralService, IMapper mapper)
        {
            _gralService = gralService;
            _mapper = mapper;
        }


        [HttpGet("/Municipio/Listado")]
        public IActionResult Index()
        {
            var listado = _gralService.ListadoMunicipios(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<VW_gral_tbMunicipios_VW>>(listado);
            var ddldepartamentos = _gralService.ListadoDepartamentosView(out string error1);

            ViewBag.depa_Id = new SelectList(ddldepartamentos, "depa_Id", "depa_Nombre");

            if (TempData["Script"] is string script)
            {
                TempData.Remove("Script");
                ViewBag.Script = script;
            }

            return View(listadoMapeado);
        }

        [HttpGet("/Municipio/Details")]
        public IActionResult Details(string id)
        {
            var listado = _gralService.ListadoMunicipios(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<VW_gral_tbMunicipios_VW>>(listado).Where(X => X.muni_id == id);
            var ddldepartamentos = _gralService.ListadoDepartamentosView(out string error1);

            ViewBag.depa_Id = new SelectList(ddldepartamentos, "depa_Id", "depa_Nombre");

            return View(listadoMapeado);
        }


        [HttpPost("/Municipio/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VW_gral_tbMunicipios_VW item)
        {
            var insertar = _gralService.InsertarMunicipio(item);

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

        [HttpPost("/Municipio/Edit")]
        public IActionResult Edit(VW_gral_tbMunicipios_VW item)
        {
            var editar = _gralService.EditarMunicipio(item);

            if (editar == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido editado con éxito');";
                TempData["Script"] = script;
            }
            else if (editar == 2)
            {
                string script = $"MostrarMensajeWarning('El registro ya existe'); AbrirModalEdit('{item.muni_id},{item.depa_Id},{item.muni_Nombre}') ";
                TempData["Script"] = script;
            }
            else
            {
                string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                TempData["Script"] = script;
            }

            return RedirectToAction("Index");
        }

        [HttpPost("/Municipio/Delete")]
        public IActionResult Delete(string id)
        {

            var delete = _gralService.EliminarMunicipio(id);

            if (delete == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido eliminado con éxito');";
                TempData["Script"] = script;
            }
            else if (delete == 2)
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
