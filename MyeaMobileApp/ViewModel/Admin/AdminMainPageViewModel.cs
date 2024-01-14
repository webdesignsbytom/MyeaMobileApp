using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Services.User;

namespace MyeaMobileApp.ViewModel.Admin
{
    public partial class AdminMainPageViewModel : ObservableObject
    {
        public ScoreAndLevelApiService ScoreAndLevelApiService { get; set; }

        public string UserId { get; set; } = "dev";
        public string ProfileId { get; set; } = "devprofile";

        // Popups
        [ObservableProperty]
        private bool isLevelUpPopupVisible;

        [ObservableProperty]
        private bool isFirstTimePopupVisible;

        public AdminMainPageViewModel() { }

        public AdminMainPageViewModel(ScoreAndLevelApiService scoreAndLevelApiService)
        {
            ScoreAndLevelApiService = scoreAndLevelApiService;
        }

        // Add test points
        [RelayCommand]
        public async Task AddOnePoint()
        {
            await ScoreAndLevelApiService.AddPointsToUserScore(UserId, ProfileId, 1);
        }

        // Navigate home
        [RelayCommand]
        public async Task AddTenPoints()
        {
            await ScoreAndLevelApiService.AddPointsToUserScore(UserId, ProfileId, 10);
        }

        // Navigate home
        [RelayCommand]
        public async Task AddOneHundredPoints()
        {
            await ScoreAndLevelApiService.AddPointsToUserScore(UserId, ProfileId, 100);
        }

        // Navigate home
        [RelayCommand]
        public async Task AddOneThousandPoints()
        {
            await ScoreAndLevelApiService.AddPointsToUserScore(UserId, ProfileId, 1000);

        }

        // Open popups
        [RelayCommand]
        private void OpenFirstTimePopup()
        {
            IsFirstTimePopupVisible = true;
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

        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
