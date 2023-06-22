using AutoriaProject.Models;
using AutoriaProject.Clients;
using Microsoft.AspNetCore.Mvc;

namespace AutoriaProject.Controllers;

[ApiController]
[Route("[controller]")]

public class GetIdsController : ControllerBase
{
    private readonly ILogger<GetIdsController> _logger;

    public GetIdsController(ILogger<GetIdsController> logger)
    {
        _logger = logger;
    }
    [HttpGet (Name = "GetIds")]
    public async Task<GetIds> GetIds(int markaId, int modelId, int price_ot, int price_do, int s_years, int po_years)
    {
        GetIdsClient getIdsClient = new GetIdsClient();
        var result = await getIdsClient.GetIds(markaId, modelId, price_ot, price_do, s_years, po_years);
        return result;
    }
}