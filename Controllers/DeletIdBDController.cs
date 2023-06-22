using Microsoft.AspNetCore.Mvc;
using AutoriaProject.Clients;
using AutoriaProject.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AutoriaProject.Controllers;

[ApiController]
[Route("[controller]")]

public class DeleteIdBDController : ControllerBase
{
    private readonly ILogger<DeleteIdBDController> _logger;

    public DeleteIdBDController(ILogger<DeleteIdBDController> logger)
    {
        _logger = logger;
    }

    [HttpDelete(Name = "DeleteDBIds")]

    public async Task DeleteIds(string id, long userId)
    {
        DataBase db = new DataBase();
        await db.DeleteIds(id, userId);
    }
}