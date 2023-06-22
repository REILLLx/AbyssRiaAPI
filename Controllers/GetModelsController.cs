using Microsoft.AspNetCore.Mvc;
using AutoriaProject.Clients;
using AutoriaProject.Models;

namespace AutoriaProject.Controllers;

[ApiController]
[Route("[controller]")]

public class GetModelsController : ControllerBase
{
    private readonly ILogger<GetModelsController> _logger;

    public GetModelsController(ILogger<GetModelsController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet (Name = "GetModels")]
    
    public async Task<List<Model>> GetModels (int markId)
    {
        GetModelClient getModelClient = new GetModelClient();
        var result1 = await getModelClient.GetModels(markId);
        return result1;
    }
}