using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model.User;
using MyeaMobileApp.Services.User;
using System.Diagnostics;

namespace MyeaMobileApp.ViewModel.Account.Manage
{
    public partial class ManageAccountPageViewModel : ObservableObject
    {
        public NewsletterApiService NewsletterApi { get; set; }
        public UserApiService UserApi { get; set; }
        public UserModel User { get; set; }

        [ObservableProperty]
        private bool isDarkModeEnabled;

        [ObservableProperty]
        private bool isRegisteredNewsletter3;

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

/*        private async void OnIsRegisteredNewsletter3Changed(bool value)
        {
            try
            {
                if (!value)
                {
                    Console.WriteLine("11111111111111111111111");

                    bool answer = await ConfirmUnsubscribeNewsletter();
                    if (answer)
                    {
                        // Unsubscribe logic here
                        Console.WriteLine("User unsubscribed.");
                        IsRegisteredNewsletter3 = value;
                    }
                }
                else
                {
                    await SignUserUpForNewsletter();
                    IsRegisteredNewsletter3 = value;
                    Console.WriteLine("User signed up for newsletter.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                // Handle error (e.g., show error message to user)
            }
        }*/


        public async Task SignUserUpForNewsletter()
        {
            await NewsletterApi.SignUpUserToNewsletterApi(User.UserId, User.Email);
        }

        public async Task<bool> ConfirmUnsubscribeNewsletter()
        {
            Console.WriteLine("CCCCCCCCCCCCCCCCCCCC");

            bool answer = await App.Current.MainPage.DisplayAlert("Warning!", "Are you sure you wish to unsubscribe for the newsletter?", "Yes", "No");
            Debug.WriteLine("Answer: " + answer);

            return answer;
        }


        // Navigate back to profile
        [RelayCommand]
        public async Task NavigateToProfilePage()
        {
            await Shell.Current.GoToAsync("///ProfilePage");
        }
    }
}
