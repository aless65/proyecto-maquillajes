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

        [HttpGet("/Municipio/Details")]
        public IActionResult Details(string id)
        {
            var listado = _gralService.ListadoMunicipios(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<VW_gral_tbMunicipios_VW>>(listado).Where(X => X.muni_id == id);
            var ddldepartamentos = _gralService.ListadoDepartamentosView(out string error1);

            ViewBag.depa_Id = new SelectList(ddldepartamentos, "depa_Id", "depa_Nombre");

            return View(listadoMapeado);
        }


        [HttpPost("/Municipio/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VW_gral_tbMunicipios_VW item)
        {
            try
            {
                var insertar = _gralService.InsertarMunicipio(item);
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {

            }

            return RedirectToAction("Index");
        }

        [HttpPost("/Municipio/Edit")]
        public IActionResult Edit(VW_gral_tbMunicipios_VW item)
        {
            try
            {
                var editar = _gralService.EditarMunicipio(item);
                return RedirectToAction("Index");
            }
            catch (Exception error)
            {

            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(string id)
        {
            try
            {
                var editar = _gralService.EliminarMunicipio(id);
                return RedirectToAction("Index");
                if(editar == 0)
                {
                    //Validacion pendiente
                }
            }
            catch (Exception error)
            {

            }

            return RedirectToAction("Index");
        }

    
    }
}
