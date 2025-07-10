using BoredActivityApp.Models;
using Microsoft.Maui.Controls;

namespace BoredActivityApp.ViewModels;

public class DetailViewModel : BaseViewModel, IQueryAttributable
{
    private ActivityModel _activity;
    public ActivityModel Activity
    {
        get => _activity;
        set { _activity = value; OnPropertyChanged(); }
    }

    private void OnPropertyChanged()
    {
        throw new NotImplementedException();
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.ContainsKey("activity"))
            Activity = query["activity"] as ActivityModel;
    }
}
