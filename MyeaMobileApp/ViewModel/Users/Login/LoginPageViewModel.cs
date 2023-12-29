using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Services.User;
using System.Diagnostics;

namespace MyeaMobileApp.ViewModel.Users.Login
{
    public partial class LoginPageViewModel : ObservableObject
    {
        // API service
        public UserApiService UserApiService { get; set; }

        // Login properties
        [ObservableProperty]
        public string email;        
        
        [ObservableProperty]
        public string password;

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
            Console.WriteLine($"EMAIL AND PASS {email} {password}");
            Debug.WriteLine($"EMAIL AND PASS {email} {password}");

            await UserApiService.LogUserInApi(email, password);
            SubmitBtn = "Success!";
            email = "";
            password = "";
        }

        // Register if not a member
        [RelayCommand]
        public async Task NavigateToRegisterPage()
        {
            await Shell.Current.GoToAsync("///RegisterPage");
        }
    }
}
