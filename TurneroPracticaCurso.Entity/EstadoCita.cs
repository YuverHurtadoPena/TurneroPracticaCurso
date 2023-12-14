using System;
using System.Collections.Generic;

namespace TurneroPracticaCurso.Entity;

public partial class EstadoCita
{
    public int IdEstadoCita { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
