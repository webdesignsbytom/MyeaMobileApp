namespace MyeaMobileApp.Model
{
    public class ProfileModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; } = "Dennis";
        public string FirstName { get; set; } = "Dennis";
        public string LastName { get; set; } = "Dennis";
        public string Bio { get; set; } = "BIOBIOBIOBIOI";
        public string ProfileImageUrl { get; set; } = "Dennis";
        public string City { get; set; } = "Paris";
        public string Country { get; set; } = "United Kingdom";
        public string Gender { get; set; } = "Male";
        public int Score { get; set; } = 10;
        public int BadgesOwned { get; set; } = 2;
        public bool IsPrivateProfile { get; set; } = false;

    }
}
