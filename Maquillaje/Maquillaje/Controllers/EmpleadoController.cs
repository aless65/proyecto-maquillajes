using AutoMapper;
using Maquillaje.BusinessLogic.Services;
using Maquillaje.Entities.Entities;
using Maquillaje.WebUI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Controllers
{
    public class EmpleadoController : Controller
    {
        private readonly MaquService _maquService;
        private readonly AcceService _acceService;
        private GralService _gralService;
        private readonly IMapper _mapper;

        public EmpleadoController(MaquService maquService, AcceService acceService, GralService gralService, IMapper mapper)
        {
            _maquService = maquService;
            _gralService = gralService;
            _acceService = acceService;
            _mapper = mapper;
        }

        [HttpGet("/Empleados/Listado")]
        public IActionResult Index()
        {
            var listado = _maquService.ListadoEmpleados(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<EmpleadoViewModel>>(listado);
            if (TempData["Script"] is string script)
            {
                TempData.Remove("Script");
                ViewBag.Script = script;
            }

            ViewBag.pant_Id = 7;
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

        [HttpGet("Empleados/Create")]
        public IActionResult Create()
        {
            var listado = _gralService.ListadoDepartamento(out string error).ToList();

            ViewBag.depa_Id = new SelectList(listado, "depa_Id", "depa_Nombre");

            var listadoEstadosCiviles = _gralService.ListadoEstadosCiviles(out string error1).ToList();
            ViewBag.estacivi_Id = new SelectList(listadoEstadosCiviles, "estacivi_Id", "estacivi_Nombre");
            var listadoSucursales = _maquService.ListadoSucursales();
            ViewBag.sucu_Id = new SelectList(listadoSucursales, "sucu_Id", "sucu_Descripcion");

            ViewBag.pant_Id = 7;
            ViewBag.role_Id = HttpContext.Session.GetInt32("role_Id");
            ViewBag.user_EsAdmin = HttpContext.Session.GetString("user_EsAdmin");

            var permiso = _acceService.RolesPantalla(ViewBag.role_Id, Convert.ToBoolean(ViewBag.user_EsAdmin), ViewBag.pant_Id);

            if (permiso == 1)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost("/Empleados/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmpleadoViewModel item)
        {
            item.empe_UsuCreacion = ViewBag.user_Id = HttpContext.Session.GetInt32("user_Id");
            var listado = _gralService.ListadoDepartamento(out string error).ToList();

            ViewBag.depa_Id = new SelectList(listado, "depa_Id", "depa_Nombre");

            var listadoEstadosCiviles = _gralService.ListadoEstadosCiviles(out string error1).ToList();
            ViewBag.estacivi_Id = new SelectList(listadoEstadosCiviles, "estacivi_Id", "estacivi_Nombre");
            var listadoSucursales = _maquService.ListadoSucursales();
            ViewBag.sucu_Id = new SelectList(listadoSucursales, "sucu_Id", "sucu_Descripcion");

            var empleado = _mapper.Map<tbEmpleados>(item);
            var insertar = _maquService.InsertEmpleado(empleado);

            try
            {
                if (insertar == 1)
                {
                    string script = $"MostrarMensajeSuccess('El registro ha sido insertado con éxito');";
                    TempData["Script"] = script;
                    return RedirectToAction("Index");
                }
                else if (insertar == 2)
                {
                    string script = "MostrarMensajeWarning('Un registro con este número de identidad ya existe'); console.log('se repite')";
                    TempData["Script"] = script;
                    return View();
                }
                else
                {
                    string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                    TempData["Script"] = script;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpGet("/Empleados/Update")]
        public IActionResult Update(int id)
        {
            var listado = _maquService.ObtenerIDEmpleado(id);

            var listadoEstadosCiviles = _gralService.ListadoEstadosCiviles(out string error1).ToList();
            ViewBag.estacivi_Id = new SelectList(listadoEstadosCiviles, "estacivi_Id", "estacivi_Nombre");

            var listadoDepa = _gralService.ListadoDepartamento(out string error).ToList();
            ViewBag.depa_Id = new SelectList(listadoDepa, "depa_Id", "depa_Nombre");

            var listadoSucursales = _maquService.ListadoSucursales();
            ViewBag.sucu_Id = new SelectList(listadoSucursales, "sucu_Id", "sucu_Descripcion");

            ViewBag.pant_Id = 7;
            ViewBag.role_Id = HttpContext.Session.GetInt32("role_Id");
            ViewBag.user_EsAdmin = HttpContext.Session.GetString("user_EsAdmin");

            var permiso = _acceService.RolesPantalla(ViewBag.role_Id, Convert.ToBoolean(ViewBag.user_EsAdmin), ViewBag.pant_Id);

            if (permiso == 1)
            {
                if (listado != null)
                {
                    return View(listado);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }


        [HttpPost("/Empleados/Update")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(tbEmpleados item)
        {
            item.empe_UsuModificacion = ViewBag.user_Id = HttpContext.Session.GetInt32("user_Id");
            var update = _maquService.UpdateEmpelado(item);

            var listadoEstadosCiviles = _gralService.ListadoEstadosCiviles(out string error1).ToList();
            ViewBag.estacivi_Id = new SelectList(listadoEstadosCiviles, "estacivi_Id", "estacivi_Nombre");

            var listadoDepa = _gralService.ListadoDepartamento(out string error).ToList();
            ViewBag.depa_Id = new SelectList(listadoDepa, "depa_Id", "depa_Nombre");
            var listadoSucursales = _maquService.ListadoSucursales();
            ViewBag.sucu_Id = new SelectList(listadoSucursales, "sucu_Id", "sucu_Descripcion");
            if (update == 1)
            {
                string script = $"MostrarMensajeSuccess('El registro ha sido editado con éxito');";
                TempData["Script"] = script;
                return RedirectToAction("Index");
            }
            else if (update == 2)
            {
                string script = $"MostrarMensajeWarning('Un registro con este número de identidad ya existe');";
                TempData["Script"] = script;
                return View(item);
            }
            else
            {
                string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                TempData["Script"] = script;
                return View(item);
            }
        }

        public IActionResult Delete(int id)
        {
            var delete = _maquService.DeleteEmpleado(id);

            if(delete == 0)
            {
                string script = "MostrarMensajeDanger('Ha ocurrido un error');";
                TempData["Script"] = script;
            }
            if(delete == 2)
            {
                string script = $"MostrarMensajeWarning('El registro ya está siendo utilizado');";
                TempData["Script"] = script;
            }
            if (delete == 1)
            {
                    string script = $"MostrarMensajeSuccess('El registro ha sido eliminado con éxito');";
                    TempData["Script"] = script;
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult CargarMunicipios(string id)
        {
            var cargarmunicipios = _gralService.GetMunicipiosPorDepartamento(id);
            return Json(cargarmunicipios);
        }

        public IActionResult CargarMunicipiosEmpleado(int id)
        {
            var cargarmunicipioselected = _maquService.UpdateEmpleadosMuniDDL(id);
            return Json(cargarmunicipioselected);
        }

        [HttpGet("/Empleado/Details")]
        public IActionResult Details(int id)
        {
            var listado = _maquService.ListadoEmpleadosView(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<VW_maqu_tbEmpleados_View>>(listado).Where(X => X.empe_Id == id);

            ViewBag.pant_Id = 7;
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
    }
}
