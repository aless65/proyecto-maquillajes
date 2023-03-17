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
    public class ProductoController : Controller
    {
        private readonly MaquService _maquService;
        private readonly IMapper _mapper;

        public ProductoController(MaquService maquService, IMapper mapper)
        {
            _maquService = maquService;
            _mapper = mapper;
        }

        [HttpGet("/Producto/Listado")]
        public IActionResult Index()
        {
            var listado = _maquService.ListadoProductosView();
            var listadoMapeado = _mapper.Map<IEnumerable<VW_maqu_tbProductos_VW>>(listado);
            var ddlcategorias = _maquService.ListadoCategorias(out string error);
            var ddlproveedores = _maquService.ListadoProveedores();

            ViewBag.cate_Id = new SelectList(ddlcategorias, "cate_Id", "cate_Nombre");
            ViewBag.prov_Id = new SelectList(ddlproveedores, "prov_Id", "prov_Nombre");
            return View(listadoMapeado);
        }

        [HttpGet("/Producto/Details")]
        public IActionResult Details(int id)
        {
            var listado = _maquService.ListadoProductosView();
            var listadoMapeado = _mapper.Map<IEnumerable<VW_maqu_tbProductos_VW>>(listado).Where(X => X.prod_Id == id);
            var ddlcategorias = _maquService.ListadoCategorias(out string error);
            var ddlproveedores = _maquService.ListadoProveedores();

            ViewBag.cate_Id = new SelectList(ddlcategorias, "cate_Id", "cate_Nombre");
            ViewBag.prov_Id = new SelectList(ddlproveedores, "prov_Id", "prov_Nombre");
            return View(listadoMapeado);
        }

        [HttpPost("/Producto/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VW_maqu_tbProductos_VW item)
        {
            try
            {
                var insertar = _maquService.InsertProducto(item);
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {

            }

            return RedirectToAction("Index");
        }

        [HttpPost("/Producto/Edit")]
        public IActionResult Edit(VW_maqu_tbProductos_VW item)
        {
            try
            {
                var editar = _maquService.EditProducto(item);
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {

            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                var eliminar = _maquService.DeleteProducto(id);
                return RedirectToAction("Index");
            }
            catch(Exception error)
            {

            }
            return RedirectToAction("Index");
        }
    }
}
