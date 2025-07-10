using System.Collections.ObjectModel;
using System.Windows.Input;
using BoredActivityApp.Models;
using BoredActivityApp.Services;
using Microsoft.Maui.Controls;

namespace BoredActivityApp.ViewModels;

public class MainViewModel : BaseViewModel
{
    private readonly IApiService _apiService;

    public ObservableCollection<ActivityModel> Activities { get; } = new();
    public List<string> Types { get; } = new() { "Education", "Recreational", "Social", "Charity", "Cooking", "Relaxation", "Busywork" };
    public List<int> ParticipantsOptions { get; } = Enumerable.Range(1, 8).ToList();

    private string _selectedType;
    public string SelectedType
    {
        get => _selectedType;
        set { _selectedType = value; OnPropertyChanged(); }
    }

    private void OnPropertyChanged()
    {
        throw new NotImplementedException();
    }

    private int _selectedParticipants = 1;
    public int SelectedParticipants
    {
        get => _selectedParticipants;
        set { _selectedParticipants = value; OnPropertyChanged(); }
    }

    public ICommand SearchCommand { get; }
    public ICommand SelectCommand { get; }

    public MainViewModel(IApiService api)
    {
        _apiService = api;
        SearchCommand = new Command(async () => await LoadActivities());
        SelectCommand = new Command<ActivityModel>(async a => {
            await Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
            {
                ["activity"] = a
            });
        });
    }

    private async Task LoadActivities()
    {
        Activities.Clear();
        var list = await _apiService.GetActivitiesAsync(SelectedType, SelectedParticipants);
        if (!list.Any())
        {
            // prikaži poruku  
            Activities.Add(new ActivityModel { Activity = "No activities found.", Type = "", Participants = 0 });
            return;
        }
        foreach (var item in list.Cast<ActivityModel>()) // Ensure the items are cast to ActivityModel  
            Activities.Add(item);
    }
}