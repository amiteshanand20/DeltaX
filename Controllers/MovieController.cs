using DeltaX.Entities;
using Deltax.Models;
using Deltax.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace Deltax.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class MovieController : ControllerBase
{
    private readonly ILogger<MasterController> _logger;
    private readonly IMovieServices _movieServices;

    public MovieController(IMovieServices movieServices, ILogger<MasterController> logger)
    {
        _logger = logger;
        _movieServices = movieServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMovies()
    {
        var response = _movieServices.GetAllMoviesAsync();
        if (response != null)
        {
            return Ok(response);
        }
        return NotFound();
    }

    [HttpGet]
    public async Task<IActionResult> GetMovieById([FromQueryAttribute] int movieId)
    {
        var response = _movieServices.GetMovieById(movieId);
        if(response != null)
        {
            return Ok(response);
        }
        return NotFound();
    }

    [HttpPut]
    public async Task<IActionResult> UpdateMovie([FromBody] MovieDTO movieDTO)
    {
        var response = _movieServices.UpdateMovie(movieDTO);
        if (response != null)
        {
            return Ok(response);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> CreateMovie([FromBody] MovieDTO movieDTO)
    {
        var response = _movieServices.CreateMovie(movieDTO);
        if (response != null)
        {
            return Ok(response);
        }
        return NotFound();
    }
}
