using AutoriaProject.Models;
using Newtonsoft.Json;
namespace AutoriaProject.Clients;

public class GetPlacesClient
{
    private HttpClient _httpClient;
    private string _mapsApiKey;
    private string _mapsAdress;

    public GetPlacesClient()
    {
        _httpClient = new HttpClient();
        _mapsAdress = Constants.mapsAdress;
        _mapsApiKey = Constants.mapsApiKey;
        _httpClient.BaseAddress = new Uri(_mapsAdress);
    }

    public async Task<GetPlaces> GetPlaces(string area)
    {
        var responce5 = await _httpClient.GetAsync($"/maps/api/place/textsearch/json?query=Автомайстерні+в+{area}&types=car_repair&key={_mapsApiKey}");
        responce5.EnsureSuccessStatusCode();
        var content5 = await responce5.Content.ReadAsStringAsync();
        var result5 = JsonConvert.DeserializeObject<GetPlaces>(content5);
        return result5;
    }
}