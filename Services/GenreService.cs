
using MoviesApi.Enteties;

namespace MoviesApi.Services
{
    public class GenreService : IGenreService
    {
        public Task<(bool IsSuccess, Exception Exception, Genre Genre)> CreateAsync(Genre Genre)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, Exception Exception)> DeleteAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ExsistAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Genre>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Genre> GetAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Genre>> GetByName(string Name)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, Exception Exception, Genre Genre)> UpdateAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}