using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model;
using MyeaMobileApp.Services.User;

namespace MyeaMobileApp.ViewModel.Users.Login
{
    public partial class LoginPageViewModel : ObservableObject
    {
        // API service
        public UserApiService UserApiService { get; set; }
        // User model
        public UserModel User { get; set; }


        // Login properties
        [ObservableProperty]
        public string? email;

        [ObservableProperty]
        public string? password;

        [ObservableProperty]
        public string submitBtn = "Login";

        public LoginPageViewModel() { }

        // Create instance of api services
        public LoginPageViewModel(UserApiService userApiService, UserModel userModel)
        {
            UserApiService = userApiService;
            User = userModel;
        }

        // Login API
        [RelayCommand]
        async Task LoginToAccount()
        {
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                return;
            }

            await UserApiService.LogUserInApi(Email, Password);
            SubmitBtn = "Success!";
            Email = "";
            Password = "";
            User.UserIsLoggedIn = true;
            User.Score++;
            await Shell.Current.GoToAsync("///ProfilePage");
        }


        // Register if not a member
        [RelayCommand]
        public async Task NavigateToRegisterPage()
        {
            await Shell.Current.GoToAsync("///RegisterPage");
        }

        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }

}
