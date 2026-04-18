using System.ComponentModel.DataAnnotations.Schema;

namespace JabilMoviesAPI.Models.Entity
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Release_year { get; set; }
        public string Gender { get; set; }
        public TimeSpan Duration { get; set; }
        public int DirectorId { get; set; }
        //[ForeignKey(nameof(DirectorId))] 
        public virtual Director Director { get; set; } // Propiedad de navegación para acceder a los detalles del director
    }
}
