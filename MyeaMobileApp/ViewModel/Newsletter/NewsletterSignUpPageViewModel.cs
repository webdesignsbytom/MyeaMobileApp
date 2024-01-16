using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model.User;
using MyeaMobileApp.Services.User;

namespace MyeaMobileApp.ViewModel.Newsletter
{
    public partial class NewsletterSignUpPageViewModel : ObservableObject
    {
        public UserModel User {  get; set; }

        // Login properties
        [ObservableProperty]
        public string? email;

        public NewsletterSignUpPageViewModel(UserModel user)
        {
            User = user;
        }

        // Navigate home
        [RelayCommand]
        public async Task SendNewsletterSignup()
        {
            NewsletterApiService newsletterApiService = new ();
            await newsletterApiService.SignUpUserToNewsletterApi(User.UserId, User.Email);
        }

        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
