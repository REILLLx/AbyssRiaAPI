using Microsoft.AspNetCore.Mvc;
using AutoriaProject.Models;
using AutoriaProject.Clients;

namespace AutoriaProject.Controllers;
[ApiController]
[Route("[controller]")]
public class GetInfoController : ControllerBase
{
    private readonly ILogger<GetInfoController> _logger;

    public GetInfoController(ILogger<GetInfoController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetInfo")]

    public async Task<GetInfo> GetInfo(string id)
    {
        GetInfoClient getInfoClient = new GetInfoClient();
        var result = await getInfoClient.GetInfo(id);
        return result;
    }
}