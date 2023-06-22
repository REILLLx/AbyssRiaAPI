using Microsoft.AspNetCore.Mvc;
using AutoriaProject.Clients;
using AutoriaProject.Models;

namespace AutoriaProject.Controllers;

[ApiController]
[Route("[controller]")]

public class GetMarksController : ControllerBase
{
    private readonly ILogger<GetMarksController> _logger;

    public GetMarksController(ILogger<GetMarksController> logger)
    {
        _logger = logger;
    }
    [HttpGet(Name = "GetMarks")]
    public async Task<ActionResult<List<Mark>>> GetMarkId()
    {
        GetMarkClient getMarkClient = new GetMarkClient();
        var result1 = await getMarkClient.GetMarks();
        return result1;
    }
}