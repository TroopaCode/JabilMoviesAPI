namespace JabilMoviesAPI.Models.DTOs
{
    public class DirectorDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }
        public int Age { get; set; }
        public bool Active { get; set; } = true; // Valor predeterminado para active es true
    }
}
