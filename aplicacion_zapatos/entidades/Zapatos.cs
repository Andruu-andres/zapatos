namespace aplicacion_zapatos.entidades
{
    public class Zapatos
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public int Cantidad { get; set; }
        public DateTime? Fecha { get; set; }
    }
}