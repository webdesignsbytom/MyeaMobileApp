using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model.User;
using MyeaMobileApp.Services.User;

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
            string id = User.UserId;
            await UserApi.DeleteUserAccountApi(id);

            User.UserIsLoggedIn = false;
            await Shell.Current.GoToAsync("///MainPage");
        }

        partial void OnIsDarkModeEnabledChanged(bool value)
        {
            // Handle the dark mode change
            // For example, update user preferences and apply the theme
            Console.WriteLine($"SSSSSSSSSSSSSSSSSSSSS {value}");
            User.IsDarkModeEnabled = value;
        }        
/*        public async void OnUserRegisteredForNewsletterChanged(bool value)
        {
            // Handle the dark mode change
            // For example, update user preferences and apply the theme
            Console.WriteLine($"SSSSSSSSSSSSSSSSSSSSS {value}");
            Console.WriteLine($"XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX {value}");
            if (UserRegisteredForNewsletter) 
            {
                bool answer = await App.Current.MainPage.DisplayAlert("Warning!", "Are you sure you wish to unsubscribe to the newsletter? Being part of the newsletter helps us earn through advertising!", "Yes", "No");
                Debug.WriteLine("Answer: " + answer);

                if (answer)
                {
                    // UN sub api
                }
            }
        }*/

        // Navigate back to profile
        [RelayCommand]
        public async Task NavigateToProfilePage()
        {
            await Shell.Current.GoToAsync("///ProfilePage");
        }
    }
}
