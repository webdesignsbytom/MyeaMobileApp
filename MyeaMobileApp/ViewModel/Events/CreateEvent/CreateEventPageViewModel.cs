using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Events.CreateEvent
{
    public partial class CreateEventPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public string? title;          
        
        [ObservableProperty]
        public string? description;            
        
        [ObservableProperty]
        public string? location;        
        
        [ObservableProperty]
        public DateTime? eventDate;

        // Navigate back ot events main
        [RelayCommand]
        public async Task NavigateToEventsMainPage()
        {
            await Shell.Current.GoToAsync("///EventsMainPage");
        }
    }
}
