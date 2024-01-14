using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Services.User;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MyeaMobileApp.View.Users.ForgotLogin
{
    public partial class ForgotLoginPageViewModel : ObservableObject
    {
        // API service
        public UserApiService UserApiService { get; set; }

        // Reset properties
        [ObservableProperty]
        public string? email;

        public ForgotLoginPageViewModel(UserApiService userApiService)
        {
            UserApiService = userApiService;
        }

        // Send Reset Email
        [RelayCommand]
        public async Task ResetEmail()
        {
            if (IsValidEmail(Email))
            {
                await UserApiService.ResetAndEmailNewUserPasswordApi(Email);
            }
            else
            {
                // Email is not valid
            }
        }

        public bool IsValidEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                // Normalize the domain
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                // Examines the domain part of the email and normalizes it.
                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();
                    var domainName = idn.GetAscii(match.Groups[2].Value);
                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }


        // Navigate to login
        [RelayCommand]
        public async Task NavigateToLoginPage()
        {
            await Shell.Current.GoToAsync("///LoginPage");
        }


    }
}
