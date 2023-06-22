using AutoriaProject.Models;
using Newtonsoft.Json;

namespace AutoriaProject.Clients;

public class GetInfoClient
{
    private HttpClient _httpClient;
    private string _riaApiKey;
    private string _riaAdress;

    public GetInfoClient()
    {
        _httpClient = new HttpClient();
        _riaAdress = Constants.riaAdress;
        _riaApiKey = Constants.riaApiKey;
        _httpClient.BaseAddress = new Uri(_riaAdress);
    }

    public async Task<GetInfo> GetInfo(string id)
    {
        var responce = await _httpClient.GetAsync($"/auto/info?api_key={_riaApiKey}&auto_id={id}");
        responce.EnsureSuccessStatusCode();
        var content = await responce.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<GetInfo>(content);
        return result;
    }
}