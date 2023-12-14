using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurneroPracticaCurso.BLL.Dto;
using TurneroPracticaCurso.Entity;

namespace TurneroPracticaCurso.BLL.Mapper
{
    public interface ITMapper
    {
        List<RolDto> ConvertRolOfEntityToVM(List<Rol> entity);
        List<PersonaDto> ConvertPeronaOfEntityToVM(List<Persona> entity);
    }
}
