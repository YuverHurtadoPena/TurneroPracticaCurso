using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurneroPracticaCurso.Entity;

namespace TurneroPracticaCurso.BLL.Interfaces
{
    public interface IDerparmentoService
    {
        Task<List<Departamento>> ListaDepartamento();
    }
}
