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
    public class MetodoPagoController : Controller
    {
        private readonly MaquService _maquService;
        private readonly IMapper _mapper;

        public MetodoPagoController(MaquService maquService, IMapper mapper)
        {
            _maquService = maquService;
            _mapper = mapper;
        }

        [HttpGet("/MetodosPago/Listado")]
        public IActionResult Index()
        {
            var listado = _maquService.ListadoMetodosPago();
            var listadoMapeado = _mapper.Map<IEnumerable<MetodoPagoViewModel>>(listado);

            return View(listadoMapeado);
        }

        [HttpPost]
        public IActionResult Create(MetodoPagoViewModel item)
        {
            var metodo = _mapper.Map<tbMetodosPago>(item);
            var insertar = _maquService.InsertMetodosPago(metodo);

            if(insertar == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public IActionResult Update(MetodoPagoViewModel item)
        {
            var metodo = _mapper.Map<tbMetodosPago>(item);
            var update = _maquService.UpdateMetodosPago(metodo);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var delete = _maquService.DeleteMetodosPago(id);

            return RedirectToAction("Index");
        }
    }
}
