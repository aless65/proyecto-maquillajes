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
            var listadoMapeado = _mapper.Map<IEnumerable<UsuarioViewModel>>(listado);

            var ddlRoles = _acceService.ListadoRoles(out string error1).ToList();
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
            var insertar = _acceService.InsertUsuario(usuario);

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

        [HttpPost]
        public IActionResult Edit(tbUsuarios usuarios)
        {
            var result = 0;
            var usuario = _mapper.Map<tbUsuarios>(usuarios);
            result = _maquService.EditCategorias(usuario);

            return RedirectToAction("Index");

        }


    }
}
