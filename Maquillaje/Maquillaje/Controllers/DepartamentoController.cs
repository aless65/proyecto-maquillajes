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
    public class DepartamentoController : Controller
    {
        private readonly GralService _gralService;
        private readonly IMapper _mapper;

        public DepartamentoController(GralService gralService, IMapper mapper)
        {
            _gralService = gralService;
            _mapper = mapper;
        }

        [HttpGet("/Departamento/Listado")]
        public IActionResult Index()
        {
            var listado = _gralService.ListadoDepartamentosView(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<VW_gral_tbDepartamentos_VW>>(listado);

            return View(listadoMapeado);
        }
    }
}
