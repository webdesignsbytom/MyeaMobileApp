using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model;
using MyeaMobileApp.Model.User;
using System.Diagnostics;

namespace MyeaMobileApp.ViewModel.Account.Profile
{
    public partial class ProfilePageViewModel : ObservableObject
    {
        // User model data
        public UserModel User { get; set; }
        public ProfileModel UserProfile { get; set; }

        // User properties
        [ObservableProperty]
        public string? email;        

        [ObservableProperty]
        public string? firstName;        
        
        [ObservableProperty]
        public string? lastName;        
        
        [ObservableProperty]
        public int? score;

        public ProfilePageViewModel(UserModel user, ProfileModel profileModel)
        {
            User = user;
            UserProfile = profileModel;

            Email = User.Email;
            FirstName = UserProfile.FirstName;
            LastName = UserProfile.LastName;
            Score = UserProfile.Score;
        }

        [RelayCommand]
        public async Task LogoutUserFromApp()
        {
            bool answer = await App.Current.MainPage.DisplayAlert("Warning!", "Are you sure you wish to logout?", "Yes", "No");
            Debug.WriteLine("Answer: " + answer);

            if (answer) 
            { 
                User.LogoutUserFromApp();
                await Shell.Current.GoToAsync("///MainPage");           
            }
        }

        [RelayCommand]
        public async Task NavigateToManageSettingsPage()
        {
            if (!User.UserIsLoggedIn)
            {
                await Shell.Current.GoToAsync("///LoginPage");
            }
            else
            {
                await Shell.Current.GoToAsync("///ManageAccountPage");
            }
        }        
        
        [RelayCommand]
        public async Task NavigateToEditProfilePage()
        {
            if (!User.UserIsLoggedIn)
            {
                await Shell.Current.GoToAsync("///LoginPage");
            }
            else
            {
                await Shell.Current.GoToAsync("///EditProfilePage");
            }
        }

        [RelayCommand]
        public async Task NavigateToBadgesPage()
        {
            await Shell.Current.GoToAsync("///BadgesPage");
        }              
        
        [RelayCommand]
        public async Task NavigateToInviteFriendsPage()
        {
            await Shell.Current.GoToAsync("///InviteFriendsPage");
        }        
        
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
