using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.About
{
    public partial class AboutUsPageViewModel : ObservableObject
    {
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
    }
}
