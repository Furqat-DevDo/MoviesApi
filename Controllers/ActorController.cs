global using Microsoft.AspNetCore.Mvc;
using MoviesApi.Mappers;
using MoviesApi.Models;
using MoviesApi.Services;

namespace MoviesApi.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ActorController : ControllerBase
{
    private readonly IActorService _as;

    public ActorController(IActorService actorService)
    {
        _as = actorService;
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(NewActor actor)
    {
        var result = await _as.CreateAsync(actor.ToEntity());

        if(result.IsSuccess)
        {
            return Ok();
        }

        return BadRequest(result.Exception.Message);
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
        => Ok(await _as.GetAllAsync());
}