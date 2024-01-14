using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace MyeaMobileApp.Services.User
{
        [XamlCompilation(XamlCompilationOptions.Compile)]
    public class ScoreAndLevelApiService
    {
        public async Task AddPointsToUserScore(string UserId, string ProfileId, int AmountToAddToScore)
        {
            string userId = UserId;
            string profileId = ProfileId;
            int amountToAddToScore = AmountToAddToScore;

            string ApiUrlPost = $"https://myea-server.vercel.app/profile/update-user-score";
            using var httpClient = new HttpClient();

            var requestBody = new
            {
                userId,
                profileId,
                amountToAddToScore,
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
