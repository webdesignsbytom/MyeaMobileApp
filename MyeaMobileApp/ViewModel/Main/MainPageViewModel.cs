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

        // User type
        [ObservableProperty]
        private bool isAdmin;        
        
        [ObservableProperty]
        private bool isDev;

        [ObservableProperty]
        private bool isLevelUpPopupVisible;        
        
        [ObservableProperty]
        private bool userWantsToDisplayPetIcon;

        // Users name
        [ObservableProperty]
        public string? firstName;

        [ObservableProperty]
        private bool isFirstTimePopupVisible;

        public MainPageViewModel(UserModel userModel, ProfileModel userProfile)
        {
            User = userModel;
            UserProfile = userProfile;
            CheckForFirstUse();
            LoadData();
        }

        // Check to display welcome message
        public async Task CheckForFirstUse()
        {
            if (User.IsFirstTimeOpeningApp)
            {
                IsFirstTimePopupVisible = true;
                User.IsFirstTimeOpeningApp = false; // update the user model to reflect that the first launch has been acknowledged
                                                    // You might want to save this change to your data store or preferences
                await LoadStarterDataFromServer();

            }
        }

        private async Task LoadStarterDataFromServer()
        {

        }

        public async Task LoadData()
        {
            string userFirstName = await SecureStorage.Default.GetAsync("user_firstName") ?? string.Empty;
            FirstName = userFirstName;
            // Set IsAdmin based on user's role
            IsAdmin = User.Role.ToUpper() == "ADMIN";
            IsDev = User.Role.ToUpper() == "DEVELOPER";

            if (User.UserWantsToDisplayPetIcon) 
            {
                UserWantsToDisplayPetIcon = true;
            }
        }

        [RelayCommand]
        private void CloseFirstTimePopup()
        {
            IsFirstTimePopupVisible = false;
        }

        [RelayCommand]
        public void ToggleLevelUpPopup()
        {
            IsLevelUpPopupVisible = !IsLevelUpPopupVisible;
        }        
        
        [RelayCommand]
        public void CloseLevelUpPopUp()
        {
            IsLevelUpPopupVisible = !IsLevelUpPopupVisible;
        }

        [RelayCommand]
        public async Task NavigateToAboutUsPage()
        {
            await Shell.Current.GoToAsync("///AboutUsPage");
        }                  
        
        [RelayCommand]
        public async Task NavigateToDonationPage()
        {
            await Shell.Current.GoToAsync("///DonationsPage");
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
        public async Task NavigateToEventsPage()
        {
            await Shell.Current.GoToAsync("///EventsMainPage");
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
        public async Task NavigateToPetigotchiPage()
        {
            await Shell.Current.GoToAsync("///PetigotchiPage");
        }           
        
        [RelayCommand]
        public async Task NavigateToMediaMainPage()
        {
            await Shell.Current.GoToAsync("///MediaCampaignMainPage");
        }

        // Navigating to the admin page
        [RelayCommand]
        public async Task NavigateToAdminPage()
        {
            // Navigate to Admin Page if user is an admin
             await Shell.Current.GoToAsync("///AdminMainPage");
            
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
