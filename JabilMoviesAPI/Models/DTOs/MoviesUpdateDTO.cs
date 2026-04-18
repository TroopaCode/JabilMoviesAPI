namespace JabilMoviesAPI.Models.DTOs
{
    public class MoviesUpdateDTO
    {
        public string Name { get; set; }
        public DateTime Release_year { get; set; }
        public string Gender { get; set; }
        public TimeSpan Duration { get; set; }
        public int DirectorId { get; set; }
    }
}
