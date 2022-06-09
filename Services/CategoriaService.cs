using webapi.Models;

namespace webapi.Services;

public class CategoriaService  : ICategoriaService
{
    private TareaContext context; 

    public CategoriaService(TareaContext dbcontext)
    {
        this.context = dbcontext;
    }

    public IEnumerable<Categoria> Get()
    {
        return context.Categorias;
    }

    public async Task SaveAsync(Categoria categoria)
    {
        context.Add(categoria);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Guid id, Categoria categoria)
    {
        var categoriaActual = context.Categorias.Find(id);

        if(categoriaActual != null)
        {
            categoriaActual.Nombre = categoria.Nombre;
            categoriaActual.Descripcion = categoria.Descripcion;
            categoriaActual.Peso = categoria.Peso;

            context.Entry<Categoria>(categoriaActual).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }

    public async Task Delete(Guid id)
    {
        var categoriaActual = context.Categorias.Find(id);

        if(categoriaActual != null)
        {
            context.Remove<Categoria>(categoriaActual);
            await context.SaveChangesAsync();
        }
    }
}

public interface ICategoriaService
{
    IEnumerable<Categoria> Get();
    Task SaveAsync(Categoria categoria);
    Task UpdateAsync(Guid id, Categoria categoria);
    Task Delete(Guid id);
}