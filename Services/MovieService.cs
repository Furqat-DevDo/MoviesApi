using MoviesApi.Data;
using MoviesApi.Enteties;

namespace MoviesApi.Services
{   
    public class MovieService : IMovieService
    {
    private readonly MoviesContext _ctx;

    public MovieService(MoviesContext context)
    {
        _ctx = context;
    }
    public Task<List<Movie>> GetAllAsync(string title)
        => _ctx.Movies
            .AsNoTracking()
            .Where(a => a.Title == title)
            .Include(m => m.Actors)
            .Include(m => m.Genres)
            .ToListAsync();
    public async Task<(bool IsSuccess, Exception Exception, Movie Movie)> UpdateAsync(Movie movie)
    {
       if(!await ExsistAsync(movie.Id))
       {
         return (false, new ArgumentException($"There is no Movie with given ID: {movie.Id}"), null);
       }
       _ctx.Update(movie);
       await _ctx.SaveChangesAsync();

       return (true, null,movie);
    }

    public async Task<(bool IsSuccess, Exception Exception, Movie Movie)> CreateAsync(Movie movie)
    {
        try
        {
        await _ctx.Movies.AddAsync(movie);
        await _ctx.SaveChangesAsync();

        return (true, null, movie);
        }
        catch(Exception e)
        {
        return (false, e, null);
        }
    }

    public Task<List<Movie>> GetAllAsync()
         => _ctx.Movies
            .AsNoTracking()
            .Include(m => m.Actors)
            .Include(m => m.Genres)
            .ToListAsync();
        
    public Task<Movie> GetAsync(Guid id)
         => _ctx.Movies.FirstOrDefaultAsync(a => a.Id == id);
    public  async Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid Id)
    {
        try
        {
          var movie = await GetAsync(Id);

          if(movie == default(Movie))
          {
            return (false, new Exception("Not found"));
          }

          _ctx.Movies.Remove(movie);
          await _ctx.SaveChangesAsync();

          return (true,  null);
        }
        catch(Exception e)
        {
            return (false, e);
        }
    }

     public Task<bool> ExsistAsync(Guid id)
        => _ctx.Movies.AnyAsync(a => a.Id == id);
        
    }
}
   
