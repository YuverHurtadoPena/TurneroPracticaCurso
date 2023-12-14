using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurneroPracticaCurso.BLL.Dto
{
    public class UsuarioDto
    {
        public int UsuarioId { get; set; }

        public string Usuario1 { get; set; } = null!;

        public string Clave { get; set; } = null!;

        public int? RolId { get; set; }

        public bool Activo { get; set; }

        public string NombreRol { get; set; } = null!;
        public int? IdPersona { get; set; }
    }
}
