using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace MyeaMobileApp.Services.Games
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class PetigotchiApiService
    {
        public async Task<ApiResponse> UpdatePetigotchiName(string NewPetName, string UserId, string PetId)
        {
            string petName = NewPetName;
            string userId = UserId;
            string petId = PetId;

            string ApiUrl = "https://myea-server.vercel.app/petigotchi/name-petigotchi"; // Corrected variable name
            using var httpClient = new HttpClient();


            var requestBody = new
            {
                petName,
                userId,
                petId,
            };

            try
            {
                var json = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await httpClient.PutAsync(ApiUrl, content);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"1111111111111111111111111111111 {responseBody}");

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseBody);
                Console.WriteLine($"AAAAAAAAAAAAAAAAAAAAAA {apiResponse.Data}");

                if (apiResponse.Data != null)
                {
                    Console.WriteLine($"22222222222222222222222222");

/*                    foreach (var ecoEvent in apiResponse)
                    {
                        Console.WriteLine(ecoEvent.ToString());
                    }*/
                }

                return apiResponse;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return null;
            }

        }

        public class ApiResponse
        {
            public string Status { get; set; }
            public Petigotchi Data { get; set; }
        }

        public class Petigotchi
        {
            public string PetName { get; set; }
            public Object namedPetigotchi { get; set; }
        }

    }
}
