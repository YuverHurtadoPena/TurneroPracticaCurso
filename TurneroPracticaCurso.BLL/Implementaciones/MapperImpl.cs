using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurneroPracticaCurso.BLL.Dto;
using TurneroPracticaCurso.BLL.Mapper;
using TurneroPracticaCurso.Entity;

namespace TurneroPracticaCurso.BLL.Implementaciones
{
    public class MapperImpl : ITMapper
    {
        public List<PersonaDto> ConvertPeronaOfEntityToVM(List<Persona> entity)
        {
            PersonaDto personaDto = null;
            List<PersonaDto> list = new List<PersonaDto>();

            foreach (var persona in entity)
            {
                personaDto = new PersonaDto();
                personaDto.Nombres = persona.Nombres;
                personaDto.Apellidos = persona.Apellidos;
                personaDto.NroCelular = persona.NroCelular;
                personaDto.NroDocumentos = persona.NroDocumentos;
                personaDto.IdPersona = persona.IdPersona;
                personaDto.Activo = persona.Activo;
                personaDto.FechaCreacion = persona.FechaCreacion;
                personaDto.FechaActualizacion = persona.FechaActualizacion;
                personaDto.IdMunicipio = persona.IdMunicipio;
                personaDto.IdTipoDocumento = persona.IdTipoDocumento;
                personaDto.DescripcionTipoDocumento = persona.IdTipoDocumentoNavigation?.Descripcion;
                personaDto.DescripcionMunicipio = persona.IdMunicipioNavigation?.Descripcion;
                personaDto.RolDescripcion = persona.Usuarios.FirstOrDefault()?.Rol?.Descripcion;
                personaDto.UsuarioEmail = persona.Usuarios.FirstOrDefault()?.Usuario1;
                list.Add(personaDto);
            }
            return list;
        }

        public List<RolDto> ConvertRolOfEntityToVM(List<Rol> entity)
        {
            RolDto infoRol = null;
            List<RolDto> infoRolList = new List<RolDto>();


            if (entity != null)
            {
                foreach (var rol in entity)
                {
                   
                    infoRol = new RolDto();
                    infoRol.Descripcion = rol.Descripcion;
                    infoRol.IdRol = rol.IdRol;
                    infoRolList.Add(infoRol);
                }
            }

            return infoRolList;
        }
    }
    
}
