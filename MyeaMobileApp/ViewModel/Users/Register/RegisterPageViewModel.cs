using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Services.User;

namespace MyeaMobileApp.ViewModel.Users.Register
{
    public partial class RegisterPageViewModel : ObservableObject
    {
        // API service
        public UserApiService UserApiService { get; set; }

        // Register properties
        [ObservableProperty]
        public string? email;

        [ObservableProperty]
        public string? password;        
        
        [ObservableProperty]
        public string? confirmPassword; 
        
        [ObservableProperty]
        public string? firstName;
        
        [ObservableProperty]
        public string? lastName;
        
        [ObservableProperty]
        public string? country; 
        
        [ObservableProperty]
        public bool? agreeToTerms;        
        
        [ObservableProperty]
        public bool? agreeToNewsletter;

        [ObservableProperty]
        public string submitBtn = "Register";

        public RegisterPageViewModel() { }

        // Create instance of api services
        public RegisterPageViewModel(UserApiService userApiService)
        {
            UserApiService = userApiService;
        }

        // Register API
        [RelayCommand]
        async Task RegisterNewUser()
        {
            // Check if passwords match
            if (Password != ConfirmPassword) return;

            // Check for missing fields
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(Country) || AgreeToTerms != true)
            {
                return;
            }

            // Safely handle the nullable boolean
            bool agreedTC = AgreeToTerms ?? false;            
            bool agreedNews = AgreeToNewsletter ?? false;

            // Register to server
            await UserApiService.RegisterNewUserApi(Email, Password, FirstName, LastName, Country, agreedTC, agreedNews);
            SubmitBtn = "Success!";
            Email = "";
            Password = "";
            await Shell.Current.GoToAsync("///ProfilePage");
        }

        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
