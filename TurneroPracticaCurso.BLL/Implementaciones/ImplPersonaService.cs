using Microsoft.EntityFrameworkCore;
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
    public class ImplPersonaService : IPersonaService
    {
        private readonly IGenericRepository<Persona> _repositorio;
        public ImplPersonaService(IGenericRepository<Persona> repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<List<Persona>> ObtenerPersonas()
        {
            IQueryable<Persona> query = await _repositorio.Consultar();
            return query
                .Include(m => m.IdMunicipioNavigation)
                .Include(td => td.IdTipoDocumentoNavigation)
                .Include(u => u.Usuarios)
                .Include(u => u.Usuarios).ThenInclude(ur => ur.Rol)
                .ToList();
        }
    }
}
