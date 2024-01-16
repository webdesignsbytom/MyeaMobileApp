using MyeaMobileApp.Model.Events;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace MyeaMobileApp.Services.Events
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class EcoEventsApiService
    {
        public async Task<List<PlannedEventModel>> GetAllEcoEvents()
        {
            string apiUrl = "https://myea-server.vercel.app/eco-events/get-all-eco-events"; // Corrected variable name
            using var httpClient = new HttpClient();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(apiUrl); // Corrected variable name
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"1111111111111111111111111111111 {responseBody}");

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseBody);
                Console.WriteLine($"AAAAAAAAAAAAAAAAAAAAAA {apiResponse.Data.EcoEvents[0].EventTitle}");

                if (apiResponse.Data.EcoEvents != null)
                {
                    Console.WriteLine($"22222222222222222222222222");

                    foreach (var ecoEvent in apiResponse.Data.EcoEvents)
                    {
                        Console.WriteLine(ecoEvent.ToString());
                    }
                }

                return apiResponse.Data.EcoEvents;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return new List<PlannedEventModel>();
            }
        }

        public class ApiResponse
        {
            public string Status { get; set; }
            public EcoEventData Data { get; set; }
        }

        public class EcoEventData
        {
            public List<PlannedEventModel> EcoEvents { get; set; }
        }


        public async Task CreateNewEcoEvent(string UserId, DateTime? EventDate, string EventLocation, string EventTitle, string EventInfo, ImageSource SelectedImage)
        {
            
            string userId = UserId;
            string eventLocation = EventLocation;
            string eventTitle = EventTitle;
            string eventInfo = EventInfo;
            ImageSource imageUrl = SelectedImage;
            DateTime? eventDate = EventDate;

            string ApiUrlPost = "https://myea-server.vercel.app/eco-events/create-new-eco-event";
            using var httpClient = new HttpClient();

            var requestBody = new
            {
                userId,
                eventLocation,
                eventTitle,
                eventInfo,
                imageUrl,
                eventDate,
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
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseBody);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
