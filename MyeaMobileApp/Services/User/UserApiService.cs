using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace MyeaMobileApp.Services.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class UserApiService
    {
        public async Task LogUserInApi(string Email, string Password)
        {
            Debug.WriteLine($"AASSSSSSSSSA");
            Console.WriteLine($"AADDDDDDDDDDDDDA");

            var email = Email;
            var password = Password;

            Console.WriteLine($"2222 EMAIL AND PASS {email} {password}");
            Debug.WriteLine($"2222 EMAIL AND PASS {email} {password}");

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

                Debug.WriteLine($"AAA content {content}");
                Console.WriteLine($"AAA content {content}");

                HttpResponseMessage response = await httpClient.PostAsync(ApiUrlPost, content);

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                Debug.WriteLine($"BBB responseBody {responseBody}");
                Console.WriteLine($"BBB responseBody {responseBody}");
                Console.WriteLine($"XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
