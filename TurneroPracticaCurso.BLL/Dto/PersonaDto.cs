using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurneroPracticaCurso.BLL.Dto
{
    public class PersonaDto
    {
        public int IdPersona { get; set; }

        public string Nombres { get; set; } = null!;

        public string Apellidos { get; set; } = null!;

        public string NroDocumentos { get; set; } = null!;

        public string NroCelular { get; set; } = null!;

        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime? FechaActualizacion { get; set; }

        public int? IdMunicipio { get; set; }

        public int? IdTipoDocumento { get; set; }
        public string? DescripcionTipoDocumento { get; set; }
        public string? DescripcionMunicipio { get; set; }

        public string? UsuarioEmail { get; set; }
        public string? RolDescripcion { get; set; }
    }
}
