namespace MoviesApi.Enteties
{
    public class Genre
    {
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }
    
    [Required]
    [MaxLength(20)]
    public string Name { get; set; }


    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ICollection<Movie> Movies { get; set; }

    [Obsolete("Only for entity binding.")]
    public Genre() { }

    public Genre(string name, ICollection<Movie> movies = default)
    {
        Id = Guid.NewGuid();
        Name = name;
    }
        
    }
}