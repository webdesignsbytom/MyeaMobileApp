using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Donations
{
    public partial class DonationsPageViewModel : ObservableObject
    {
        // Navigate contact
        [RelayCommand]
        public async Task NavigateToContactMainPage()
        {
            await Shell.Current.GoToAsync("///ContactMainPage");
        }        
        
        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
