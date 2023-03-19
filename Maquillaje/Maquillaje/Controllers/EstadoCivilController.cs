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
    public class EstadoCivilController : Controller
    {

        private readonly GralService _gralService;
        private readonly IMapper _mapper;

        public EstadoCivilController(GralService gralService, IMapper mapper)
        {
            _gralService = gralService;
            _mapper = mapper;
        }

        [HttpGet("/EstadoCivil/Listado")]
        public IActionResult Index()
        {
            var listado = _gralService.ListadoEstadosCivilesVista(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<VW_gral_tbEstadosCiviles_VW>>(listado);
            return View(listadoMapeado);
        }
    }
}