using MyeaMobileApp.Model;
using MyeaMobileApp.Model.User;

namespace MyeaMobileApp
{
    public partial class App : Application
    {
        public UserModel User { get; set; }
        public ProfileModel UserProfile { get; set; }
        public App(UserModel user, ProfileModel userProfile)
        {

            // Check if the 'first_time' preference is set
            bool isFirstTime = Preferences.Get("first_time", true);
            User = user;

            if (isFirstTime)
            {
                // Set the preference to false for subsequent launches
                Preferences.Set("first_time", false);
                User.IsFirstTimeOpeningApp = true;
            }
 
            UserProfile = userProfile;
            CheckUserLogin();
            InitializeComponent();
            MainPage = new AppShell();
        }

        private async void CheckUserLogin()
        {
            var userToken = await SecureStorage.Default.GetAsync("user_token");
            string userFirstName = await SecureStorage.Default.GetAsync("user_firstName") ?? string.Empty;
            Console.WriteLine($"###### userToken {userToken}");

            if (!string.IsNullOrEmpty(userToken))
            {
                User.UserIsLoggedIn = true;
                UserProfile.FirstName = userFirstName;
            }
            else
            {
                // User is not logged in, show login page
                Console.WriteLine("NNNNNNNNN NOT LOGGED IN");
            }
        }
    }
}
