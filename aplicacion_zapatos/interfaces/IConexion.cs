using aplicacion_zapatos.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace aplicacion_zapatos.interfaces
{
    public interface IConexion
    {
        DbSet<Zapatos>? Zapatos { get; set; }
        
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
