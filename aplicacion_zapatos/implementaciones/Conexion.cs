using aplicacion_zapatos.entidades;
using aplicacion_zapatos.interfaces;
using aplicacion_zapatos.nucleo;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_zapatos.implementaciones
{
    public class Conexion : DbContext, IConexion
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DatosGenerales.StringConexion()!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Zapatos>? Zapatos { get; set; }
    }
}
