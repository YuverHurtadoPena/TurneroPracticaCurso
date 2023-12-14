using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using TurneroPracticaCurso.Entity;

namespace TurneroPracticaCurso.BLL.Interfaces
{
    public interface IMunicipioService
    {
        Task<List<Municipio>> ListaMunicipio(int IdDepartamento);
    }
}
