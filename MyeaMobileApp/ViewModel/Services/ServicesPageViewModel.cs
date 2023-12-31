using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Services
{
    public partial class ServicesPageViewModel
    {
        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
