using MyeaMobileApp.Model;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyeaMobileApp.Services.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class UserApiService
    {
        public UserModel User { get; set; }
        public ProfileModel UserProfile { get; set; }
        public UserApiService(UserModel userModel, ProfileModel profileModel) 
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
                        Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
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

            public Profile Profile { get; set; }

            // Add other fields as necessary
        }

        public class Profile
        {
            public string FirstName { get; set; }
            // Add other profile-specific fields
        }


        public async Task RegisterNewUserApi(string Email, string Password, string FirstName, string LastName, string Country, bool AgreeToTerms, bool AgreedNews)
        {
            string email = Email;
            string password = Password;
            string firstName = FirstName;
            string lastName = LastName;
            string country = Country;
            bool agreeToTerms = AgreeToTerms;
            bool agreedNews = AgreedNews;

            string ApiUrlPost = "https://myea-server.vercel.app/users/register";
            using var httpClient = new HttpClient();

            var requestBody = new
            {
                email,
                password,
                firstName,
                lastName,
                country,
                agreeToTerms,
                agreedNews
            };

            try
            {
                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PostAsync(ApiUrlPost, content);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                Debug.WriteLine($"BBB responseBody {responseBody}");
                Console.WriteLine($"BBB responseBody {responseBody}");

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
