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
    public class MunicipioController : Controller
    {

        private readonly GralService _gralService;
        private readonly IMapper _mapper;

        public MunicipioController(GralService gralService, IMapper mapper)
        {
            _gralService = gralService;
            _mapper = mapper;
        }


        [HttpGet("/Municipio/Listado")]
        public IActionResult Index()
        {
            var listado = _gralService.ListadoMunicipios(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<VW_gral_tbMunicipios_VW>>(listado);
            var ddldepartamentos = _gralService.ListadoDepartamentosView(out string error1);

            ViewBag.depa_Id = new SelectList(ddldepartamentos, "depa_Id", "depa_Nombre");
            
            return View(listadoMapeado);
        }
    }
}
