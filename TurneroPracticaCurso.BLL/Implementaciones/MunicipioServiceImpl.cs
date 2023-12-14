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
    public class MunicipioServiceImpl : IMunicipioService
    {
        private readonly IGenericRepository<Municipio> _repositorio;
        public MunicipioServiceImpl(IGenericRepository<Municipio> repositorio)
        {
            _repositorio = repositorio;
        }
        public async Task<List<Municipio>> ListaMunicipio(int IdDepartamento)
        {
            IQueryable<Municipio> query = await _repositorio.Consultar(m => m.IdDeprtamento == IdDepartamento);
            return query.ToList();
        }
    }
}
