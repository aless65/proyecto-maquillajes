using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.Entities.Entities;
using Microsoft.AspNetCore.Http;
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
        private readonly AcceService _acceService;
        private readonly IMapper _mapper;

        public EstadoCivilController(GralService gralService, AcceService acceService, IMapper mapper)
        {
            _gralService = gralService;
            _acceService = acceService;
            _mapper = mapper;
        }

        [HttpGet("/EstadoCivil/Listado")]
        public IActionResult Index()
        {
            var listado = _gralService.ListadoEstadosCivilesVista(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<VW_gral_tbEstadosCiviles_VW>>(listado);

            if (TempData["Script"] is string script)
            {
                TempData.Remove("Script");
                ViewBag.Script = script;
            }

            ViewBag.pant_Id = 4;
            ViewBag.role_Id = HttpContext.Session.GetInt32("role_Id");
            ViewBag.user_EsAdmin = HttpContext.Session.GetString("user_EsAdmin");

            var permiso = _acceService.RolesPantalla(ViewBag.role_Id, Convert.ToBoolean(ViewBag.user_EsAdmin), ViewBag.pant_Id);

            if (permiso == 1)
            {
                return View(listadoMapeado);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpGet("/EstadoCivil/Details")]
        public IActionResult Details(int id)
        {
            var listado = _gralService.ListadoEstadosCivilesVista(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<VW_gral_tbEstadosCiviles_VW>>(listado).Where(X => X.estacivi_Id == id);

            ViewBag.pant_Id = 4;
            ViewBag.role_Id = HttpContext.Session.GetInt32("role_Id");
            ViewBag.user_EsAdmin = HttpContext.Session.GetString("user_EsAdmin");

            var permiso = _acceService.RolesPantalla(ViewBag.role_Id, Convert.ToBoolean(ViewBag.user_EsAdmin), ViewBag.pant_Id);

            if (permiso == 1)
            {
                return View(listadoMapeado);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

        }

        [HttpPost("/EstadoCivil/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VW_gral_tbEstadosCiviles_VW item)
        {
            try
            {
                item.estacivi_UsuCreacion = ViewBag.user_Id = HttpContext.Session.GetInt32("user_Id");
                var insertar = _gralService.InsertarEstadoCivil(item);

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
            catch (Exception error)
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost("/EstadoCivil/Edit")]
        public IActionResult Edit(VW_gral_tbEstadosCiviles_VW item)
        {
            try
            {
                item.estacivi_UsuModificacion = ViewBag.user_Id = HttpContext.Session.GetInt32("user_Id");
                var Editar = _gralService.EditarEstadoCivil(item);
                if (Editar == 1)
                {
                    string script = $"MostrarMensajeSuccess('El registro ha sido editado con éxito');";
                    TempData["Script"] = script;
                }
                else if (Editar == 2)
                {
                    string script = $"MostrarMensajeWarning('El registro ya existe'); AbrirModalEdit('{item.estacivi_Id},{item.estacivi_Nombre}') ";
                    TempData["Script"] = script;
                }
                else
                {
                    string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                    TempData["Script"] = script;
                }
            }
            catch (Exception error)
            {    
                
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var Eliminar = _gralService.EliminarEstadoCivil(id);

            if (Eliminar == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido eliminado con éxito');";
                TempData["Script"] = script;
            }
            else if (Eliminar == 2)
            {
                string script = $"MostrarMensajeWarning('El registro ya está siendo utilizado');";
                TempData["Script"] = script;
            }
            else
            {
                string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                TempData["Script"] = script;
            }

            return RedirectToAction("Index");
        }
    }
}
    