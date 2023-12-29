using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Services.User;

namespace MyeaMobileApp.ViewModel.Users.Login
{
    public partial class LoginPageViewModel : ObservableObject
    {
        // API service
        public UserApiService UserApiService { get; set; }

        // Login properties
        [ObservableProperty]
        public string? email;

        [ObservableProperty]
        public string? password;

        [ObservableProperty]
        public string submitBtn = "Login";

        public LoginPageViewModel() { }

        // Create instance of api services
        public LoginPageViewModel(UserApiService userApiService)
        {
            UserApiService = userApiService;
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
            await Shell.Current.GoToAsync("///ProfilePage");
        }


        // Register if not a member
        [RelayCommand]
        public async Task NavigateToRegisterPage()
        {
            await Shell.Current.GoToAsync("///RegisterPage");
        }
    }

}
