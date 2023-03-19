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
    public class SucursalController : Controller
    {

        private readonly MaquService _maquService;
        private readonly IMapper _mapper;

        public SucursalController(MaquService maquService, IMapper mapper)
        {
            _maquService = maquService;
            _mapper = mapper;
        }

        [HttpGet("/Sucursal/Listado")]
        public IActionResult Index()
        {
            var listado = _maquService.ListadoSucursales();
            var listadoMapeado = _mapper.Map<IEnumerable<VW_maqu_tbSucursales_VW>>(listado);

            return View(listadoMapeado);
        }
    }
}
