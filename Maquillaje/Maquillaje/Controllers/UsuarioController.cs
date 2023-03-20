using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.Entities.Entities;
using Maquillaje.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Controllers
{
    public class UsuarioController: Controller
    {
        private readonly AcceService _acceService;
        private readonly MaquService _maquService;
        private readonly IMapper _mapper;

        public UsuarioController(AcceService aceeService,MaquService maquService, IMapper mapper)
        {
            _acceService = aceeService;
            _maquService = maquService;
            _mapper = mapper;
        }

        [HttpGet("/Usuario/Listado")]
        public IActionResult Index()
        {
            var listado = _acceService.ListadoUsuarios(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<UsuarioViewModel>>(listado).Where(X => X.user_Estado == true);

            var ddlRoles = _acceService.ListadoRoles(out string error1).ToList();
            ViewBag.ddlRoles = new SelectList(ddlRoles, "role_Id", "role_Nombre");

            var ddlEmpleados = _maquService.ListadoEmpleadosView(out string error2).ToList();
            ViewBag.ddlEmpleados = new SelectList(ddlEmpleados, "empe_Id", "NombreCompleto");

            if (TempData["Script"] is string script)
            {
                TempData.Remove("Script");
                ViewBag.Script = script;
            }

            return View(listadoMapeado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UsuarioViewModel item)
        {
            var usuario = _mapper.Map<tbUsuarios>(item);
            var insertar = _acceService.InsertUsuario(usuario);

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

        [HttpPost]
        public IActionResult Edit(tbUsuarios usuarios)
        {
            var result = 0;
            var usuario = _mapper.Map<tbUsuarios>(usuarios);
            result = _acceService.EditUsuario(usuario);

            if (result == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido editado con éxito');";
                TempData["Script"] = script;
            }
            else if (result == 2)
            {
                string script = $"MostrarMensajeWarning('El registro ya existe'); AbrirModalEdit('{usuarios.user_Id},{usuarios.user_EsAdmin},{usuarios.role_Id},{usuarios.empe_Id}') ";
                TempData["Script"] = script;
            }
            else
            {
                string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                TempData["Script"] = script;
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var delete = _acceService.DeleteUsuario(id);

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

        [HttpGet("/Usuario/Details")]
        public IActionResult Details(int id)
        {
            string rol = ViewBag.Rol = HttpContext.Session.GetString("role_Id");
            string admin = ViewBag.Admin = HttpContext.Session.GetString("user_EsAdmin");
            if ((rol != "1") && admin != "True")
            {
                return RedirectToAction("Index", "Home");

            }
            var ddlRoles = _acceService.ListadoRoles(out string error1).ToList();
            ViewBag.ddlRoles = new SelectList(ddlRoles, "role_Id", "role_Nombre");

            var ddlEmpleados = _maquService.ListadoEmpleadosView(out string error2).ToList();
            ViewBag.ddlEmpleados = new SelectList(ddlEmpleados, "empe_Id", "NombreCompleto");
            var listado = _acceService.Details(id);
            var listadoMapeado = _mapper.Map<IEnumerable<VW_acce_tbUsuarios_View>>(listado);

            return View(listadoMapeado);
        }

        public IActionResult RolesPantalla(int role_Id, bool esAdmin, int pant_Id)
        {
            var accesopantalla = _acceService.RolesPantalla(role_Id, esAdmin, pant_Id);
            return Json(accesopantalla);
        }
    }
}
