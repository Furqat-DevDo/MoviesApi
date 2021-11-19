using MoviesApi.Enteties;

namespace MoviesApi.Services
{
    public interface IActorService
    {
        Task<(bool IsSuccess, Exception Exception , Actor Actor)> CreateAsync(Actor actor);
        Task <List<Actor>> GetAllAsync();
        Task <Actor> GetAsync(Guid Id);
        Task <List<Actor>> GetAllAsync(string fullname);
        Task< (bool IsSuccess , Exception Exception)> DeleteAsync(Guid Id);
        Task <bool > ExsistAsync(Guid Id);
        Task <(bool IsSuccess, Exception Exception,Actor Actor)> UpdateAsync(Guid Id);
    }
}