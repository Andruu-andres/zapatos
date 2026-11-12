using aplicacion_zapatos.entidades;
using presentacion_zapatos.interfaces;

namespace aplicacion_zapatos.interfaces
{
    public class ZapatosPresentacion : IZapatosPresentacion
    {
        private IComunicaciones IComunicaciones;

        public ZapatosPresentacion(IComunicaciones IComunicaciones)
        {
            this.IComunicaciones = IComunicaciones;
        }

        public Zapatos Actualizar(Zapatos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Zapatos>(
                "Zapatos/Actualizar", 
                entidad);
            task.Wait();
            return task.Result;
        }

        public Zapatos Borrar(Zapatos entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Zapatos>(
                "Zapatos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Zapatos> Buscar(Zapatos entidad)
        {
            var task = this.IComunicaciones.Ejecutar<List<Zapatos>>(
                "Zapatos/Buscar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Zapatos> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Zapatos>>(
                "Zapatos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Zapatos Insertar(Zapatos entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            if (Validar(entidad))
                throw new Exception("Falta informacion");

            var task = this.IComunicaciones.Ejecutar<Zapatos>(
                "Zapatos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        private bool Validar(Zapatos entidad)
        {
            return string.IsNullOrEmpty(entidad.Codigo) ||
                string.IsNullOrEmpty(entidad.Nombre);
        }
    }
}