namespace JabilMoviesAPI.Models.DTOs
{
    public class DirectorInsertDTO
    {
        //No se inclue el ID porque se asume que el ID se generará automáticamente al insertar un nuevo director en la base de datos.
        public string Name { get; set; }
        public string Nationality { get; set; }
        public int Age { get; set; }

        //No se incluye el campo Active porque se asume que el valor predeterminado para Active es true,
        //lo que significa que el director estará activo por defecto al ser insertado en la base de datos.
    }
}
