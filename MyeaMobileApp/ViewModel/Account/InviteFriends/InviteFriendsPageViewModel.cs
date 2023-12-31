using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Account.InviteFriends
{
    public partial class InviteFriendsPageViewModel
    {
        // Navigate back to profile
        [RelayCommand]
        public async Task NavigateToProfilePage()
        {
            await Shell.Current.GoToAsync("///ProfilePage");
        }
    }
}
