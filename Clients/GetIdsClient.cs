using AutoriaProject.Models;
using Newtonsoft.Json;
namespace AutoriaProject.Clients;

public class GetIdsClient
{
    private HttpClient _httpClient;
    private string _riaApiKey;
    private string _riaAdress;

    public GetIdsClient()
    {
        _httpClient = new HttpClient();
        _riaAdress = Constants.riaAdress;
        _riaApiKey = Constants.riaApiKey;
        _httpClient.BaseAddress = new Uri(_riaAdress);
    }
    public async Task<GetIds> GetIds(int markaId, int modelId, int price_ot, int price_do, int s_years, int po_years)
    {
        var response = await _httpClient.GetAsync($"/auto/search?api_key={_riaApiKey}&category_id=1&marka_id={markaId}&model_id={modelId}&price_ot={price_ot}&price_do={price_do}&s_yers={s_years}&po_years={po_years}");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<GetIds>(content);
        return result;
    }
}