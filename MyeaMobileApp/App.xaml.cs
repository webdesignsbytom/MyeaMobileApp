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
            Console.WriteLine($"111111111111111111111111111111111111111111111111111111111111111 {userToken}");
            Console.WriteLine($"X111111111111111111111111111111111111111111111111111111111111111 {userFirstName}");

            if (!string.IsNullOrEmpty(userToken))
            {
                Console.WriteLine("111111111111111111111111111111111111111111111111111111111111111");
                User.UserIsLoggedIn = true;
                UserProfile.FirstName = userFirstName;
            }
            else
            {
                Console.WriteLine($"22222222222222222222222222222222222222222222 {userToken}");
                Console.WriteLine($"X22222222222222222222222222222222222222222222 {userFirstName}");

                // User is not logged in, show login page
                Console.WriteLine("NNNNNNNNNNNNNNNNNNNNNN");
            }
        }
    }
}
