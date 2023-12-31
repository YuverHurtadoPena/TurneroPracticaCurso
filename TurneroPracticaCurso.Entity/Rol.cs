﻿using System;
using System.Collections.Generic;

namespace TurneroPracticaCurso.Entity;

public partial class Rol
{
    public int IdRol { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Menu> Menus { get; set; } = new List<Menu>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
