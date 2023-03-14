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
    public class UsuarioController: Controller
    {
        private readonly MaquService _maquService;
        private readonly IMapper _mapper;

        public UsuarioController(MaquService maquService, IMapper mapper)
        {
            _maquService = maquService;
            _mapper = mapper;
        }

        [HttpGet("/Usuario/Listado")]
        public IActionResult Index()
        {
            var listado = _maquService.ListadoUsuarios(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<UsuarioViewModel>>(listado);

            if (String.IsNullOrEmpty(error))
                ModelState.AddModelError("", error);

            return View(listadoMapeado);
        }
    }
}
