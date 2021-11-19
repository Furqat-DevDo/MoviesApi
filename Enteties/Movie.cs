global using System.ComponentModel.DataAnnotations.Schema;
global using System.ComponentModel.DataAnnotations;

namespace MoviesApi.Enteties
{
    public class Movie
    {
    
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id{get;set;}=Guid.NewGuid();
        [Required,MaxLength(255)]
        public string Title{get;set;}
        [MaxLength(1024)]
        public string Description{get;set;}
        [Required,Range(0,10)]
        public double Rating{get;set;}
        [Required]
        public DateTimeOffset ReleaseData{get;set;}
        public ICollection<Genre> Genres{get;set;}
        public ICollection<Actor> Actors{get;set;}
        public ICollection<Image> Images{get;set;}
      
    }
}