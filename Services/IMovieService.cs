using MoviesApi.Enteties;

namespace MoviesApi.Services
{
    public interface IMovieService
    {
        Task<(bool IsSuccess, Exception Exception , Movie Movie)> CreateAsync(Movie Movie);
        Task <List<Movie>> GetAllAsync();
        Task <Movie> GetAsync(Guid Id);
        Task< (bool IsSuccess , Exception Exception)> DeleteAsync(Guid Id);
        Task <bool > ExsistAsync(Guid Id);
        Task <(bool IsSuccess, Exception Exception,Movie Movie)> UpdateAsync(Movie movie);  
    }
}