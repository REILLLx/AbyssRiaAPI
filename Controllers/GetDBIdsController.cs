using Microsoft.AspNetCore.Mvc;
using AutoriaProject.Clients;
using AutoriaProject.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AutoriaProject.Controllers;

[ApiController]
[Route("[controller]")]

public class GetDBIdsController
{
    private readonly ILogger<GetDBIdsController> _logger;

    public GetDBIdsController(ILogger<GetDBIdsController> logger)
    {
        _logger = logger;
    }
    [HttpGet(Name = "GetDBIds")]
    public async Task<List<string>> GetDBIds(long UserId)
    {
        DataBase db = new DataBase();
        return await db.SelectIds(UserId);
    } 
}