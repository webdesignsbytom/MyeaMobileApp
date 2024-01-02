using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model;
using MyeaMobileApp.Services.Achievements;
using System.Collections.ObjectModel;

namespace MyeaMobileApp.ViewModel.Account.Badges
{
    public partial class BadgesPageViewModel : ObservableObject
    {
        public ProfileModel UserProfile { get; set; }

        public AchievementsAndBadgesApiService BadgesApiService { get; set; }

        [ObservableProperty]
        private ObservableCollection<string> badgeImages;

        [ObservableProperty]
        private int badgesOwned;

        [ObservableProperty]
        private int totalBadges;
        public BadgesPageViewModel(ProfileModel userProfile, AchievementsAndBadgesApiService badgesApiService)
        {
            BadgesApiService = badgesApiService;

            BadgesOwned = userProfile.BadgesOwned; // Assume this property exists in UserModel
            TotalBadges = 10;

            LoadBadgesDataFromApi();

            BadgeImages = new ObservableCollection<string>
            {
                "badge1.png", "badge2.png", "badge3.png", "badge4.png", "badge5.png", "badge6.png","badge7.png", "badge8.png", "badge9.png","badge10.png", "badge11.png"
            };
        }

        private async void LoadBadgesDataFromApi()
        {
            var achievementsAndBadgesFound = await BadgesApiService.GetFullListOfAchievementsAndBadges();


            if (achievementsAndBadgesFound != null)
            {
                Console.WriteLine("YYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYYY");
            }
        }

        // Open list of badges and achievements
        [RelayCommand]
        public async Task OpenBadgeListContainer()
        {
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
