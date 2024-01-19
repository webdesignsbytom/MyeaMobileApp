namespace MyeaMobileApp.Model.User
{
    public class UserModel
    {
        public string UserId { get; set; } = "dev";
        public string Role { get; set; } = "ADMIN";
        public string Email { get; set; } = "dev@dev.com";
        public DateTime DateOfBirth { get; set; }
        public bool UserRegisteredForNewsletter { get; set; } = false;
        public bool UserAgreedToTermsAndConditions { get; set; } = true;
        public bool HasLivePetigotchi { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastLoggedIn { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool UserIsLoggedIn { get; set; } = false;
        public bool IsFirstTimeNaming { get; set; } = true;

        // Saved to local machine not database
        // First page visit reward bools
        public bool IsDarkModeEnabled { get; set; } = false;
        public bool UserWantsToDisplayPetIcon { get; set; } = true;
        public bool IsFirstTimeOpeningApp { get; set; } = false;
        public bool FirstTimeOnAboutUsPage { get; set; } = false;
        public bool FirstTimeOnGamesMainPage { get; set; } = false;
        public bool FirstTimeOnGoalsPage { get; set; } = false;
        public bool FirstTimeOnFundingPage { get; set; } = false;
        public bool FirstTimeOnServicesPage { get; set; } = false;
        public bool FirstTimeOnAppsPage { get; set; } = false;
        public bool FirstTimeOnNewsPage { get; set; } = false;
        public bool FirstTimeOnMediaMainPage { get; set; } = false;
        public bool FirstTimeOnLotteryMainPage { get; set; } = false;
        public bool FirstTimeOnTimelinePage { get; set; } = false;
        public bool FirstTimeOnEventsPage { get; set; } = false;
        public bool FirstTimeOnDonationsPage { get; set; } = false;
        public bool FirstTimeOnProfileMainPage { get; set; } = false;
        public bool FirstTimeOnBadgesPage { get; set; } = false;
        public bool FirstTimeOnAchievementsPage { get; set; } = false;

        public UserToken UserToken { get; set; }

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

    public class UserToken
    { 
        public string UserId { get; set; }
        public string Token { get; set; }
    }

}
