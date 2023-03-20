 using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.Entities.Entities;
using Maquillaje.WebUI.Models;
using Microsoft.AspNetCore.Http;
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
            var listadoMapeado = _mapper.Map<IEnumerable<CategoriaViewModel>>(listado);

            if (String.IsNullOrEmpty(error))
                ModelState.AddModelError("", error);

            return View(listadoMapeado);
        }


        [HttpGet("/Categorias/Listado")]
        public IActionResult Index()
        {
            var listado = _maquService.ListadoCategorias(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<CategoriaViewModel>>(listado);

            if (TempData["Script"] is string script)
            {
                TempData.Remove("Script");
                ViewBag.Script = script;
            }

            //if (String.IsNullOrEmpty(error))
            //    ModelState.AddModelError("", error);

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
                {
                    string script = $"MostrarMensajeSuccess('El registro ha sido insertado con éxito');";
                    TempData["Script"] = script;
                }
                else if (insertar == 2)
                {
                    string script = "MostrarMensajeWarning('El registro ya existe'); AbrirModalCreate();";
                    TempData["Script"] = script;
                }
                else
                {
                    string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                    TempData["Script"] = script;
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost("/Categoria/Edit")]
        public IActionResult Edit(tbCategorias categorias)
        {
            var result = 0;
            var categoria = _mapper.Map<tbCategorias>(categorias);
            result = _maquService.EditCategorias(categoria);

            if (result == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido editado con éxito');";
                TempData["Script"] = script;
            }
            else if (result == 2)
            {
                string script = $"MostrarMensajeWarning('El registro ya existe'); AbrirModalEdit('{categoria.cate_Id},{categoria.cate_Nombre}');";
                TempData["Script"] = script;
            }
            else
            {
                string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                TempData["Script"] = script;
            }

            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id)
        {
            var delete = _maquService.DeleteCategoria(id);

            if(delete == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido eliminado con éxito');";
                TempData["Script"] = script;
            }
            else if (delete == 2)
            {
                string script = $"MostrarMensajeWarning('No se permite eliminar este registro');";
                TempData["Script"] = script;

            } else
            {
                string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                TempData["Script"] = script;
            }
            return RedirectToAction("Index");
        }
    }
}
