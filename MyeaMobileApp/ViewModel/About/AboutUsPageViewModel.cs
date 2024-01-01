using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.About
{
    public partial class AboutUsPageViewModel : ObservableObject
    {
        // Open shop externally
        [RelayCommand]
        public async Task NavigateAwayToShop()
        {
            string url = "https://google.com";
            await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
        }

        // Navigate To Goals Page
        [RelayCommand]
        public async Task NavigateToGoalsPage()
        {
            await Shell.Current.GoToAsync("///GoalsPage");
        }        
        
        // Sign up to newsletter
        [RelayCommand]
        public async Task SignUpToNewsLetter()
        {
            await Shell.Current.GoToAsync("///NewsletterSignUpPage");
        }

        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
