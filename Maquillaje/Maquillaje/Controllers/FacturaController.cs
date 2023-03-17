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
            //var listadoMapeado = _mapper.Map<IEnumerable<VW_tbFacturas_List>>(listado);

            return View(listado);
        }

        //public IActionResult GetFacturaDetalles()
        //{
        //    var detalles = _maquService.ListadoFacturasDetalles().ToList();

        //    ViewBag.FacturaDetalles = detalles;

        //    return PartialView("_IndexDetalles", detalles);
        //}

        [HttpGet("/Facturas/Create")]
        public IActionResult Create(FacturaDetalleViewModel item)
        {
            var ddlCliente = _maquService.ListadoClientes(out string error).ToList();
            var ddlMetodo = _maquService.ListadoMetodosPago().ToList();
            var ddlCategoria = _maquService.ListadoCategorias(out string error1).ToList();
            var detalles = _maquService.ListadoFacturasDetalles(item.fact_Id);

            ViewBag.cate = new SelectList(ddlCategoria, "cate_Id", "cate_Nombre");

            ViewBag.ddlCliente = new SelectList(ddlCliente, "clie_Id", "clie_Nombres");
            ViewBag.ddlMetodo = new SelectList(ddlMetodo, "meto_Id", "meto_Nombre");
            ViewBag.detalles = detalles;



            return View();
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
            ViewBag.ddlCliente = new SelectList(ddlCliente, "clie_Id", "clie_Nombres");
            ViewBag.ddlMetodo = new SelectList(ddlMetodo, "meto_Id", "meto_Nombre");
            ViewBag.detalles = detalles;


            if (insertar != 0)
            {
                ViewBag.fact_Id = insertar;
            }

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateDetalles(FacturaDetalleViewModel item)
        {
            var facturaDetalle = _mapper.Map<tbFacturasDetalles>(item);
            var create = _maquService.InsertFacturasDetalles(facturaDetalle);
            var detalles = _maquService.ListadoFacturasDetalles(item.fact_Id);

            ViewBag.detalles = detalles;

            if (create == 1)
            {
                return RedirectToAction("Create");
            }
            else
            {
                return RedirectToAction("Create");
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

    }
}
