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
    public class ClienteController : Controller
    {
        private readonly MaquService _maquService;
        private GralService _gralService;
        private readonly AcceService _acceService;
        private readonly IMapper _mapper;

        public ClienteController(MaquService maquService, GralService gralService, AcceService acceService, IMapper mapper)
        {
            _maquService = maquService;
            _gralService = gralService;
            _acceService = acceService;
            _mapper = mapper;
        }

        [HttpGet("/Clientes/Listado")]
        public IActionResult Index()
        {
            var listado = _maquService.ListadoClientes(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<ClienteViewModel>>(listado);

            if (TempData["Script"] is string script)
            {
                TempData.Remove("Script");
                ViewBag.Script = script;
            }

            ViewBag.pant_Id = 6;
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

        [HttpGet("/Clientes/Create")]
        public IActionResult Create()
        {
            var listado = _gralService.ListadoDepartamento(out string error).ToList();
            ViewBag.depa_Id = new SelectList(listado, "depa_Id", "depa_Nombre");

            ViewBag.pant_Id = 6;
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

        [HttpPost("/Clientes/Create")]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClienteViewModel item)
        {
            item.clie_UsuCreacion = ViewBag.user_Id = HttpContext.Session.GetInt32("user_Id");
            var listado = _gralService.ListadoDepartamento(out string error).ToList();
            ViewBag.depa_Id = new SelectList(listado, "depa_Id", "depa_Nombre");

            var cliente = _mapper.Map<tbClientes>(item);
            var insertar = _maquService.InsertClientes(cliente);


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

        [HttpGet("/Clientes/Update")]
        public IActionResult Update(int id)
        {
            var cliente = _maquService.ObtenerIDCliente(id);

            var listadoDepa = _gralService.ListadoDepartamento(out string error).ToList();
            ViewBag.depa_Id = new SelectList(listadoDepa, "depa_Id", "depa_Nombre");

            ViewBag.pant_Id = 6;
            ViewBag.role_Id = HttpContext.Session.GetInt32("role_Id");
            ViewBag.user_EsAdmin = HttpContext.Session.GetString("user_EsAdmin");

            var permiso = _acceService.RolesPantalla(ViewBag.role_Id, Convert.ToBoolean(ViewBag.user_EsAdmin), ViewBag.pant_Id);

            if (permiso == 1)
            {
                return View(cliente);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost("/Clientes/Update")]
        [ValidateAntiForgeryToken]
        public IActionResult Update(tbClientes item)
        {
            item.clie_UsuModificacion = ViewBag.user_Id = HttpContext.Session.GetInt32("user_Id");
            var update = _maquService.UpdateClientes(item);

            var listadoDepa = _gralService.ListadoDepartamento(out string error).ToList();
            ViewBag.depa_Id = new SelectList(listadoDepa, "depa_Id", "depa_Nombre");

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
            var delete = _maquService.DeleteCliente(id);

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

        public IActionResult CargarMunicipios(string id)
        {
            var cargarmunicipios = _gralService.GetMunicipiosPorDepartamento(id);
            return Json(cargarmunicipios);
        }

        public IActionResult CargarMunicipiosCliente(int id)
        {
            var cargarmunicipioselected = _maquService.UpdateClientesMuniDDL(id);
            return Json(cargarmunicipioselected);
        }

        [HttpGet("/Clientes/Details")]
        public IActionResult Details(int id)
        {
            var listado = _maquService.DetailsClientes(out string error);
            var listadoMapeado = _mapper.Map<IEnumerable<VW_maqu_tbClientes_VW>>(listado).Where(X => X.clie_Id == id);

            ViewBag.pant_Id = 6;
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
