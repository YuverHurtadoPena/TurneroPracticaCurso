using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TurneroPracticaCurso.DAL.Interfaces;

namespace TurneroPracticaCurso.DAL.Implentacion
{
    public class ImpGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly TurneroContext _dBContext;
        public ImpGenericRepository(TurneroContext dBContext)
        {
            _dBContext = dBContext;
        }
         async Task<IQueryable<TEntity>> IGenericRepository<TEntity>.Consultar(Expression<Func<TEntity, bool>> filtro)
        {
            IQueryable<TEntity> queryTable = filtro == null ? _dBContext.Set<TEntity>() : _dBContext.Set<TEntity>().Where(filtro);
            return queryTable;
        }
 

       async Task<TEntity> IGenericRepository<TEntity>.Crear(TEntity entidad)
        {
            try
            {
                _dBContext.Set<TEntity>().Add(entidad);
                await _dBContext.SaveChangesAsync();
                return entidad;
            }
            catch (Exception ex) { throw ex; }
        }

       async Task<bool> IGenericRepository<TEntity>.Editar(TEntity entidad)
        {
            try
            {
                _dBContext.Set<TEntity>().Update(entidad);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { throw ex; }
        }

        async Task<bool> IGenericRepository<TEntity>.Eliminar(TEntity entidad)
        {
            try
            {
                _dBContext.Set<TEntity>().Remove(entidad);
                await _dBContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex) { throw; }
        }

      async Task<TEntity> IGenericRepository<TEntity>.Obtener(Expression<Func<TEntity, bool>> filtro)
        {
            try
            {
                TEntity entidad = await _dBContext.Set<TEntity>().FirstOrDefaultAsync(filtro);
                return entidad;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
