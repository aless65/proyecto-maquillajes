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
    public class UsuarioController: Controller
    {
        private readonly MaquService _maquService;
        private readonly IMapper _mapper;

        public UsuarioController(MaquService maquService, IMapper mapper)
        {
            _maquService = maquService;
            _mapper = mapper;
        }

        [HttpGet("/Usuario/Listado")]
        public IActionResult Index()
        {
            var listado = _maquService.ListadoUsuarios(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<UsuarioViewModel>>(listado);

            var ddlRoles = _maquService.ListadoRoles(out string error1).ToList();
            ViewBag.ddlRoles = new SelectList(ddlRoles, "role_Id", "role_Nombre");

            var ddlEmpleados = _maquService.ListadoEmpleadosView(out string error2).ToList();
            ViewBag.ddlEmpleados = new SelectList(ddlEmpleados, "empe_Id", "NombreCompleto");
            if (String.IsNullOrEmpty(error))
                ModelState.AddModelError("", error);

            return View(listadoMapeado);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UsuarioViewModel item)
        {
            var usuario = _mapper.Map<tbUsuarios>(item);
            var insertar = _maquService.InsertUsuario(usuario);

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
