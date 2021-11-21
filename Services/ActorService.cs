using MoviesApi.Data;
using MoviesApi.Enteties;

namespace MoviesApi.Services
{
    public class ActorService : IActorService
    {
        private readonly MoviesContext _act;

        public ActorService(MoviesContext act)
        {
           _act=act; 
        }
        public async Task<(bool IsSuccess, Exception Exception, Actor Actor)> CreateAsync(Actor actor)
        {
           try
           {
             await _act.Actors.AddAsync(actor);
             await _act.SaveChangesAsync();
             return (true,null,actor);
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
             var actor = await GetAsync(Id);
             if(actor == default(Actor))
             {
               return(false,new Exception("Not Found"));
             }
             _act.Actors.Remove(actor);
             await  _act.SaveChangesAsync();
             return(true,null);
            
            }
            catch(Exception e)
            {
             return(false,e);
            }
        }

        public Task<bool> ExsistAsync(Guid ID)
        =>_act.Actors.AnyAsync(w=>w.Id==ID);

        public Task<List<Actor>> GetAllAsync()
        =>_act.Actors
        .AsNoTracking()
        .Include(m=>m.Movies)
        .ToListAsync();

        public Task<List<Actor>> GetAllAsync(string fullname)
        =>_act.Actors.
        AsNoTracking()
        .Where(m=>m.Fullname == fullname)
        .Include(w=>w.Movies)
        .ToListAsync();
        public Task<Actor> GetAsync(Guid ID)
        =>_act.Actors.FirstOrDefaultAsync(k=>k.Id==ID);
        
        public async Task<(bool IsSuccess, Exception Exception, Actor Actor)> UpdateAsync(Actor actor)
        {
          try
          {
           if(! await ExsistAsync(actor.Id))
           {
             return(false,new Exception("Actor was not Found"),null);
           }
           _act.Actors.Update(actor);
           await _act.SaveChangesAsync();
           return(true,null,actor);
          }
          catch(Exception e)
          {
            return (false,e,null);
          }
        }
    }
}