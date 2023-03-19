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
            var ddlmunicipios = _gralService.ListadoMunicipios(out string error);

            ViewBag.muni_Id = new SelectList(ddlmunicipios, "muni_id", "muni_Nombre");
            return View(listadoMapeado);
        }

        [HttpGet("/Sucursal/Details")]
        public IActionResult Details(int id)
        {
            var listado = _maquService.ListadoSucursales();
            var listadoMapeado = _mapper.Map<IEnumerable<VW_maqu_tbSucursales_VW>>(listado).Where(X => X.sucu_Id == id);
            var ddlmunicipios = _gralService.ListadoMunicipios(out string error);

            ViewBag.muni_Id = new SelectList(ddlmunicipios, "muni_id", "muni_Nombre");
            return View(listadoMapeado);
        }


        [HttpPost("/Sucursal/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VW_maqu_tbSucursales_VW item)
        {
            var sucursal = _mapper.Map<VW_maqu_tbSucursales_VW>(item);
            var insertar = _maquService.InsertarSucursal(sucursal);

            try
            {
                if (insertar == 1)
                    return RedirectToAction("Index");
            }
            catch
            {

            }
            return RedirectToAction("Index");
        }

        [HttpPost("/Sucursal/Edit")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VW_maqu_tbSucursales_VW item)
        {
            var sucursal = _mapper.Map<VW_maqu_tbSucursales_VW>(item);
            var Editar = _maquService.EditarSucursal(sucursal);

            try
            {
                if (Editar == 1)
                    return RedirectToAction("Index");
            }
            catch
            {

            }
            return RedirectToAction("Index");
        }

        
        public IActionResult Delete(int id)
        {
            var Delete = _maquService.EliminarSucursal(id);

            try
            {
                if (Delete == 1)
                    return RedirectToAction("Index");
            }
            catch
            {
            }
            return RedirectToAction("Index");
        }
    }
}
