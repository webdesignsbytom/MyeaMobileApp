using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Newsletter
{
    public partial class NewsletterSignUpPageViewModel
    {
        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
