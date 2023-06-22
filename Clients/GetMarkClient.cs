using AutoriaProject.Models;
using Newtonsoft.Json;
namespace AutoriaProject.Clients;


public class GetMarkClient
{
    private HttpClient _httpClient;
    private string _riaApiKey;
    private string _riaAdress;

    public GetMarkClient()
    {
        _httpClient = new HttpClient();
        _riaAdress = Constants.riaAdress;
        _riaApiKey = Constants.riaApiKey;
        _httpClient.BaseAddress = new Uri(_riaAdress);
    }

    public async Task<List<Mark>> GetMarks()
    {
        var responce4 = await _httpClient.GetAsync($"/auto/categories/1/marks?api_key={_riaApiKey}");
        responce4.EnsureSuccessStatusCode();
        var content4 = await responce4.Content.ReadAsStringAsync();
        var result4 = JsonConvert.DeserializeObject<List<Mark>>(content4);
        return result4;
    }
}