using Microsoft.Maui.ApplicationModel.Communication;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace MyeaMobileApp.Services.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class NewsletterApiService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string ApiUrl = "https://localhost:4000";
        public async Task SignUpUserToNewsletterApi(string UserId, string Email)
        {
            var requestBody = new { email = Email, userId = UserId };

            string ApiUrlEndPoint = "/newsletter/newsletter-signup";

            var json = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await httpClient.PostAsync(ApiUrl, content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Console.WriteLine($"Response: {responseBody}");

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error in SignUpUserToNewsletterApi: {ex.Message}");
                throw;
            }
        }
    }

}
