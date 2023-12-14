using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurneroPracticaCurso.BLL.Dto
{
   public class TipoDocumentoDto
    {
        public int IdTipoDocumento { get; set; }

        public string Descripcion { get; set; } = null!;
    }
}
