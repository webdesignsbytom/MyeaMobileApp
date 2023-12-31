using MyeaMobileApp.Model;

namespace MyeaMobileApp
{
    public partial class App : Application
    {
        public UserModel User { get; set; }
        public ProfileModel UserProfile { get; set; }
        public App(UserModel user, ProfileModel userProfile)
        {
            User = user;
            UserProfile = userProfile;
            CheckUserLogin();
            InitializeComponent();
            MainPage = new AppShell();
        }

        private async void CheckUserLogin()
        {
            var userToken = await SecureStorage.Default.GetAsync("user_token");
            string userFirstName = await SecureStorage.Default.GetAsync("user_firstName") ?? string.Empty;

            if (!string.IsNullOrEmpty(userToken))
            {
                User.UserIsLoggedIn = true;
                UserProfile.FirstName = userFirstName;
            }
            else
            {
               // User is not logged in, show login page
                Console.WriteLine("NNNNNNNNNNNNNNNNNNNNNN");
            }
        }
    }
}
