using AutoriaProject.Models;
using Newtonsoft.Json;
namespace AutoriaProject.Clients;

public class GetModelClient
{
    private HttpClient _httpClient;
    private string _riaApiKey;
    private string _riaAdress;

    public GetModelClient()
    {
        _httpClient = new HttpClient();
        _riaAdress = Constants.riaAdress;
        _riaApiKey = Constants.riaApiKey;
        _httpClient.BaseAddress = new Uri(_riaAdress);
    }

    public async Task<List<Model>> GetModels(int markId)
    {
        var responce5 = await _httpClient.GetAsync($"/auto/categories/1/marks/{markId}/models?api_key={_riaApiKey}");
        responce5.EnsureSuccessStatusCode();
        var content5 = await responce5.Content.ReadAsStringAsync();
        var result5 = JsonConvert.DeserializeObject<List<Model>>(content5);
        return result5;
    }
}