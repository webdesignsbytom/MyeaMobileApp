using MyeaMobileApp.Model;

namespace MyeaMobileApp
{
    public partial class App : Application
    {
        public UserModel User { get; set; }
        public ProfileModel UserProfile { get; set; }
        public App(UserModel user, ProfileModel userProfile)
        {
            InitializeComponent();
            User = user;
            UserProfile = userProfile;
            CheckUserLogin();
            MainPage = new AppShell();
        }

        private async void CheckUserLogin()
        {
            var userId = await SecureStorage.GetAsync("user_id") ?? string.Empty;
            string userFirstName = await SecureStorage.GetAsync("user_firstName") ?? string.Empty;

            if (!string.IsNullOrEmpty(userId))
            {
                User.UserIsLoggedIn = true;
                UserProfile.FirstName = userFirstName;
                // Get user by id from token
            }
/*            else
            {
                // User is not logged in, show login page
                Debug.WriteLine("NNNNNNNNNNNNNNNNNN");
                Console.WriteLine("NNNNNNNNNNNNNNNNNNNNNN");
            }*/
        }
    }
}
