using AutoriaProject.Clients;
using AutoriaProject.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AutoriaProject.Controllers;

[ApiController]
[Route ("[controller]")]
public class YTSearchController : ControllerBase
{
    private readonly ILogger<YTSearchController> _logger;

    public YTSearchController(ILogger<YTSearchController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetVideo")]
    public async Task<YTSearch> GetVideo(string car)
    {
        YTSearchClient ytSearchClient = new YTSearchClient();
        var result = await ytSearchClient.GetVideo(car);
        return result;
    }
}