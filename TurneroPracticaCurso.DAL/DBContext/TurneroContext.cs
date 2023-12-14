using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TurneroPracticaCurso.Entity;
namespace TurneroPracticaCurso.DAL;

public partial class TurneroContext : DbContext
{
    public TurneroContext()
    {
    }

    public TurneroContext(DbContextOptions<TurneroContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AtendidoPor> AtendidoPors { get; set; }

    public virtual DbSet<Cita> Cita { get; set; }

    public virtual DbSet<Configuracion> Configuracions { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<EstadoCita> EstadoCita { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Municipio> Municipios { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        //optionsBuilder.UseNpgsql();
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AtendidoPor>(entity =>
        {
            entity.HasKey(e => e.IdAtendido).HasName("atendido_por_pkey");

            entity.ToTable("atendido_por");

            entity.Property(e => e.IdAtendido).HasColumnName("id_atendido");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdCita).HasColumnName("id_cita");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");

            entity.HasOne(d => d.IdCitaNavigation).WithMany(p => p.AtendidoPors)
                .HasForeignKey(d => d.IdCita)
                .HasConstraintName("atendido_por_id_cita_fkey");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.AtendidoPors)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("atendido_por_id_persona_fkey");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("cita_pkey");

            entity.ToTable("cita");

            entity.Property(e => e.IdCita).HasColumnName("id_cita");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdEstadoCita).HasColumnName("id_estado_cita");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");

            entity.HasOne(d => d.IdEstadoCitaNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdEstadoCita)
                .HasConstraintName("cita_id_estado_cita_fkey");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("cita_id_persona_fkey");
        });

        modelBuilder.Entity<Configuracion>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("configuracion");

            entity.Property(e => e.Propiedad)
                .HasMaxLength(50)
                .HasColumnName("propiedad");
            entity.Property(e => e.Recurso)
                .HasMaxLength(50)
                .HasColumnName("recurso");
            entity.Property(e => e.Valor)
                .HasMaxLength(60)
                .HasColumnName("valor");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("departamentos_pkey");

            entity.ToTable("departamentos");

            entity.Property(e => e.IdDepartamento).HasColumnName("id_departamento");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
        });

        modelBuilder.Entity<EstadoCita>(entity =>
        {
            entity.HasKey(e => e.IdEstadoCita).HasName("estado_cita_pkey");

            entity.ToTable("estado_cita");

            entity.Property(e => e.IdEstadoCita).HasColumnName("id_estado_cita");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.MenuId).HasName("menu_pkey");

            entity.ToTable("menu");

            entity.Property(e => e.MenuId).HasColumnName("menu_id");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.Titulo)
                .HasMaxLength(100)
                .HasColumnName("titulo");

            entity.HasOne(d => d.Rol).WithMany(p => p.Menus)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("menu_rol_id_fkey");
        });

        modelBuilder.Entity<Municipio>(entity =>
        {
            entity.HasKey(e => e.IdMunicipio).HasName("municipio_pkey");

            entity.ToTable("municipio");

            entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.IdDeprtamento).HasColumnName("id_deprtamento");

            entity.HasOne(d => d.IdDeprtamentoNavigation).WithMany(p => p.Municipios)
                .HasForeignKey(d => d.IdDeprtamento)
                .HasConstraintName("municipio_id_deprtamento_fkey");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.IdPersona).HasName("persona_pkey");

            entity.ToTable("persona");

            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Apellidos).HasColumnName("apellidos");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdMunicipio).HasColumnName("id_municipio");
            entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");
            entity.Property(e => e.Nombres).HasColumnName("nombres");
            entity.Property(e => e.NroCelular).HasColumnName("nro_celular");
            entity.Property(e => e.NroDocumentos).HasColumnName("nro_documentos");

            entity.HasOne(d => d.IdMunicipioNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdMunicipio)
                .HasConstraintName("persona_id_municipio_fkey");

            entity.HasOne(d => d.IdTipoDocumentoNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdTipoDocumento)
                .HasConstraintName("persona_id_tipo_documento_fkey");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("rol_pkey");

            entity.ToTable("rol");

            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.IdTipoDocumento).HasName("tipo_documento_pkey");

            entity.ToTable("tipo_documento");

            entity.Property(e => e.IdTipoDocumento).HasColumnName("id_tipo_documento");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("usuarios_pkey");

            entity.ToTable("usuarios");

            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");
            entity.Property(e => e.Activo).HasColumnName("activo");
            entity.Property(e => e.Clave).HasColumnName("clave");
            entity.Property(e => e.FechaActualizacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_actualizacion");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("timestamp without time zone")
                .HasColumnName("fecha_creacion");
            entity.Property(e => e.IdPersona).HasColumnName("id_persona");
            entity.Property(e => e.RolId).HasColumnName("rol_id");
            entity.Property(e => e.Usuario1).HasColumnName("usuario");

            entity.HasOne(d => d.IdPersonaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPersona)
                .HasConstraintName("usuarios_id_persona_fkey");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("usuarios_rol_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
