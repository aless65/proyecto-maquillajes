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
    public class ClienteController : Controller
    {
        private readonly MaquService _maquService;
        private readonly IMapper _mapper;

        public ClienteController(MaquService maquService, IMapper mapper)
        {
            _maquService = maquService;
            _mapper = mapper;
        }

        [HttpGet("/Clientes/Listado")]
        public IActionResult Index()
        {
            var listado = _maquService.ListadoClientes(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<ClienteViewModel>>(listado);

            return View(listadoMapeado);
        }
    }
}
