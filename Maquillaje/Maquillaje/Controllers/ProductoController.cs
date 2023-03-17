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
            return View(listadoMapeado);
        }
    }
}
