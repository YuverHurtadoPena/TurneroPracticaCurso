using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurneroPracticaCurso.BLL.Dto
{
    public class MenuDto
    {
        public int MenuId { get; set; }

        public string Titulo { get; set; } = null!;

        public string? Descripcion { get; set; }

        public int? RolId { get; set; }
    }
}
