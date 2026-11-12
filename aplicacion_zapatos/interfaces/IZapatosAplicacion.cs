using aplicacion_zapatos.entidades;

namespace aplicacion_zapatos.interfaces
{
    public interface IZapatosAplicacion
    {
        Zapatos Insertar(Zapatos entidad);
        Zapatos Actualizar(Zapatos entidad);
        List<Zapatos> Consultar();
        List<Zapatos> Buscar(Zapatos entidad);
        Zapatos Borrar(Zapatos entidad);
    }
}