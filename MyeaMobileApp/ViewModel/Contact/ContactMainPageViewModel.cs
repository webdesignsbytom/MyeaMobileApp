using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Contact
{
    public partial class ContactMainPageViewModel : ObservableObject
    {
        [ObservableProperty]
        public string? searchQuery;

        // Search for item
        [RelayCommand]
        public async Task PerformSearch()
        {
            return;
        }

        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
