using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TurneroPracticaCurso.DAL;
using TurneroPracticaCurso.DAL.DBContext;
using TurneroPracticaCurso.DAL.Interfaces;
using TurneroPracticaCurso.BLL.Mapper;
using TurneroPracticaCurso.BLL.Implementaciones;
using TurneroPracticaCurso.BLL.Interfaces;
using TurneroPracticaCurso.DAL.Implentacion;

namespace TurneroPracticaCurso.IOC
{
    public static  class Dependencia
    {

        public static void InyecionDepencia(this IServiceCollection services, IConfiguration Configuration)
        {

            services.AddDbContext<TurneroContext>(options =>
            {
                 options.UseNpgsql(Configuration.GetConnectionString("cadenaConexion"));
            });
            services.AddTransient(typeof(IGenericRepository<>), typeof(ImpGenericRepository<>));
            services.AddScoped<ITMapper, MapperImpl>();
            services.AddScoped<IPersonaService, ImplPersonaService>();
            services.AddScoped<IRolService, RolServiceImpl>();
            



        }
    }
}
