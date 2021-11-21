global using System.Text.Json.Serialization;

namespace MoviesApi.Enteties
{
    public class Actor
    {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [Required]
    [MaxLength(255)]
    public string Fullname { get; set; }

    [Required]
    public DateTimeOffset Birthdate { get; set; }
    
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ICollection<Movie> Movies { get; set; }
    }
}