using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly GralService _gralService;
        private readonly IMapper _mapper;

        public DepartamentoController(GralService gralService, IMapper mapper)
        {
            _gralService = gralService;
            _mapper = mapper;
        }

        [HttpGet("/Departamento/Listado")]
        public IActionResult Index()
        {
            var listado = _gralService.ListadoDepartamentosView(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<VW_gral_tbDepartamentos_VW>>(listado).Where(X => X.depa_Estado == true);

            if (TempData["Script"] is string script)
            {
                TempData.Remove("Script");
                ViewBag.Script = script;
            }

            return View(listadoMapeado);
        }

        [HttpGet("/Departamento/Details")]
        public IActionResult Details(string id)
        {
            var listado = _gralService.ListadoDepartamentosView(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<VW_gral_tbDepartamentos_VW>>(listado).Where(X => X.depa_Id == id);

            return View(listadoMapeado);
        }

        [HttpPost("/Departamento/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VW_gral_tbDepartamentos_VW item)
        {
            try
            {
                item.depa_UsuCreacion = ViewBag.user_Id = HttpContext.Session.GetInt32("user_Id");
                var insertar = _gralService.InsertarDepartamento(item);
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {

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

        [HttpPost("/Departamento/Edit")]
        public IActionResult Edit(VW_gral_tbDepartamentos_VW item)
        {
            try
            {
                item.depa_UsuModificacion = ViewBag.user_Id = HttpContext.Session.GetInt32("user_Id");
                var editar = _gralService.EditarDepartamento(item);
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {

            if (editar == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido editado con éxito');";
                TempData["Script"] = script;
            }
            else if (editar == 2)
            {
                string script = $"MostrarMensajeWarning('El registro ya existe'); AbrirModalEdit('{item.depa_Id},{item.depa_Id},{item.depa_Nombre}') ";
                TempData["Script"] = script;
            }
            else
            {
                string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                TempData["Script"] = script;
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {

            var delete = _gralService.EliminarDepartamento(id);

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
