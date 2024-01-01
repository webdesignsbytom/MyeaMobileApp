﻿using MyeaMobileApp.Model;
using Newtonsoft.Json;
using System.Text;

namespace MyeaMobileApp.Services.Auth
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class LoginApi
    {
        public UserModel User { get; set; }
        public ProfileModel UserProfile { get; set; }
        public LoginApi(UserModel userModel, ProfileModel profileModel)
        {
            User = userModel;
            UserProfile = profileModel;
        }

        public async Task<bool> LogUserInApi(string Email, string Password)
        {
            var email = Email;
            var password = Password;

            var ApiUrlPost = "https://myea-server.vercel.app/login";
            using var httpClient = new HttpClient();

            var requestBody = new
            {
                email,
                password
            };

            try
            {
                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(ApiUrlPost, content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                // Parse the response
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseBody);

                if (apiResponse != null && apiResponse.Status == "success" && apiResponse.Data != null)
                {

                    User.Email = apiResponse.Data.ExistingUser.Email;
                    // Store token and other data in SecureStorage
                    await SecureStorage.Default.SetAsync("user_token", apiResponse.Data.Token);
                    await SecureStorage.Default.SetAsync("user_email", apiResponse.Data.ExistingUser.Email);

                    if (apiResponse.Data.ExistingUser.Profile != null)
                    {
                        string firstName = apiResponse.Data.ExistingUser.Profile.FirstName;

                        UserProfile.FirstName = firstName;
                        await SecureStorage.Default.SetAsync("user_firstName", firstName);
                    }

                    Console.WriteLine("User logged in successfully.");
                    return true;
                }
                else
                {
                    Console.WriteLine("Login failed: Invalid response.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
        // Define classes to parse the API response
        public class ApiResponse
        {
            public string Status { get; set; }
            public LoginData Data { get; set; }
        }

        public class LoginData
        {
            public string Token { get; set; }
            public ExistingUser ExistingUser { get; set; }
        }

        public class ExistingUser
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public string Role { get; set; }
            public DateTime DOB { get; set; }
            public Boolean IsEmailVerified { get; set; }
            public Boolean UserAgreedToTermsAndConditions { get; set; }
            public Boolean UserRegisteredForNewsletter { get; set; }
            public Boolean IsActive { get; set; }
            public Profile Profile { get; set; }
        }

        public class Profile
        {
            public string Username { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string City { get; set; }
            public string Country { get; set; }
            public string Gender { get; set; }
            public int Score { get; set; }
            public string Bio { get; set; }
            public string ProfileImageUrl { get; set; }
            public Boolean IsPrivateProfile { get; set; }
        }
    }
}
