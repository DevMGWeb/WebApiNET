using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi;

public class TareaContext : DbContext
{
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Tarea> Tareas { get; set; }
    public TareaContext(DbContextOptions<TareaContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        List<Categoria> categoriasInit = new List<Categoria>();
        categoriasInit.Add(new Categoria(){ CategoriaId = Guid.Parse("4b00cae4-b7d2-44fa-a816-a26412be509b"), Nombre = "Actividades Pendientes", Peso = 20 });
        categoriasInit.Add(new Categoria(){ CategoriaId = Guid.Parse("4b00cae4-b7d2-44fa-a816-a26412be5002"), Nombre = "Actividades Personales", Peso = 10 });
        categoriasInit.Add(new Categoria(){ CategoriaId = Guid.Parse("4b00cae4-b7d2-44fa-a816-a26412be5003"), Nombre = "Actividades Pendientes 2", Peso = 30 });
        categoriasInit.Add(new Categoria(){ CategoriaId = Guid.Parse("4b00cae4-b7d2-44fa-a816-a26412be5004"), Nombre = "Actividades Personales 2", Peso = 40 });

        modelBuilder.Entity<Categoria>(categoria => 
        {
            categoria.ToTable("Categoria");
            categoria.HasKey(p=> p.CategoriaId);
            categoria.Property(p=> p.Nombre).IsRequired().HasMaxLength(150);
            categoria.Property(p=> p.Descripcion).IsRequired(false);
            categoria.Property(p=> p.Peso);
            categoria.HasData(categoriasInit);
        });

        List<Tarea> tareasInit = new List<Tarea>();
        tareasInit.Add(new Tarea(){ TareaId = Guid.Parse("4b00cae4-b7d2-44fa-a816-a26412be5011"), CategoriaId = Guid.Parse("4b00cae4-b7d2-44fa-a816-a26412be509b"), PrioridadTarea = Prioridad.Media, Titulo = "Pago de servicios publicos", FechaCreacion = DateTime.Now });
        tareasInit.Add(new Tarea(){ TareaId = Guid.Parse("4b00cae4-b7d2-44fa-a816-a26412be5012"), CategoriaId = Guid.Parse("4b00cae4-b7d2-44fa-a816-a26412be5002"), PrioridadTarea = Prioridad.Baja, Titulo = "Terminar de ver pelicula en netflix", FechaCreacion= DateTime.Now});

        modelBuilder.Entity<Tarea>(tarea => 
        {
            tarea.ToTable("Tarea");
            tarea.HasKey(p=> p.TareaId);
            tarea.HasOne(p=> p.Categoria).WithMany(p=> p.Tareas).HasForeignKey(p => p.CategoriaId);
            tarea.Property(p=> p.Titulo).IsRequired().HasMaxLength(200);
            tarea.Property(p=> p.Descripcion).IsRequired(false);
            tarea.Property(p=> p.PrioridadTarea);
            tarea.Property(p=> p.FechaCreacion).HasColumnType("datetime");
            tarea.Ignore(p => p.Resumen);
            tarea.HasData(tareasInit);
        });
    }
}