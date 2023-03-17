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

        [HttpPost("/Proveedor/Edit")]
        public IActionResult Edit(VW_maqu_tbProveedores_VW item)
        {
            try
            {
                var editar = _maquService.EditarProveedor(item);
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {

            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var delete = _maquService.DeleteProveedor(id);

            return RedirectToAction("Index");
        }
    }
}
