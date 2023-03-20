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
            var listado = _maquService.CategoriaDetails(id,out string error).Where(X => X.cate_Id == id);

            if (String.IsNullOrEmpty(error))
                ModelState.AddModelError("", error);
         
            return View(listado);
        }


        [HttpGet("/Categorias/Listado")]
        public IActionResult Index()
        {
            var listado = _maquService.ListadoCategorias(out string error);

            if (TempData["Script"] is string script)
            {
                TempData.Remove("Script");
                ViewBag.Script = script;
            }

            //if (String.IsNullOrEmpty(error))
            //    ModelState.AddModelError("", error);

            return View(listado);
        }

        [HttpPost("/Categorias/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VW_maqu_tbCategorias_VW item)
        {
            item.cate_UsuCreacion = ViewBag.user_Id = HttpContext.Session.GetInt32("user_Id");
            var insertar = _maquService.InsertCategorias(item);

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
        public IActionResult Edit(VW_maqu_tbCategorias_VW categorias)
        {
            categorias.cate_UsuModificacion = ViewBag.user_Id = HttpContext.Session.GetInt32("user_Id");
            var result = 0;
            result = _maquService.EditCategorias(categorias);

            if (result == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido editado con éxito');";
                TempData["Script"] = script;
            }
            else if (result == 2)
            {
                string script = $"MostrarMensajeWarning('El registro ya existe'); AbrirModalEdit('{categorias.cate_Id},{categorias.cate_Nombre}');";
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
