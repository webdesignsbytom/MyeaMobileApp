using MyeaMobileApp.Model;
using Newtonsoft.Json;
using System.Diagnostics;

namespace MyeaMobileApp.Services.Achievements
{
    public class AchievementsAndBadgesApiService
    {
        public async Task<BadgeModel> GetFullListOfAchievementsAndBadges()
        {
            string apiUrl = "https://myea-server.vercel.app/achievements/get-all-achievements";
            using var httpClient = new HttpClient();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                Debug.WriteLine($"AAAAAAAAAAAAAAAAAAAAAAAA {response.EnsureSuccessStatusCode()}");

                string responseBody = await response.Content.ReadAsStringAsync();

                Debug.WriteLine($"BBB responseBody {responseBody}");
                var apiResponse = JsonConvert.DeserializeObject<BadgeModel>(responseBody);

                Debug.WriteLine($"CCCCCCCCCCCCCCCCCCCCCCCC apiResponse {apiResponse}");

                return apiResponse;

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }
    }
}
