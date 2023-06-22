using Microsoft.AspNetCore.Mvc;
using AutoriaProject.Models;
using AutoriaProject.Clients;

namespace AutoriaProject.Controllers;

[ApiController]
[Route("[controller]")]

public class GetPlacesController : ControllerBase
{
    private readonly ILogger<GetPlacesController> _logger;

    public GetPlacesController(ILogger<GetPlacesController> logger)
    {
        _logger = logger;
    }
    [HttpGet(Name = "GetPlaces")]
    public async Task<ActionResult<GetPlaces>> GetPlaces(string area)
    {
        GetPlacesClient getPlacesClient = new GetPlacesClient();
        var result1 = await getPlacesClient.GetPlaces(area);
        return result1;
    }
}