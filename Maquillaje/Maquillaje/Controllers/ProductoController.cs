using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.Entities.Entities;
using Microsoft.AspNetCore.Http;
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

            if (TempData["Script"] is string script)
            {
                TempData.Remove("Script");
                ViewBag.Script = script;
            }

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
            item.prod_UsuCreacion = ViewBag.user_Id = HttpContext.Session.GetInt32("user_Id");
            var insertar = _maquService.InsertProducto(item);

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

        [HttpPost("/Producto/Edit")]
        public IActionResult Edit(VW_maqu_tbProductos_VW item)
        {
            item.prod_UsuModificacion = ViewBag.user_Id = HttpContext.Session.GetInt32("user_Id");
            var editar = _maquService.EditProducto(item);

            if (editar == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido editado con éxito');";
                TempData["Script"] = script;
            }
            else if (editar == 2)
            {
                string script = $"MostrarMensajeWarning('El registro ya existe'); AbrirModalEdit('{item.prod_Id},{item.prod_Nombre},{item.prod_PrecioUni},{item.cate_Id},{item.prov_Id}'," +
                                $"{item.prod_Stock}) ";
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

            var eliminar = _maquService.DeleteProducto(id);

            if (eliminar == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido eliminado con éxito');";
                TempData["Script"] = script;
            }
            else if (eliminar == 2)
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
