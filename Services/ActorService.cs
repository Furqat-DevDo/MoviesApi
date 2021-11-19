using MoviesApi.Enteties;

namespace MoviesApi.Services
{
    public class ActorService : IActorService
    {
        public Task<(bool IsSuccess, Exception Exception, Actor Actor)> CreateAsync(Actor actor)
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

        public Task<List<Actor>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Actor>> GetAllAsync(string fullname)
        {
            throw new NotImplementedException();
        }

        public Task<Actor> GetAsync(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool IsSuccess, Exception Exception, Actor Actor)> UpdateAsync(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}