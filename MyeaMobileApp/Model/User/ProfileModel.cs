using MyeaMobileApp.Services.User;

namespace MyeaMobileApp.Model
{
    public class ProfileModel
    {
        public string Id { get; set; } = "devprofile";
        public string UserId { get; set; } = "dev";
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public string ProfileImageUrl { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; }
        public int Score { get; set; } = 0;
        public int Level { get; set; } = 1;
        public int BadgesOwned { get; set; } = 0;
        public bool IsPrivateProfile { get; set; } = false;

        public ProfileApiService ProfileApi { get; set; }
        public ProfileModel(ProfileApiService profileApi) 
        {
            ProfileApi = profileApi;
        }
        public async Task<bool> UpdateScoreByAmount(int scoreToAdd)
        {
            var result = await ProfileApi.UpdatePlayerScoreApi(this.UserId, scoreToAdd, this.Id);

            if (result.updatedScore != -1 && result.newLevel != -1)
            {
                this.Score = result.updatedScore;
                this.Level = result.newLevel;
                return true;
            }
            else
            {
                return false; 
            }
        }
    }
}
