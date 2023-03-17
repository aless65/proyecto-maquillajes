using Maquillaje.BusinessLogic.Services;
using Maquillaje.DataAccess;
using Maquillaje.DataAccess.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Maquillaje.BusinessLogic
{
    public static class ServiceConfiguration
    {
        public static void DataAccess(this IServiceCollection service, string connectionString)
        {
            service.AddScoped<CategoriaRepository>();
            service.AddScoped<EmpleadoRepository>();
            service.AddScoped<MunicipioRepository>();
            service.AddScoped<ClienteRepository>();
            service.AddScoped<DepartamentoRepository>();
            service.AddScoped<EstadoCivilRepository>();
            service.AddScoped<MetodoPagoRepository>();
            service.AddScoped<FacturaRepository>();
            service.AddScoped<UsuarioRepository>();
            service.AddScoped<RolRepository>();
            service.AddScoped<VW_acce_tbUsuarios_View_Repository>();
            service.AddScoped<FacturaDetalleRepository>();
            service.AddScoped<ProductoRepository>();
            service.AddScoped<VW_maqu_tbProveedores_VW_Repository>();
            service.AddScoped<VW_maqu_tbProductos_VW_Repository>();
            AndreasContext.BuildConnectionString(connectionString);
        }

        public static void BusinessLogic(this IServiceCollection service)
        {
            service.AddScoped<MaquService>();
            service.AddScoped<GralService>();
            service.AddScoped<AcceService>();
        }
    }
}
