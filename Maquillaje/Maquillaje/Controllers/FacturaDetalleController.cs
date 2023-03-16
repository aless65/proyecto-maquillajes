using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
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


        public IActionResult Index()
        {
            var listado = _maquService.ListadoFacturasDetalles();
            //var listadoMapeado = _mapper.Map<IEnumerable<FacturaDetalleViewModel>>(listado);

            return PartialView("_IndexDetalles", listado);
        }
    }
}
