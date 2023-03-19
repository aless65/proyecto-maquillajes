using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Controllers
{
    public class ProveedorController : Controller
    {

        private readonly MaquService _maquService;
        private readonly IMapper _mapper;

        public ProveedorController(MaquService maquService, IMapper mapper)
        {
            _maquService = maquService;
            _mapper = mapper;
        }

        [HttpGet("/Proveedor/Listado")]
        public IActionResult Index()
        {
            var listado = _maquService.ListadoProveedores();
            var listadoMapeado = _mapper.Map<IEnumerable<VW_maqu_tbProveedores_VW>>(listado);

            if (TempData["Script"] is string script)
            {
                TempData.Remove("Script");
                ViewBag.Script = script;
            }

            return View(listadoMapeado);
        }

        [HttpGet("/Proveedor/Details")]
        public IActionResult Details(int id)
        {
            var listado = _maquService.ListadoProveedores();
            var listadoMapeado = _mapper.Map<IEnumerable<VW_maqu_tbProveedores_VW>>(listado).Where(X => X.prov_Id == id);

            return View(listadoMapeado);
        }

        [HttpPost("/Proveedor/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VW_maqu_tbProveedores_VW item)
        {
            var proveedor = _mapper.Map<VW_maqu_tbProveedores_VW>(item);
            var insertar = _maquService.InsertarProveedor(proveedor);

            if (insertar == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido insertado con éxito');";
                TempData["Script"] = script;
            }
            else if(insertar == 2)
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

        [HttpPost("/Proveedor/Edit")]
        public IActionResult Edit(VW_maqu_tbProveedores_VW item)
        {

            var editar = _maquService.EditarProveedor(item);

            if (editar == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido editado con éxito');";
                TempData["Script"] = script;
            }
            else if (editar == 2)
            {
                string script = $"MostrarMensajeWarning('El registro ya existe'); AbrirModalEdit('{item.prov_Id},{item.prov_Nombre},{item.prov_CorreoElectronico},{item.prov_Telefono}," +
                                $"{item.prov_Telefono}') ";
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
            var delete = _maquService.DeleteProveedor(id);

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
