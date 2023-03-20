﻿using AutoMapper;
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
    public class SucursalController : Controller
    {

        private readonly MaquService _maquService;
        private readonly GralService _gralService;
        private readonly IMapper _mapper;

        public SucursalController(MaquService maquService, GralService gralService, IMapper mapper)
        {
            _maquService = maquService;
            _gralService = gralService;
            _mapper = mapper;
        }

        [HttpGet("/Sucursal/Listado")]
        public IActionResult Index()
        {
            var listado = _maquService.ListadoSucursales();
            var listadoMapeado = _mapper.Map<IEnumerable<VW_maqu_tbSucursales_VW>>(listado);
            var ddlDepartamentos = _gralService.ListadoDepartamento(out string error).ToList();
            ViewBag.depa_Id = new SelectList(ddlDepartamentos, "depa_Id", "depa_Nombre");

            if (TempData["Script"] is string script)
            {
                TempData.Remove("Script");
                ViewBag.Script = script;
            }

            return View(listadoMapeado);
        }

        [HttpGet("/Sucursal/Details")]
        public IActionResult Details(int id)
        {
            var listado = _maquService.ListadoSucursales();
            var listadoMapeado = _mapper.Map<IEnumerable<VW_maqu_tbSucursales_VW>>(listado).Where(X => X.sucu_Id == id);
            var ddlDepartamentos = _gralService.ListadoDepartamento(out string error).ToList();
            ViewBag.depa_Id = new SelectList(ddlDepartamentos, "depa_Id", "depa_Nombre");
            return View(listadoMapeado);
        }


        [HttpPost("/Sucursal/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VW_maqu_tbSucursales_VW item)
        {
            var sucursal = _mapper.Map<VW_maqu_tbSucursales_VW>(item);
            var insertar = _maquService.InsertarSucursal(sucursal);

            var ddlDepartamentos = _gralService.ListadoDepartamento(out string error).ToList();
            ViewBag.depa_Id = new SelectList(ddlDepartamentos, "depa_Id", "depa_Nombre");

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

        [HttpPost("/Sucursal/Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VW_maqu_tbSucursales_VW item)
        {
            var sucursal = _mapper.Map<VW_maqu_tbSucursales_VW>(item);
            var Editar = _maquService.EditarSucursal(sucursal);

            var ddlDepartamentos = _gralService.ListadoDepartamento(out string error).ToList();
            ViewBag.depa_Id = new SelectList(ddlDepartamentos, "depa_Id", "depa_Nombre");

            if (Editar == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido editado con éxito');";
                TempData["Script"] = script;
            }
            else if (Editar == 2)
            {
                string script = $"MostrarMensajeWarning('El registro ya existe'); AbrirModalEdit('{item.sucu_Id},{item.sucu_Descripcion},{item.muni_Id},{item.sucu_DireccionExacta}," +
                                $"{item.depa_Id}') ";
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
            var Delete = _maquService.EliminarSucursal(id);


            if (Delete == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido eliminado con éxito');";
                TempData["Script"] = script;
            }
            else if (Delete == 2)
            {
                string script = $"MostrarMensajeWarning('El registro no se puede eliminar porque está siendo utilizado');";
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
