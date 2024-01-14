using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Events.Main
{
    public partial class EventsMainPageViewModel : ObservableObject
    {
        // Create event 
        [RelayCommand]
        public async Task NavigateToCreateEventPage()
        {
            await Shell.Current.GoToAsync("///CreateEventPage");
        }        
        
        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
