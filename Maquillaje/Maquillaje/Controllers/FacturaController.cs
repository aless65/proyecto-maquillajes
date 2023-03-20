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
    public class FacturaController : Controller
    {
        private readonly MaquService _maquService;
        private readonly IMapper _mapper;

        public FacturaController(MaquService maquService, IMapper mapper)
        {
            _maquService = maquService;
            _mapper = mapper;
        }

        [HttpGet("/Facturas/Listado")]
        public IActionResult Index()
        {

            var listado = _maquService.ListadoFacturas();

            if (TempData["Script"] is string script)
            {
                TempData.Remove("Script");
                ViewBag.Script = script;
            }

            return View(listado);
        }

        //public IActionResult GetFacturaDetalles()
        //{
        //    var detalles = _maquService.ListadoFacturasDetalles().ToList();

        //    ViewBag.FacturaDetalles = detalles;

        //    return PartialView("_IndexDetalles", detalles);
        //}

        [HttpGet("/Facturas/Create")]
        public IActionResult Create(FacturaDetalleViewModel item, FacturaViewModel item2)
        {
            var ddlCliente = _maquService.ListadoClientes(out string error).ToList();
            var ddlMetodo = _maquService.ListadoMetodosPago().ToList();
            var ddlCategoria = _maquService.ListadoCategorias(out string error1).ToList();
            var detalles = _maquService.ListadoFacturasDetalles(item.fact_Id);

            ViewBag.cate = new SelectList(ddlCategoria, "cate_Id", "cate_Nombre");

            ViewBag.clie_Id = new SelectList(ddlCliente, "clie_Id", "clie_Nombres");
            ViewBag.meto_Id = new SelectList(ddlMetodo, "meto_Id", "meto_Nombre");
            ViewBag.detalles = detalles;
            ViewBag.fact_Id = item.fact_Id;
            ViewBag.esEditar = false;

            if (TempData["Script"] is string script)
            {
                TempData.Remove("Script");
                ViewBag.Script = script;
            }

            return View(item2);
        }


        [HttpPost("/Facturas/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FacturaViewModel item, int prod_Id)
        {
            var factura = _mapper.Map<tbFacturas>(item);
            var insertar = _maquService.InsertFacturas(factura);

            var ddlCliente = _maquService.ListadoClientes(out string error).ToList();
            var ddlMetodo = _maquService.ListadoMetodosPago().ToList();
            var ddlCategoria = _maquService.ListadoCategorias(out string error1).ToList();
            var detalles = _maquService.ListadoFacturasDetalles(item.fact_Id);


            ViewBag.cate = new SelectList(ddlCategoria, "cate_Id", "cate_Nombre");
            ViewBag.clie_Id = new SelectList(ddlCliente, "clie_Id", "clie_Nombres");
            ViewBag.meto_Id = new SelectList(ddlMetodo, "meto_Id", "meto_Nombre");
            ViewBag.detalles = detalles;
            ViewBag.esEditar = false;

            if (insertar != 0)
            {
                ViewBag.fact_Id = insertar;
            }
            else
            {
                string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                TempData["Script"] = script;
            }

            return View(item);
        }


        [HttpGet("/Facturas/Update")]
        public IActionResult Update(int id)
        {
            var factura = _maquService.ObtenerIDFactura(id);

            if(factura == null)
            {
                return RedirectToAction("Index");
            }

            if (TempData["Script"] is string script)
            {
                TempData.Remove("Script");
                ViewBag.Script = script;
            }

            var ddlCliente = _maquService.ListadoClientes(out string error).ToList();
            var ddlMetodo = _maquService.ListadoMetodosPago().ToList();
            var ddlCategoria = _maquService.ListadoCategorias(out string error1).ToList();
            var detalles = _maquService.ListadoFacturasDetalles(id);

            ViewBag.cate = new SelectList(ddlCategoria, "cate_Id", "cate_Nombre");
            ViewBag.clie_Id = new SelectList(ddlCliente, "clie_Id", $"clie_Nombres");
            ViewBag.meto_Id = new SelectList(ddlMetodo, "meto_Id", "meto_Nombre");
            ViewBag.detalles = detalles;
            ViewBag.fact_Id = id;

            return View(factura);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDetalles(FacturaDetalleViewModel item, FacturaViewModel item2, tbFacturas factura)
        {
            if(item.fact_Id < 1)
            {
                string script = "MostrarMensajeDanger('No se ha encontrado la factura');";
                TempData["Script"] = script;
                return RedirectToAction("Index");
            }

            var facturaDetalle = _mapper.Map<tbFacturasDetalles>(item);
            var create = _maquService.InsertFacturasDetalles(facturaDetalle);
            var detalles = _maquService.ListadoFacturasDetalles(item.fact_Id);
            var ddlCliente = _maquService.ListadoClientes(out string error).ToList();
            var ddlMetodo = _maquService.ListadoMetodosPago().ToList();
            var ddlCategoria = _maquService.ListadoCategorias(out string error1).ToList();

            ViewBag.cate = new SelectList(ddlCategoria, "cate_Id", "cate_Nombre");
            ViewBag.fact_Id = item.fact_Id;
            ViewBag.detalles = detalles;
            ViewBag.clie_Id = new SelectList(ddlCliente, "clie_Id", $"clie_Nombres");
            ViewBag.meto_Id = new SelectList(ddlMetodo, "meto_Id", "meto_Nombre");

            if(item.esEditar == "no")
            {
                if (create == 1)
                {
                    return RedirectToAction("Create", item);
                }
                else
                {
                    return RedirectToAction("Create", item);
                }
            }
            else
            {
                if (create == 1)
                {
                    return RedirectToAction("Update", new { id = ViewBag.fact_Id });
                }
                else
                {
                    return RedirectToAction("Update", new { id = ViewBag.fact_Id });
                }
            }
        }

        [HttpPost]
        public IActionResult Delete(int id, int idFactura, string esEditar2, FacturaDetalleViewModel item, FacturaViewModel item2)
        {
            var delete = _maquService.DeleteFacturasDetalles(id);
            var detalles = _maquService.ListadoFacturasDetalles(idFactura);

            ViewBag.detalles = detalles; 
            ViewBag.fact_Id = idFactura;
            item2.fact_Id = idFactura;

            if(esEditar2 == "no")
            {
                if (delete == 1)
                {
                    string script = $"MostrarMensajeSuccess('El registro ha sido eliminado con éxito');";
                    TempData["Script"] = script;
                    return RedirectToAction("Create", item2);
                }
                else
                {
                    string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                    TempData["Script"] = script;
                    return RedirectToAction("Create", item2);
                }
            }
            else
            {
                if (delete == 1)
                {
                    string script = $"MostrarMensajeSuccess('El registro ha sido eliminado con éxito');";
                    TempData["Script"] = script;
                    return RedirectToAction("Update", new { id = ViewBag.fact_Id });
                }
                else
                {
                    string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                    TempData["Script"] = script;
                    return RedirectToAction("Update", new { id = ViewBag.fact_Id });
                }
            }
        }

        [HttpPost]
        public IActionResult Edit(FacturaDetalleViewModel item)
        {
            var facdetalle = _mapper.Map<tbFacturasDetalles>(item);
            var update = _maquService.UpdateFacturasDetalles(facdetalle);
            var ddlCategoria = _maquService.ListadoCategorias(out string error1).ToList();
            var detalles = _maquService.ListadoFacturasDetalles(item.fact_Id);

            ViewBag.fact_Id = item.fact_Id;
            ViewBag.detalles = detalles;
            ViewBag.cate = new SelectList(ddlCategoria, "cate_Id", "cate_Nombre");

            if(item.esEditar == "no")
            {
                if (update == 1)
                {
                    string script = $"MostrarMensajeSuccess('El registro ha sido editado con éxito');";
                    TempData["Script"] = script;
                    return RedirectToAction("Create", item);
                }
                else
                {
                    return RedirectToAction("Create", item);
                }
            }
            else
            {
                if (update == 1)
                {
                    string script = $"MostrarMensajeSuccess('El registro ha sido editado con éxito');";
                    TempData["Script"] = script;
                    return RedirectToAction("Update", new { id = ViewBag.fact_Id }); 
                }
                else
                {
                    string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                    TempData["Script"] = script;
                    return RedirectToAction("Update", new { id = ViewBag.fact_Id });
                }
            }
        }

        [HttpGet("/Factura/Details")]
        public IActionResult Details(int id)
        {
            var listado = _maquService.ListadoFacturas();
            var listadoMapeado = _mapper.Map<IEnumerable<VW_tbFacturas_List>>(listado).Where(X => X.fact_Id == id);

            //var ddldepartamentos = _gralService.ListadoDepartamentosView(out string error1);

            //ViewBag.depa_Id = new SelectList(ddldepartamentos, "depa_Id", "depa_Nombre");

            if (id < 1)
            {
                string script = $"MostrarMensajeDanger('No se ha encontrado esta factura');";
                TempData["Script"] = script;
                return RedirectToAction("Index");
            }
            else
            {
                return View(listadoMapeado);
            }
        }

        public IActionResult CargarProductos(int id)
        {
            var productos = _maquService.ListadoProductos(id);
            return Json(productos);
        }

        public IActionResult PrecioProductos(int id)
        {
            var precio = _maquService.PrecioProducto(id);
            return Json(precio);
        }

        public IActionResult RevisarStock(int id, int cantidad)
        {
            var stock = _maquService.RevisarStock(id, cantidad);
            return Json(stock);
        }
    }
}
