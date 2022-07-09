using Deltax.Models;
using Deltax.Services;
using Microsoft.AspNetCore.Mvc;

namespace Deltax.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ProducerController : ControllerBase
{
    private readonly ILogger<MasterController> _logger;
    private readonly IProducerServices _producerServices;

    public ProducerController(IProducerServices producerServices, ILogger<MasterController> logger)
    {
        _logger = logger;
        _producerServices = producerServices;
    }

    [HttpGet]
    public async Task<IActionResult> GetProducersList()
    {
        var response = _producerServices.GetProducersListAsync();
        if (response != null)
        {
            return Ok(response);
        }
        return NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> AddProducer([FromBodyAttribute] ProducerDTO producerDTO)
    {
        var response = _producerServices.AddProducer(producerDTO);
        if (response != null)
        {
            return Ok(response);
        }
        return NotFound();
    }
}
