using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model;
using System.Diagnostics;

namespace MyeaMobileApp.ViewModel.Main
{
    public partial class MainPageViewModel : ObservableObject
    {
        public UserModel User { get; set; }
        public MainPageViewModel(UserModel userModel)
        {
            User = userModel;
        }

        [RelayCommand]
        public async Task NavigateToAboutUsPage()
        {
            await Shell.Current.GoToAsync("///AboutUsPage");
        }            
        
        [RelayCommand]
        public async Task NavigateToLoginPage()
        {
            await Shell.Current.GoToAsync("///LoginPage");
        }        
        
        [RelayCommand]
        public async Task NavigateToNewReelPage()
        {
            await Shell.Current.GoToAsync("///NewsReelPage");
        }        
        
        [RelayCommand]
        public async Task NavigateToRegisterPage()
        {
            await Shell.Current.GoToAsync("///RegisterPage");
        }    
        
        [RelayCommand]
        public async Task NavigateToLotteryPage()
        {
            await Shell.Current.GoToAsync("///LotteryMainPage");
        }             
        
        [RelayCommand]
        public async Task NavigateToFundingPage()
        {
            await Shell.Current.GoToAsync("///FundingPage");
        }            
        
        [RelayCommand]
        public async Task NavigateToGoalsPage()
        {
            await Shell.Current.GoToAsync("///GoalsPage");
        }        
        
        [RelayCommand]
        public async Task NavigateToUsersAccount()
        {
            if (User.UserIsLoggedIn)
            {
                Debug.WriteLine($"Logged in as {User.Username}");
                await Shell.Current.GoToAsync("///ProfilePage");
            }
            else
            {
                Debug.WriteLine($"Not logged in");
                await Shell.Current.GoToAsync("///LoginOrRegisterPage");
            }
        }

    }
}
