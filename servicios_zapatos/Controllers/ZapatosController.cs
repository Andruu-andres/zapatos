using aplicacion_zapatos.entidades;
using Microsoft.AspNetCore.Mvc;
using aplicacion_zapatos.interfaces;

namespace servicios_Zapatos.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ZapatosController : ControllerBase
    {
        private IZapatosAplicacion IZapatosAplicacion;

        public ZapatosController(IZapatosAplicacion IZapatosAplicacion)
        {
            this.IZapatosAplicacion = IZapatosAplicacion;
        }

        [HttpPost]
        public List<Zapatos> Consultar()
        {
            return this.IZapatosAplicacion.Consultar();
        }

        [HttpPost]
        public List<Zapatos> Buscar(Zapatos entidad)
        {
            return this.IZapatosAplicacion.Buscar(entidad);
        }

        [HttpPost]
        public Zapatos Insertar(Zapatos entidad)
        {
            return this.IZapatosAplicacion.Insertar(entidad);
        }

        [HttpPost]
        public Zapatos Actualizar(Zapatos entidad)
        {
            return this.IZapatosAplicacion.Actualizar(entidad);
        }

        [HttpPost]
        public Zapatos Borrar(Zapatos entidad)
        {
            return this.IZapatosAplicacion.Borrar(entidad);
        }
    }
}
