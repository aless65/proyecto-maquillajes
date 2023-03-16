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
    public class FacturaDetalleController : Controller
    {
        private readonly MaquService _maquService;
        private readonly IMapper _mapper;

        public FacturaDetalleController(MaquService maquService, IMapper mapper)
        {
            _maquService = maquService;
            _mapper = mapper;
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    var listado = _maquService.ListadoFacturasDetalles();
        //    //var listadoMapeado = _mapper.Map<IEnumerable<FacturaDetalleViewModel>>(listado);

        //    return PartialView("Index", listado);
        //}

        //[HttpPost]
        //public IActionResult Create()
        //{
        //    var ddlCategoria = _maquService.ListadoCategorias(out string error).ToList();

        //    ViewBag.cate = new SelectList(ddlCategoria, "cate_Id", "cate_Nombre");

        //    return PartialView();
        //}
    }
}
