using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Services.User;

namespace MyeaMobileApp.ViewModel.Newsletter
{
    public partial class NewsletterSignUpPageViewModel : ObservableObject
    {
        // Login properties
        [ObservableProperty]
        public string? email;

        // Navigate home
        [RelayCommand]
        public async Task SendNewsletterSignup()
        {
            NewsletterApiService newsletterApiService = new ();
            await newsletterApiService.SignUpUserToNewsletterApi(Email);
        }

        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
