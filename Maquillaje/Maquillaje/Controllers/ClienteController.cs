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

        [HttpGet("/Clientes/Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("/Clientes/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClienteViewModel item)
        {
            var cliente = _mapper.Map<tbClientes>(item);
            var insertar = _maquService.InsertClientes(cliente);

            try
            {
                if (insertar == 1)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("/Clientes/Update{id}")]
        public IActionResult Update(int id)
        {
            return View();
        }


    }
}
