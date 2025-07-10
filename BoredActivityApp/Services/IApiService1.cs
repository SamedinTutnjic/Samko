
namespace BoredActivityApp.Services
{
    public interface IApiService
    {
        Task<IEnumerable<object>> GetActivitiesAsync(string selectedType, int selectedParticipants);
    }
}