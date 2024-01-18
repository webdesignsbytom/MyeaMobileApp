using Newtonsoft.Json;
using System.Text;

namespace MyeaMobileApp.Services.User
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class ProfileApiService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string ApiUrl = "https://myea-server.vercel.app";

        public async Task<(int updatedScore, int newLevel)> UpdatePlayerScoreApi(string UserId, int AmountToAddToScore, string ProfileId)
        {
            var requestBody = new { userId = UserId, amountToAddToScore = AmountToAddToScore, profileId = ProfileId };

            string ApiUrlEndPoint = "/profile/update-user-score";

            var json = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await httpClient.PutAsync($"{ApiUrl}{ApiUrlEndPoint}", content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                // Parse the response
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseBody);

                if (apiResponse != null && apiResponse.Status == "success" && apiResponse.Data != null)
                {
                    Console.WriteLine("SUCCESSSSS");
                    Console.WriteLine($"SUCCESSSSS {apiResponse.Data.UpdatedScore}");
                    Console.WriteLine($"SUCCESSSSS {apiResponse.Data.NewLevel}");

                    return (apiResponse.Data.UpdatedScore, apiResponse.Data.NewLevel);
                }
                else
                {
                    Console.WriteLine("failed: Invalid response.");
                    return (-1, -1); // Indicates failure
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return (-1, -1); // Indicates failure
            }
        }


        public class ApiResponseData
        {
            [JsonProperty("updatedScore")]
            public int UpdatedScore { get; set; }

            [JsonProperty("newLvl")]
            public int NewLevel { get; set; }
        }

        public class ApiResponse
        {
            public string Status { get; set; }
            public ApiResponseData Data { get; set; }
        }

    }
}
