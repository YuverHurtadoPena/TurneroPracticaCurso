using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurneroPracticaCurso.BLL.Interfaces;
using TurneroPracticaCurso.Entity;
using TurneroPracticaCurso.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TurneroPracticaCurso.BLL.Implementaciones
{
    public class ImplUsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _repository;
        public ImplUsuarioService(IGenericRepository<Usuario> repository)
        {
            _repository = repository;
        }
        public Task<Usuario> Crear(Usuario entidad, string UrlPlantillaCorreo)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Usuario>> Lista()
        {
            IQueryable<Usuario> query = await _repository.Consultar();
            return query.Include(r => r.Rol).ToList();
        }
    }
}
