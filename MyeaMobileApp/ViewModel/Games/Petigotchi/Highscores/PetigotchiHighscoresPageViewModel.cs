using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Games.Petigotchi.Highscores
{
    public partial class PetigotchiHighscoresPageViewModel
    {
        // Navigate home
        [RelayCommand]
        public async Task NavigateToPetigotchiGame()
        {
            await Shell.Current.GoToAsync("///PetigotchiPage");
        }        
        
        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
