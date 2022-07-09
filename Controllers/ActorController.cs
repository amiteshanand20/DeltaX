using Deltax.Models;
using Deltax.Services;
using Microsoft.AspNetCore.Mvc;

namespace Deltax.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ActorController : ControllerBase
{
    private readonly ILogger<MasterController> _logger;
    private readonly IActorServices _actorService;

    public ActorController(IActorServices actorService, ILogger<MasterController> logger)
    {
        _logger = logger;
        _actorService = actorService;
    }

    [HttpGet]
    public async Task<ActionResult> GetActorsList()
    {
        var response = _actorService.GetActorsListAsync();
        if(response != null)
        {
            return Ok(response);    
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult> AddActor([FromBodyAttribute] ActorDTO actorDTO)
    {
        var response = _actorService.AddActor(actorDTO);
        if (response != null)
        {
            return Ok(response);
        }
        return NotFound();
    }
}
