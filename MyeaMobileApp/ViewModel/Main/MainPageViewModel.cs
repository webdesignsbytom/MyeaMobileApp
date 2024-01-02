using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model;
using MyeaMobileApp.Model.User;

namespace MyeaMobileApp.ViewModel.Main
{
    public partial class MainPageViewModel : ObservableObject
    {
        public UserModel User { get; set; }
        public ProfileModel UserProfile { get; set; }

        // Users name
        [ObservableProperty]
        public string? firstName;

        public MainPageViewModel(UserModel userModel, ProfileModel userProfile)
        {
            User = userModel;
            UserProfile = userProfile;
            LoadData();
        }

        public async Task LoadData()
        {
            string userFirstName = await SecureStorage.Default.GetAsync("user_firstName") ?? string.Empty;
            FirstName = userFirstName;
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
        public async Task NavigateToServicesPage()
        {
            await Shell.Current.GoToAsync("///ServicesPage");
        }           
        
        [RelayCommand]
        public async Task NavigateToAppsMainPage()
        {
            await Shell.Current.GoToAsync("///AppsMainPage");
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
        public async Task NavigateToTimelinePage()
        {
            await Shell.Current.GoToAsync("///TimelinePage");
        }           
        
        [RelayCommand]
        public async Task NavigateToGamesPage()
        {
            await Shell.Current.GoToAsync("///GamesMainPage");
        }           
        
        [RelayCommand]
        public async Task NavigateToMediaMainPage()
        {
            await Shell.Current.GoToAsync("///MediaCampaignMainPage");
        }        
        
        [RelayCommand]
        public async Task NavigateToUsersAccount()
        {
            if (User.UserIsLoggedIn)
            {
                await Shell.Current.GoToAsync("///ProfilePage");
            }
            else
            {
                await Shell.Current.GoToAsync("///LoginPage");
            }
        }

    }
}
