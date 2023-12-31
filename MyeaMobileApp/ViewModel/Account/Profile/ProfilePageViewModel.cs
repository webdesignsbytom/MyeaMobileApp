using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model;

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
/*            FirstName = UserProfile.FirstName;
            LastName = UserProfile.LastName;
            Score = UserProfile.Score;*/
        }

        [RelayCommand]
        public void LogoutUserCommand()
        {
            User.LogoutUserFromApp();
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
