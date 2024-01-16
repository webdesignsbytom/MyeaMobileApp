using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Games.Snake
{
    public partial class SnakeGamePageViewModel : ObservableObject
    {
        // Navigate back
        [RelayCommand]
        public async Task NavigateToBackToGameMain()
        {
            await Shell.Current.GoToAsync("///GamesMainPage");
        }
    }
}
