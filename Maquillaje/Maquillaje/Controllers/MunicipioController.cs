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
    public class MunicipioController : Controller
    {

        private readonly GralService _gralService;
        private readonly AcceService _acceService;
        private readonly IMapper _mapper;

        public MunicipioController(GralService gralService, AcceService acceService, IMapper mapper)
        {
            _gralService = gralService;
            _acceService = acceService;
            _mapper = mapper;
        }


        [HttpGet("/Municipio/Listado")]
        public IActionResult Index()
        {
            ViewBag.pant_Id = 3;
            ViewBag.role_Id = HttpContext.Session.GetInt32("role_Id");
            ViewBag.user_EsAdmin = HttpContext.Session.GetString("user_EsAdmin");

            try
            {

                var permiso = _acceService.RolesPantalla(ViewBag.role_Id, Convert.ToBoolean(ViewBag.user_EsAdmin), ViewBag.pant_Id);

                if (permiso == 1)
                {

                    var listado = _gralService.ListadoMunicipios(out string error);
                    var listadoMapeado = _mapper.Map<IEnumerable<VW_gral_tbMunicipios_VW>>(listado);
                    var ddldepartamentos = _gralService.ListadoDepartamentosView(out string error1);

                    ViewBag.depa_Id = new SelectList(ddldepartamentos, "depa_Id", "depa_Nombre");

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
            }
            catch
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet("/Municipio/Details")]
        public IActionResult Details(string id)
        {
            ViewBag.pant_Id = 3;
            ViewBag.role_Id = HttpContext.Session.GetInt32("role_Id");
            ViewBag.user_EsAdmin = HttpContext.Session.GetString("user_EsAdmin");

            try
            {
                var permiso = _acceService.RolesPantalla(ViewBag.role_Id, Convert.ToBoolean(ViewBag.user_EsAdmin), ViewBag.pant_Id);

                if (permiso == 1)
                {
                    var listado = _gralService.ListadoMunicipios(out string error);
                    var listadoMapeado = _mapper.Map<IEnumerable<VW_gral_tbMunicipios_VW>>(listado).Where(X => X.muni_id == id);
                    var ddldepartamentos = _gralService.ListadoDepartamentosView(out string error1);

                    ViewBag.depa_Id = new SelectList(ddldepartamentos, "depa_Id", "depa_Nombre");

                    return View(listadoMapeado);
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            catch
            {
                return RedirectToAction("Index", "Login");
            }

        }


        [HttpPost("/Municipio/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VW_gral_tbMunicipios_VW item)
        {
            try
            {
                item.muni_UsuCreacion = ViewBag.user_Id = HttpContext.Session.GetInt32("user_Id");
                var insertar = _gralService.InsertarMunicipio(item);
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

        [HttpPost("/Municipio/Edit")]
        public IActionResult Edit(VW_gral_tbMunicipios_VW item)
        {
            try
            {
                item.muni_UsuModificacion = ViewBag.user_Id = HttpContext.Session.GetInt32("user_Id");
                var editar = _gralService.EditarMunicipio(item);

                if (editar == 1)
                {
                    string script = $"MostrarMensajeSuccess('El registro ha sido editado con éxito');";
                    TempData["Script"] = script;
                }
                else if (editar == 2)
                {
                    string script = $"MostrarMensajeWarning('El registro ya existe'); AbrirModalEdit('{item.muni_id},{item.depa_Id},{item.muni_Nombre}') ";
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

        [HttpPost("/Municipio/Delete")]
        public IActionResult Delete(string id)
        {

            var delete = _gralService.EliminarMunicipio(id);

            if (delete == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido eliminado con éxito');";
                TempData["Script"] = script;
            }
            else if (delete == 2)
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
