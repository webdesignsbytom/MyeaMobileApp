namespace MyeaMobileApp.Model
{
    public class UserModel
    {
        public string UserId { get; set; } = "tempId";
        public string Role { get; set; } = "USER";
        public string Email { get; set; } = "user@mail.com";
        public DateTime DateOfBirth { get; set; }
        public bool UserRegisteredForNewsletter { get; set; } = false;
        public bool UserAgreedToTermsAndConditions { get; set; } = true;
        public bool HasLivePetigotchi { get; set; }
        public DateTime LastLoggedIn { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool UserIsLoggedIn { get; set; } = false;

        // Logout 
        public void LogoutUserFromApp()
        {
            // Set the login status to false
            UserIsLoggedIn = false;

            // Clear user data from secure storage
            SecureStorage.Default.Remove("user_token");
            SecureStorage.Default.Remove("user_email");
            SecureStorage.Default.Remove("user_firstName");
        }
    }
}
