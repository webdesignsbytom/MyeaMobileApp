﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model.User;
using MyeaMobileApp.Services.Auth;

namespace MyeaMobileApp.ViewModel.Users.Login
{
    public partial class LoginPageViewModel : ObservableObject
    {
        // API service
        public LoginApi LoginApiService { get; set; }
        // User model
        public UserModel User { get; set; }

        // Login properties
        [ObservableProperty]
        public string? email;

        [ObservableProperty]
        public string? password;        
        
        [ObservableProperty]
        public bool? isLoading = false;        
        
        [ObservableProperty]
        public bool? isVisible = true;

        [ObservableProperty]
        public string submitBtn = "Login";

        public LoginPageViewModel() { }

        // Create instance of api services
        public LoginPageViewModel(LoginApi loginApiService, UserModel userModel)
        {
            LoginApiService = loginApiService;
            User = userModel;
        }

        // Login API
        [RelayCommand]
        async Task LoginToAccount()
        {
            IsVisible = false;
            IsLoading = true;

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                return;
            }

            await LoginApiService.LogUserInApi(Email, Password);

            SubmitBtn = "Success!";
            Email = "";
            Password = "";
            User.UserIsLoggedIn = true;

            IsVisible = true;
            IsLoading = false;
            await Shell.Current.GoToAsync("///ProfilePage");
        }


        // Register if not a member
        [RelayCommand]
        public async Task NavigateToRegisterPage()
        {
            await Shell.Current.GoToAsync("///RegisterPage");
        }
        
        // Forgot Login
        [RelayCommand]
        public async Task NavigateToForgotLogin()
        {
            await Shell.Current.GoToAsync("///ForgotLoginPage");
        }

        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }

}
