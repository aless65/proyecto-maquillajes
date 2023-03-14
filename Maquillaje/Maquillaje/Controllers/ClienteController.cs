using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.Entities.Entities;
using Maquillaje.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var listado = _maquService.ListadoDepartamento(out string error).ToList();
            ViewBag.depa_Id = new SelectList(listado, "depa_Id", "depa_Nombre");
            return View();
        }

        [HttpPost("/Clientes/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClienteViewModel item)
        {
            var listado = _maquService.ListadoDepartamento(out string error).ToList();
            ViewBag.depa_Id = new SelectList(listado, "depa_Id", "depa_Nombre");

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

        [HttpGet("/Clientes/Update")]
        public IActionResult Update(int id)
        {
            var cliente = _maquService.ObtenerIDCliente(id);

            var listadoDepa = _maquService.ListadoDepartamento(out string error).ToList();
            ViewBag.depa_Id = new SelectList(listadoDepa, "depa_Id", "depa_Nombre");

            return View(cliente);
        }

        [HttpPost("/Clientes/Update")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(tbClientes item)
        {
            var update = _maquService.UpdateClientes(item);

            var listadoDepa = _maquService.ListadoDepartamento(out string error).ToList();
            ViewBag.depa_Id = new SelectList(listadoDepa, "depa_Id", "depa_Nombre");

            if(update == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.depa_Id = new SelectList(listadoDepa, "depa_Id", "depa_Nombre", item.depa_Id);
                return View(item);
            }
        }

        public IActionResult Delete(int id)
        {
            var delete = _maquService.DeleteCliente(id);

            return RedirectToAction("Index");
        }

        public IActionResult CargarMunicipios(string id)
        {
            var cargarmunicipios = _maquService.GetMunicipiosPorDepartamento(id);
            return Json(cargarmunicipios);
        }

        public IActionResult CargarMunicipiosCliente(int id)
        {
            var cargarmunicipioselected = _maquService.UpdateClientesMuniDDL(id);
            return Json(cargarmunicipioselected);
        }
    }
}
