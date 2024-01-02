using Microsoft.Maui.ApplicationModel.Communication;
using MyeaMobileApp.Model;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Text;

namespace MyeaMobileApp.Services.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class UserApiService
    {
        public async Task RegisterNewUserApi(string Email, string Password, string FirstName, string LastName, string Country, DateTime DateOfBirth, bool AgreeToTerms, bool AgreedNews)
        {
            string email = Email;
            string password = Password;
            string firstName = FirstName;
            string lastName = LastName;
            string country = Country;
            string dateOfBirth = DateOfBirth.ToString("yyyy-MM-dd");
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
                dateOfBirth,
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

        public async Task UpdateUserProfileData(
            string id, string userId, string username, string firstName,
            string lastName, string bio, string profileImageUrl,
            string city, string country, string gender,
            int score, int badgesOwned, bool isPrivateProfile)
        {
            // Fetch address
            string ApiUrlPost = $"https://myea-server.vercel.app/users/account/update/{userId}";
            using var httpClient = new HttpClient();

            var requestBody = new
            {
                Id = id,
                UserId = userId,
                Username = username,
                FirstName = firstName,
                LastName = lastName,
                Bio = bio,
                ProfileImageUrl = profileImageUrl,
                City = city,
                Country = country,
                Gender = gender,
                Score = score,
                BadgesOwned = badgesOwned,
                IsPrivateProfile = isPrivateProfile
            };

            try
            {
                var json = JsonConvert.SerializeObject(requestBody);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync(ApiUrlPost, data);
                // Handle the response as needed

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }

        public async Task DeleteUserAccountApi(string Id)
        {
            string id = Id;

            string ApiUrlPost = $"https://myea-server.vercel.app/users/delete-user/{id}";
            using var httpClient = new HttpClient();

            var requestBody = new
            {
                id
            };

            try
            {
                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.DeleteAsync(ApiUrlPost);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                Debug.WriteLine($"BBB responseBody {responseBody}");
                Console.WriteLine($"BBB responseBody {responseBody}");

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error Deleting User: {ex.Message}");
            }
        }
    }
}
