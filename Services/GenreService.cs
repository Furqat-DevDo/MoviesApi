
using MoviesApi.Data;
using MoviesApi.Enteties;

namespace MoviesApi.Services
{
    public class GenreService : IGenreService
    {
        private readonly MoviesContext _gtx;

        public GenreService(MoviesContext gtx)
        {
          _gtx=gtx;
        }
        public async Task<(bool IsSuccess, Exception Exception, Genre Genre)> CreateAsync(Genre Genre)
        {
           try
           {
             await _gtx.Genres.AddAsync(Genre);
             await _gtx.SaveChangesAsync();
             return(true,null,Genre);
           }
           catch(Exception e)
           {
            return(false,e,null);
           }
        }

        public async Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid Id)
        {
          try
          {
            var genre=await GetAsync(Id);
            if(genre==default(Genre))
            {
                return(false,new Exception("Not Found"));
            }
            _gtx.Genres.Remove(genre);
           await  _gtx.SaveChangesAsync();
           return(true,null);
          }
          catch(Exception e)
          {
           return(false,e);
          }
        }

        public Task<bool> ExsistAsync(Guid id)
        =>_gtx.Genres.AnyAsync(a=>a.Id==id);

        public Task<List<Genre>> GetAllAsync()
        =>_gtx.Genres.
        AsNoTracking().
        Include(m=>m.Movies)
        .ToListAsync();

        public Task<Genre> GetAsync(Guid Id)
        =>_gtx.Genres.FirstOrDefaultAsync(m=>m.Id==Id);
        public async Task<bool> GetByNameAsync(string name)
        => await _gtx.Genres.AnyAsync(m=>m.Name==name);
      

        public async Task<(bool IsSuccess, Exception Exception, Genre Genre)> UpdateAsync(Genre genre)
        {
           try
           {
            if(!await ExsistAsync(genre.Id))
            {
            return(false, new Exception("Genre Was Not Found"),null);
            }
             _gtx.Genres.Update(genre);
             await _gtx.SaveChangesAsync();
             return(true,null,genre);
           }
           catch(Exception e)
           {
            return(false,e,null);
           }
        }
    }
}