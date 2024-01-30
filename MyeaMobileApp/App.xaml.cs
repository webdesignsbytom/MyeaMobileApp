using Aptabase.Maui;
using MyeaMobileApp.Model;
using MyeaMobileApp.Model.User;
using MyeaMobileApp.Services.Achievements;

namespace MyeaMobileApp
{
    public partial class App : Application
    {
        // Analytics
        IAptabaseClient _aptabase;

        // Models
        public UserModel User { get; set; }
        public ProfileModel UserProfile { get; set; }

        // Api
        public AchievementsAndBadgesApiService AchievementsApi { get; set; }

        public App(IAptabaseClient aptabase, UserModel user, ProfileModel userProfile, AchievementsAndBadgesApiService achievementsApi)
        {
            // Check if the 'first_time' preference is set
            bool isFirstTime = Preferences.Get("first_time", true);

            User = user;
            AchievementsApi = achievementsApi;
            UserProfile = userProfile;

            if (isFirstTime)
            {
                // Set the preference to false for subsequent launches
                GetSetStartingData();
            }

            // Analytics
            _aptabase = aptabase;

            TrackAppOpen();

            CheckUserLogin();
            InitializeComponent();

            MainPage = new AppShell();
        }

        private void TrackAppOpen()
        {
            _aptabase.TrackEvent("app_started");
        }


        private async Task GetSetStartingData()
        {
            Preferences.Set("first_time", false);
            User.IsFirstTimeOpeningApp = true;

            var result = await AchievementsApi.GetFullListOfAchievementsAndBadges();
            Console.WriteLine($"???????????????????????? result {result}");
        }

        private async void CheckUserLogin()
        {
            var userToken = await SecureStorage.Default.GetAsync("user_token");
            string userFirstName = await SecureStorage.Default.GetAsync("user_firstName") ?? string.Empty;
            Console.WriteLine($"###### userToken {userToken}");

            // TODO missing token

            if (!string.IsNullOrEmpty(userToken))
            {
                User.UserIsLoggedIn = true;
                UserProfile.FirstName = userFirstName;
            }
            else
            {
                // User is not logged in, show login page
                Console.WriteLine("NNNNNNNNN NOT LOGGED IN");
                // Temp - remove when done - user token broken
                User.UserIsLoggedIn = true;
                UserProfile.FirstName = userFirstName;
            }
        }
    }
}
