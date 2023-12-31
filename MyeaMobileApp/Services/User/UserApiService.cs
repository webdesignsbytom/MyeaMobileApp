using MyeaMobileApp.Model;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace MyeaMobileApp.Services.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class UserApiService
    {
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
