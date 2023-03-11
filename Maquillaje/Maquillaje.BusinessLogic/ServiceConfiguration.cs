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

            AndreasContext.BuildConnectionString(connectionString);
        }

        public static void BusinessLogic(this IServiceCollection service)
        {
            service.AddScoped<MaquService>();
        }
    }
}
