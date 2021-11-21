using MoviesApi.Enteties;

namespace MoviesApi.Services
{
    public interface IGenreService
    {
       Task<(bool IsSuccess, Exception Exception , Genre Genre)> CreateAsync(Genre Genre);
        Task <List<Genre>> GetAllAsync();
        Task <Genre> GetAsync(Guid Id);
        Task <bool> GetByNameAsync(string Name);
        Task< (bool IsSuccess , Exception Exception)> DeleteAsync(Guid Id);
        Task <bool > ExsistAsync(Guid Id);
        Task <(bool IsSuccess, Exception Exception,Genre Genre)> UpdateAsync(Genre genre);    
    }
}