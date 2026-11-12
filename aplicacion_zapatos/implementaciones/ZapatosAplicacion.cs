using aplicacion_zapatos.entidades;
using Microsoft.EntityFrameworkCore;

namespace aplicacion_zapatos.interfaces
{
    public class ZapatosAplicacion : IZapatosAplicacion
    {
        private IConexion IConexion;

        public ZapatosAplicacion(IConexion IConexion)
        {
            this.IConexion = IConexion;
        }

        public Zapatos Actualizar(Zapatos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var entry = this.IConexion!.Entry<Zapatos>(entidad);
            entry.State = EntityState.Modified;
            this.IConexion!.SaveChanges();
            return entidad;
        }

        public Zapatos Borrar(Zapatos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            this.IConexion.Zapatos!.Remove(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        public List<Zapatos> Buscar(Zapatos entidad)
        {
            return this.IConexion.Zapatos!
                .Where(x => x.Nombre!.Contains(entidad.Nombre!))
                .ToList();
        }

        public List<Zapatos> Consultar()
        {
            return this.IConexion.Zapatos!.Take(5).ToList();
        }

        public Zapatos Insertar(Zapatos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            this.IConexion.Zapatos!.Add(entidad!);
            this.IConexion.SaveChanges();
            return entidad;
        }

        private bool Validar(Zapatos entidad)
        {
            return string.IsNullOrEmpty(entidad.Codigo) ||
                string.IsNullOrEmpty(entidad.Nombre) ||
                entidad.Cantidad == 0 ||
                entidad.Fecha == null;
        }
    }
}