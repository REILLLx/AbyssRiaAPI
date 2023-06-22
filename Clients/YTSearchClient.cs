using AutoriaProject.Models;
using Newtonsoft.Json;

namespace AutoriaProject.Clients;

public class YTSearchClient
{
    private HttpClient _httpClient;
    private string _ytApiKey;
    private string _ytAdress;

    public YTSearchClient()
    {
        _httpClient = new HttpClient();
        _ytAdress = Constants.ytAdress;
        _ytApiKey = Constants.ytApiKey;
        _httpClient.BaseAddress = new Uri(_ytAdress);
    }

    public async Task<YTSearch> GetVideo(string car)
    {
        var responce = await _httpClient.GetAsync($"/youtube/v3/search?part=snippet&q={car}&regionCode=US&type=video&relevanceLanguage=en&key={_ytApiKey}");
        responce.EnsureSuccessStatusCode();
        var content = await responce.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<YTSearch>(content);
        return result;
    }

}