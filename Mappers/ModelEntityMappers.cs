using MoviesApi.Enteties;

namespace MoviesApi.Mappers;

public static class ModelEntityMappers
{
    public static Genre ToEntity(this Models.NewGenre genre)
        => new Genre(genre.Name);

    public static Actor ToEntity(this Models.NewActor actor)
        => new Actor()
        {   
            Id = Guid.NewGuid(),
            FullName = actor.Fullname,
            BirthDate = actor.Birthdate
        };

    public static Movie ToEntity(this Models.NewMovie movie, 
        IEnumerable<Actor> actors, 
        IEnumerable<Genre> genres)
            => new Movie()
            {
                Id = Guid.NewGuid(),
                Title = movie.Title,
                Description = movie.Description,
                ReleaseData= movie.ReleaseDate,
                Rating = movie.Rating,
                Actors = actors.ToList(),
                Genres = genres.ToList()
            };
}