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
    public class TipoDocumentoServiceImpl : ITipoDocumentoService
    {
        private readonly IGenericRepository<TipoDocumento> _repositorio;

        public TipoDocumentoServiceImpl(IGenericRepository<TipoDocumento> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<List<TipoDocumento>> ListaTipoDocumento()
        {
            IQueryable<TipoDocumento> query = await _repositorio.Consultar();
            return query.ToList();
        }
    }
}
