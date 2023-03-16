using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.Entities.Entities;
using Maquillaje.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetFacturaDetalles()
        {
            var detalles = _maquService.ListadoFacturasDetalles().ToList();

            ViewBag.FacturaDetalles = detalles;

            return PartialView("_IndexDetalles", detalles);
        }

        [HttpGet("/Facturas/Create")]
        public IActionResult Create()
        {
            return View();
        }
    }
}
