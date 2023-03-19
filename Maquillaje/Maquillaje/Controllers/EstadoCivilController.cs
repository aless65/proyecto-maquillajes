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

        [HttpGet("/EstadoCivil/Details")]
        public IActionResult Details(int id)
        {
            var listado = _gralService.ListadoEstadosCivilesVista(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<VW_gral_tbEstadosCiviles_VW>>(listado).Where(X => X.estacivi_Id == id);
            return View(listadoMapeado);
        }

        [HttpPost("/EstadoCivil/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VW_gral_tbEstadosCiviles_VW item)
        {
            try
            {
                var insertar = _gralService.InsertarEstadoCivil(item);
                if(insertar == 0)
                {
                    //Validacion Pendiente
                }
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {

            }

            return RedirectToAction("Index");
        }

        [HttpPost("/EstadoCivil/Edit")]
        public IActionResult Edit(VW_gral_tbEstadosCiviles_VW item)
        {
            try
            {
                var Editar = _gralService.EditarEstadoCivil(item);
                if (Editar == 0)
                {
                    //Validacion Pendiente
                }
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {

            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            try
            {
                var Eliminar = _gralService.EliminarEstadoCivil(id);
                if (Eliminar == 0)
                {
                    //Validacion Pendiente
                }
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {

            }
            return RedirectToAction("Index");
        }
    }
}