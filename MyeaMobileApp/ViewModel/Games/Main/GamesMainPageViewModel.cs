using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Games.Main
{
    public partial class GamesMainPageViewModel : ObservableObject
    {
        // Open web games
        [RelayCommand]
        public async Task OpenWebGamesPage()
        {
            // Logic to open myecoapp.org page
            string url = "https://www.myecoapp.org/";
            await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
        }

        // Navigate home
        [RelayCommand]
        public async Task NavigateToPetigotchiPage()
        {
            await Shell.Current.GoToAsync("///PetigotchiPage");
        }

        // Navigate home
        [RelayCommand]
        public async Task NavigateToSnakePage()
        {
            await Shell.Current.GoToAsync("///SnakeGamePage");
        }

        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
