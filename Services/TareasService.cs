using webapi.Models;

namespace webapi.Services;

public class TareasService : ITareasServices
{
    TareaContext context;

    public TareasService(TareaContext dbcontext)
    {
        this.context = dbcontext;
    }

    public IEnumerable<Tarea> Get()
    {
        return this.context.Tareas;
    }

    public async Task SaveAsync(Tarea tarea)
    {
        context.Add<Tarea>(tarea);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id, Tarea tarea)
    {
        var TareaActual = context.Find<Tarea>(id);

        if(TareaActual != null)
        {   
            TareaActual.CategoriaId = tarea.CategoriaId;
            TareaActual.Descripcion = tarea.Descripcion;
            TareaActual.FechaCreacion = tarea.FechaCreacion;
            TareaActual.PrioridadTarea = tarea.PrioridadTarea;
            TareaActual.Resumen = tarea.Resumen;
            TareaActual.Titulo = tarea.Titulo;
            
            context.Entry<Tarea>(TareaActual).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(Guid id)
    {
        var TareaActual = context.Find<Tarea>(id);

        if(TareaActual != null)
        {   
            context.Remove<Tarea>(TareaActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface ITareasServices 
{
    IEnumerable<Tarea> Get();

    Task SaveAsync(Tarea tarea);

    Task UpdateAsync(Guid id, Tarea tarea);

    Task DeleteAsync(Guid id);
}