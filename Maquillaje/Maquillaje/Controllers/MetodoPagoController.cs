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
    public class MetodoPagoController : Controller
    {
        private readonly MaquService _maquService;
        private readonly AcceService _acceService;
        private readonly IMapper _mapper;

        public MetodoPagoController(MaquService maquService, AcceService acceService, IMapper mapper)
        {
            _maquService = maquService;
            _acceService = acceService;
            _mapper = mapper;
        }

        [HttpGet("/MetodosPago/Listado")]
        public IActionResult Index()
        {
            ViewBag.pant_Id = 9;
            ViewBag.role_Id = HttpContext.Session.GetInt32("role_Id");
            ViewBag.user_EsAdmin = HttpContext.Session.GetString("user_EsAdmin");

            var permiso = _acceService.RolesPantalla(ViewBag.role_Id, Convert.ToBoolean(ViewBag.user_EsAdmin), ViewBag.pant_Id);

            if (permiso == 1)
            {

                var listado = _maquService.ListadoMetodosPago();
                var listadoMapeado = _mapper.Map<IEnumerable<MetodoPagoViewModel>>(listado);

                if (TempData["Script"] is string script)
                {
                    TempData.Remove("Script");
                    ViewBag.Script = script;
                }

                return View(listadoMapeado);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
            //return View(listadoMapeado);
        }

        [HttpPost]
        public IActionResult Create(MetodoPagoViewModel item)
        {
            item.meto_UsuCreacion = ViewBag.user_Id = HttpContext.Session.GetInt32("user_Id");
            var metodo = _mapper.Map<tbMetodosPago>(item);
            var insertar = _maquService.InsertMetodosPago(metodo);

            if(insertar == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido insertado con éxito');";
                TempData["Script"] = script;
            }
            else if(insertar == 2)
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

        [HttpPost]
        public IActionResult Update(MetodoPagoViewModel item)
        {
            item.meto_UsuModificacion = ViewBag.user_Id = HttpContext.Session.GetInt32("user_Id");
            var metodo = _mapper.Map<tbMetodosPago>(item);
            var update = _maquService.UpdateMetodosPago(metodo);

            if (update == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido editado con éxito');";
                TempData["Script"] = script;
            } 
            else if (update == 2)
            {
                string script = $"MostrarMensajeWarning('El registro ya existe'); AbrirModalEdit('{item.meto_Id},{item.meto_Nombre}') ";
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
            var delete = _maquService.DeleteMetodosPago(id);

            if(delete == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido eliminado con éxito');";
                TempData["Script"] = script;
            }
            else if(delete == 2)
            {
                string script = $"MostrarMensajeWarning('El registro ya está siendo utilizado');";
                TempData["Script"] = script;
            } else
            {
                string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                TempData["Script"] = script;
            }

            return RedirectToAction("Index");
        }

        [HttpGet("/MetodosPago/Details")]
        public IActionResult Details(int id)
        {
            ViewBag.pant_Id = 9;
            ViewBag.role_Id = HttpContext.Session.GetInt32("role_Id");
            ViewBag.user_EsAdmin = HttpContext.Session.GetString("user_EsAdmin");

            var permiso = _acceService.RolesPantalla(ViewBag.role_Id, Convert.ToBoolean(ViewBag.user_EsAdmin), ViewBag.pant_Id);

            if (permiso == 1)
            {
                var listado = _maquService.MetodosPagoDetails();
                var listadoMapeado = _mapper.Map<IEnumerable<VW_maqu_tbMetodosPago_View>>(listado).Where(X => X.meto_Id == id);

                return View(listadoMapeado);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
