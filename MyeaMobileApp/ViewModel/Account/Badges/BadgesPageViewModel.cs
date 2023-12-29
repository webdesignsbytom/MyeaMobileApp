using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Account.Badges
{
    public partial class BadgesPageViewModel
    {
        // Navigate back to profile
        [RelayCommand]
        public async Task NavigateToProfilePage()
        {
            await Shell.Current.GoToAsync("///ProfilePage");
        }
    }
}
