using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Account.Profile
{
    public partial class ProfilePageViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task NavigateToBadgesPage()
        {
            await Shell.Current.GoToAsync("///BadgesPage");
        }
    }
}
