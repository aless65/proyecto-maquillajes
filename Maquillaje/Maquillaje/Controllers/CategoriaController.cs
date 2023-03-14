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
    public class CategoriaController : Controller
    {
        private readonly MaquService _maquService;
        private readonly IMapper _mapper;

        public CategoriaController(MaquService maquService, IMapper mapper)
        {
            _maquService = maquService;
            _mapper = mapper;
        }

        [HttpGet("/Categoria/Details")]
        public IActionResult Details(int id)
        {
            var listado = _maquService.CategoriaDetails(id,out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<tbCategorias>>(listado);

            if (String.IsNullOrEmpty(error))
                ModelState.AddModelError("", error);

            return View(listadoMapeado);
        }


        [HttpGet("/Categorias/Listado")]
        public IActionResult Index()
        {
            var listado = _maquService.ListadoCategorias(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<CategoriaViewModel>>(listado);

            if (String.IsNullOrEmpty(error))
                ModelState.AddModelError("", error);

            return View(listadoMapeado);
        }

        [HttpPost("/Categorias/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoriaViewModel item)
        {
            var categoria = _mapper.Map<tbCategorias>(item);
            var insertar = _maquService.InsertCategorias(categoria);

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

        [HttpPost("/Categoria/Edit")]
        public IActionResult Edit(tbCategorias categorias)
        {
            var result = 0;
            var categoria = _mapper.Map<tbCategorias>(categorias);
            result = _maquService.EditCategorias(categoria);

            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var delete = _maquService.DeleteCategoria(id);

            return RedirectToAction("Index");
        }
    }
}
