using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace MyeaMobileApp.Services.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class NewsletterApiService
    {
        public async Task SignUpUserToNewsletterApi(string Email)
        {
            string email = Email;

            string ApiUrlPost = "https://myea-server.vercel.app/newsletter/newsletter-signup";
            using var httpClient = new HttpClient();

            var requestBody = new
            {
                email,
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
