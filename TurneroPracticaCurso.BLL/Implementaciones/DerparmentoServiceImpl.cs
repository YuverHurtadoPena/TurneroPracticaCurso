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
    public class DerparmentoServiceImpl : IDerparmentoService
    {
        private readonly IGenericRepository<Departamento> _repositorio;
        public DerparmentoServiceImpl(IGenericRepository<Departamento> repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<List<Departamento>> ListaDepartamento()
        {
            IQueryable<Departamento> query = await _repositorio.Consultar();
            return query.ToList();
        }
    }
}
