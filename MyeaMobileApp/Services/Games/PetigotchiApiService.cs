using MyeaMobileApp.Model.Games;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace MyeaMobileApp.Services.Games
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public class PetigotchiApiService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string ApiUrl = "https://myea-server.vercel.app";

        public PetigotchiModel PetigotchiModel { get; set; }

        public PetigotchiApiService(PetigotchiModel petigotchiModel)
        {
            PetigotchiModel = petigotchiModel;
        }
        public async Task<string> UpdatePetigotchiName(string NewPetName, string UserId, string PetId)
        {
            Console.WriteLine($"ZZZZZZZZZZZZZZZZZZZZZZZZ");
            Console.WriteLine($"XXX {NewPetName} YYY {UserId}  MMM {PetId}");

            var requestBody = new { petName = NewPetName, userId = UserId, petId = PetId };
            Console.WriteLine($"ZZZZZZZZZZZZZZZZZZZZZZZZ");

            string ApiUrlEndPoint = "/petigotchi/name-petigotchi";
            Console.WriteLine($"ZZZZZZZZZZZZZZZZZZZZZZZZ");

            var json = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {

                HttpResponseMessage response = await httpClient.PutAsync($"{ApiUrl}{ApiUrlEndPoint}", content);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                // Parse the response
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseBody);
                Console.WriteLine($"1111111111111111111111 {apiResponse}");
                Console.WriteLine($"AAAAAAAAAAAAAAAAAAAAAA {apiResponse.Data}");

                if (apiResponse != null && apiResponse.Status == "success" && apiResponse.Data != null)
                {
                    Console.WriteLine($"22222222222222222222222222");
                    if (apiResponse != null && apiResponse.Status == "success" && apiResponse.Data != null)
                    {
                        // Update the PetigotchiModel's name with the name returned from the API
                        PetigotchiModel.PetName = apiResponse.Data.PetigotchiName;
                        Debug.WriteLine($"Petigotchi name updated to: {PetigotchiModel.PetName}");
                    }
                }

                return PetigotchiModel.PetName;
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"HTTP Request Error: {ex.Message} : {ex}");
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"General Error: {ex.Message}\n{ex.StackTrace}");
                return null;
            }

        }

        public class ApiResponse
        {
            public string Status { get; set; }
            public PetigotchiData Data { get; set; }
        }

        public class PetigotchiData
        {
            [JsonProperty("petigotchi")]
            public string PetigotchiName { get; set; }
        }
    }
}
