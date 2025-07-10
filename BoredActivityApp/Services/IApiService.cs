
using System.Net.Http.Json;
using BoredActivityApp.Models;

using BoredActivityApp.Models;

namespace BoredActivityApp.Services;

public class ApiService : IApiService
{
    private const string BaseUrl = "https://bored-api.appbrewery.com/filter";
    private readonly HttpClient _http;

    public ApiService()
    {
        _http = new HttpClient();
    }

    public async Task<List<ActivityModel>> GetActivitiesAsync(string type, int participants)
    {
        var url = $"{BaseUrl}?type={type}&participants={participants}";
        var result = await _http.GetFromJsonAsync<List<ActivityModel>>(url);
        return result ?? new List<ActivityModel>();
    }

    Task<IEnumerable<object>> IApiService.GetActivitiesAsync(string selectedType, int selectedParticipants)
    {
        throw new NotImplementedException();
    }
}
