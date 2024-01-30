using MyeaMobileApp.Model;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace MyeaMobileApp.Services.Achievements
{
    public class AchievementsAndBadgesApiService
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private const string ApiUrl = "https://myea-server.vercel.app";

        public async Task<BadgeModel> GetFullListOfAchievementsAndBadges()
        {
            string ApiUrlEndPoint = "/achievements/get-all-achievements";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{ApiUrl}{ApiUrlEndPoint}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Debug.WriteLine($"BBBBBB responseBody {responseBody}");
                var apiResponse = JsonConvert.DeserializeObject<BadgeModel>(responseBody);

                Debug.WriteLine($"CCCCCCCCCCCCCCCCCCCCCCCC apiResponse {apiResponse}");

                if (apiResponse != null)
                {

                    return apiResponse;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error: {ex.Message}");
                return null;
            }
        }

        public async Task<object> GetStarterDataAchievementsAndBadges()
        {
            string ApiUrlEndPoint = "/users/user/set-up/get-achievements-levels-badges";

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync($"{ApiUrl}{ApiUrlEndPoint}");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();

                Debug.WriteLine($"BBBBBB responseBody {responseBody}");
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse>(responseBody);

                // Set models

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
            public Data Data { get; set; }
        }

        public class Data
        {
            public SetupData SetupData { get; set; }
        }

        public class SetupData
        {
            public List<Achievement> Achievements { get; set; }
            public List<Level> Levels { get; set; }
            public List<Badge> Badges { get; set; }
        }

        public class Achievement
        {
            public string Id { get; set; }
            public string AchievementType { get; set; }
            public string Name { get; set; }
            public int AchievementLevel { get; set; }
            public string BadgeUrl { get; set; }
            public bool SelfAwardable { get; set; }
            public List<Requirement> Requirements { get; set; }
        }

        public class Requirement
        {
            public int Id { get; set; }
            public RequirementDetail RequirementDetail { get; set; }
        }

        public class RequirementDetail
        {
            public string Model { get; set; }
            public string Record { get; set; }
            public int Score { get; set; }
        }

        public class Level
        {
            public int LevelNumber { get; set; }
            public int ScoreRequired { get; set; }
        }

        public class Badge
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }


        /*{
            "status": "success",
            "data": {
                "setupData": {
                    "achievements": [
                        {
                            "id": "ach-1",
                            "achievementType": "",
                            "name": "",
                            "achievementLevel": 0,
                            "badgeUrl": "",
                            "selfAwardable": false,
                            "requirements": [
                                {
                                    "id": 1,
                                    "requirement": {}
                                }
                            ]
                        },
                        {
                            "id": "ach-2",
                            "achievementType": "login",
                            "name": "Login 3 days in a row",
                            "achievementLevel": 1,
                            "badgeUrl": "",
                            "selfAwardable": false,
                            "requirements": [
                                {
                                    "id": 1,
                                    "requirement": {
                                        "model": "loginRecord",
                                        "record": "daysInARow",
                                        "score": 3
                                    }
                                }
                            ]
                        },
                        {
                            "id": "ach-3",
                            "achievementType": "login",
                            "name": "Login 3 days in a row",
                            "achievementLevel": 1,
                            "badgeUrl": "",
                            "selfAwardable": false,
                            "requirements": [
                                {
                                    "id": 1,
                                    "requirement": {
                                        "model": "loginRecord",
                                        "record": "daysInARow",
                                        "score": 3
                                    }
                                }
                            ]
                        },
                        {
                            "id": "ach-4",
                            "achievementType": "login",
                            "name": "Login 1 week in a row",
                            "achievementLevel": 2,
                            "badgeUrl": "",
                            "selfAwardable": false,
                            "requirements": [
                                {
                                    "id": 1,
                                    "requirement": {
                                        "model": "loginRecord",
                                        "record": "daysInARow",
                                        "score": 7
                                    }
                                }
                            ]
                        },
                        {
                            "id": "ach-5",
                            "achievementType": "login",
                            "name": "Login 2 week in a row",
                            "achievementLevel": 3,
                            "badgeUrl": "",
                            "selfAwardable": false,
                            "requirements": [
                                {
                                    "id": 1,
                                    "requirement": {
                                        "model": "loginRecord",
                                        "record": "daysInARow",
                                        "score": 14
                                    }
                                }
                            ]
                        },
                        {
                            "id": "ach-6",
                            "achievementType": "login",
                            "name": "Login 1 month in a row",
                            "achievementLevel": 4,
                            "badgeUrl": "",
                            "selfAwardable": false,
                            "requirements": [
                                {
                                    "id": 1,
                                    "requirement": {
                                        "model": "loginRecord",
                                        "record": "daysInARow",
                                        "score": 30
                                    }
                                }
                            ]
                        }
                    ],
                    "levels": [
                        {
                            "level": 1,
                            "scoreRequired": 0
                        },
                        {
                            "level": 2,
                            "scoreRequired": 10
                        },
                        {
                            "level": 3,
                            "scoreRequired": 50
                        },
                        {
                            "level": 4,
                            "scoreRequired": 100
                        },
                        {
                            "level": 5,
                            "scoreRequired": 200
                        },
                        {
                            "level": 6,
                            "scoreRequired": 500
                        },
                        {
                            "level": 7,
                            "scoreRequired": 1000
                        },
                        {
                            "level": 8,
                            "scoreRequired": 2000
                        },
                        {
                            "level": 9,
                            "scoreRequired": 3500
                        },
                        {
                            "level": 10,
                            "scoreRequired": 5000
                        }
                    ],
                    "badges": [
                        {
                            "id": 1,
                            "name": "Wildlife Sausage"
                        }
                    ]
                }
            }
        }*/
    }
}
