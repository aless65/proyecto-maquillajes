﻿using AutoMapper;
using Maquillaje.Entities.Entities;
using Maquillaje.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Maquillaje.WebUI.Extensions
{
    public class MappingProfileExtensions: Profile
    {
        public MappingProfileExtensions()
        {
            CreateMap<CategoriaViewModel, tbCategorias>().ReverseMap();
            CreateMap<EmpleadoViewModel, tbEmpleados>().ReverseMap();
            CreateMap<ClienteViewModel, tbClientes>().ReverseMap();
            CreateMap<MetodoPagoViewModel, tbMetodosPago>().ReverseMap();
            CreateMap<UsuarioViewModel, tbUsuarios>().ReverseMap();
            CreateMap<FacturaViewModel, tbFacturas>().ReverseMap();
            CreateMap<VW_acce_tbUsuarios_ViewModel, VW_acce_tbUsuarios_View>().ReverseMap();
            //CreateMap<tbUsuarios, VW_acce_tbUsuarios_View>().ReverseMap();
            CreateMap<FacturaDetalleViewModel, tbFacturasDetalles>().ReverseMap();
        }
    }
}
