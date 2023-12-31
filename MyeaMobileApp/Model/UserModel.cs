namespace MyeaMobileApp.Model
{
    public class UserModel
    {
        public string UserId { get; set; } = "1234";
        public string Role { get; set; }
        public string Email { get; set; } = "tom@x.com";
        public DateTime DateOfBirth { get; set; }
        public bool UserRegisteredForNewsletter { get; set; } = false;
        public bool UserAgreedToTermsAndConditions { get; set; } = true;
        public bool UserIsLoggedIn { get; set; } = false;
        public bool HasLivePetigotchi { get; set; }
        public DateTime LastLoggedIn { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Logout 
        public void LogoutUserFromApp()
        {
            // Set the login status to false
            UserIsLoggedIn = false;

            // Clear user data from secure storage
            SecureStorage.Remove("user_id");
        }
    }
}
