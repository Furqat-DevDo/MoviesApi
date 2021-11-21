using System.Text.Json;
using MoviesApi.Mappers;
using MoviesApi.Models;
using MoviesApi.Services;

namespace MoviesApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly IMovieService _ms;
    private readonly IActorService _as;
    private readonly IGenreService _gs;

    public MovieController(
        IMovieService movieService,
        IGenreService genreService,
        IActorService actorService)
    {
        _ms = movieService;
        _as = actorService;
        _gs = genreService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(NewMovie movie)
    {
        if(movie.ActorIds.Count() < 1 || movie.GenreIds.Count() < 1)
        {
            return BadRequest("Actors and Genres are required");
        }

        if(!movie.GenreIds.All(id => _gs.ExsistAsync(id).Result))
        {
            return BadRequest("Genre doesnt exist");
        }

        if(!movie.ActorIds.All(id => _as.ExsistAsync(id).Result))
        {
            return BadRequest("Actor doesnt exist");
        }

        var genres = movie.GenreIds.Select(id => _gs.GetAsync(id).Result);
        var actors = movie.ActorIds.Select(id => _as.GetAsync(id).Result);
        
        var result = await _ms.CreateAsync(movie.ToEntity(actors, genres));

        if(result.IsSuccess)
        {
            return Ok();
        }

        return BadRequest(result.Exception.Message);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        JsonSerializerOptions options = new()
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };

        var json = JsonSerializer.Serialize(await _ms.GetAllAsync(), options);
        return Ok(json);
    }
}