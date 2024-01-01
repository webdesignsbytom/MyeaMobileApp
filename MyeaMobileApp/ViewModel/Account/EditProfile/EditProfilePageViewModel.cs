using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model;

namespace MyeaMobileApp.ViewModel.Account.EditProfile
{
    public partial class EditProfilePageViewModel : ObservableObject
    {

        [ObservableProperty]
        public ProfileModel userProfile;

        public EditProfilePageViewModel(ProfileModel userProfile)
        {
            UserProfile = userProfile;
        }

        // Update Profile Command
        [RelayCommand]
        async Task UpdateProfile()
        {
            // Logic to update the profile
            // This might involve calling an API service to update the user profile on the server
            // After updating, you can navigate back to the profile page or show a success message

            await Shell.Current.GoToAsync("///ProfilePage");
        }

        // Navigate back to profile
        [RelayCommand]
        public async Task NavigateToProfilePage()
        {
            await Shell.Current.GoToAsync("///ProfilePage");
        }
    }
}
