using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using MyeaMobileApp.Model.Lottery;

namespace MyeaMobileApp.Services
{
    public class LotteryApiService
    {
        public async Task<LotteryDrawModel> GetNextLotteryDraw()
        {
            string apiUrl = "https://myea-server.vercel.app/lottery/get-next-lottery-draw";
            using var httpClient = new HttpClient();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();
                Debug.WriteLine($"AAAAAAAAAAAAAAAAAAAAAAAA {response.EnsureSuccessStatusCode()}");

                string responseBody = await response.Content.ReadAsStringAsync();

                Debug.WriteLine($"BBB responseBody {responseBody}");
                var apiResponse = JsonConvert.DeserializeObject<ApiResponseModel>(responseBody);

                return apiResponse?.Data?.Draw;

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public class ApiResponseModel
        {
            public string Status { get; set; }
            public DataModel Data { get; set; }
        }

        public class DataModel
        {
            public LotteryDrawModel Draw { get; set; }
        }
    }
}
