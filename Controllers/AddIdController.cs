using Microsoft.AspNetCore.Mvc;
using AutoriaProject.Models;
using AutoriaProject.Clients;

namespace AutoriaProject.Controllers;

[ApiController]
[Route("[controller]")]

public class AddIdController : ControllerBase
{
    private readonly ILogger<AddIdController> _logger;

    public AddIdController(ILogger<AddIdController> logger)
    {
        _logger = logger;
    }

    [HttpPost]

    public async Task<string> AddId(string id, long UserId)
    {
        DataBase db = new DataBase();
        await db.InsertIds(id, UserId);
        return id;
    }
}