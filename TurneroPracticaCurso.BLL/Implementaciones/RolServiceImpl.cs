using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurneroPracticaCurso.BLL.Interfaces;
using TurneroPracticaCurso.DAL.Interfaces;
using TurneroPracticaCurso.Entity;

namespace TurneroPracticaCurso.BLL.Implementaciones
{
    public class RolServiceImpl : IRolService
    {
        private readonly IGenericRepository<Rol> _repositorio;

        public RolServiceImpl(IGenericRepository<Rol> repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<List<Rol>> ListaRol()
        {
            IQueryable<Rol> query = await _repositorio.Consultar();
            return query.ToList();
        }
    }
}
