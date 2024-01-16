namespace MyeaMobileApp.Model
{
    public class ProfileModel
    {
        public string Id { get; set; } = "devprofile";
        public string UserId { get; set; }
        public string Username { get; set; } = "Devina";
        public string FirstName { get; set; } = "Devel";
        public string LastName { get; set; } = "Oppy";
        public string Bio { get; set; } = "My biography of water";
        public string ProfileImageUrl { get; set; } = "";
        public string City { get; set; } = "Paris";
        public string Country { get; set; } = "United Kingdom";
        public string Gender { get; set; } = "Male";
        public int Score { get; set; } = 0;
        public int BadgesOwned { get; set; } = 0;
        public bool IsPrivateProfile { get; set; } = false;

        public int UpdateScoreByAmount(int scoreToAdd)
        {
            Score += scoreToAdd;
            return Score;
        }
    }
}
