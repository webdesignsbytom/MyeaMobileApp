using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model.User;
using MyeaMobileApp.Services.User;
using System.Diagnostics;

namespace MyeaMobileApp.ViewModel.Account.Manage
{
    public partial class ManageAccountPageViewModel : ObservableObject
    {
        public UserApiService UserApi { get; set; }
        public UserModel User { get; set; }

        [ObservableProperty]
        private bool isDarkModeEnabled;        
        
        [ObservableProperty]
        private bool userRegisteredForNewsletter;        
        
        [ObservableProperty]
        private bool userWantsToDisplayPetIcon;

        public ManageAccountPageViewModel(UserModel user, UserApiService userApiService) 
        {
            User = user;
            UserApi = userApiService;
/*            IsDarkModeEnabled = User.IsDarkModeEnabled;
            UserRegisteredForNewsletter = User.UserRegisteredForNewsletter;*/
        }

        // Delete api
        [RelayCommand]
        async Task DeleteUserAccount()
        {
            bool answer = await App.Current.MainPage.DisplayAlert("Warning!", "Are you sure you wish to delete your account? This will delete you across all myecoapp products", "Yes", "No");
            Debug.WriteLine("Answer: " + answer);

            if (answer)
            {
                string id = User.UserId;
                await UserApi.DeleteUserAccountApi(id);

                User.UserIsLoggedIn = false;
                await Shell.Current.GoToAsync("///MainPage");
            }
        }


        partial void OnIsDarkModeEnabledChanged(bool value)
        {
            User.IsDarkModeEnabled = value;
        }           
        
        partial void OnUserWantsToDisplayPetIconChanged(bool value)
        {
            User.UserWantsToDisplayPetIcon = value;
        }


        // Navigate back to profile
        [RelayCommand]
        public async Task NavigateToProfilePage()
        {
            await Shell.Current.GoToAsync("///ProfilePage");
        }
    }
}
