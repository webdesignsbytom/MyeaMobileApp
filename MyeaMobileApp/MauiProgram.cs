using Microsoft.Extensions.Logging;
using MyeaMobileApp.Model;
using MyeaMobileApp.Model.Advert;
using MyeaMobileApp.Model.Games;
using MyeaMobileApp.Model.Lottery;
using MyeaMobileApp.Model.Products;
using MyeaMobileApp.Model.User;
using MyeaMobileApp.Services;
using MyeaMobileApp.Services.Achievements;
using MyeaMobileApp.Services.Auth;
using MyeaMobileApp.Services.User;
using MyeaMobileApp.View.About;
using MyeaMobileApp.View.Account.Badges;
using MyeaMobileApp.View.Account.EditProfile;
using MyeaMobileApp.View.Account.InviteFriends;
using MyeaMobileApp.View.Account.Manage;
using MyeaMobileApp.View.Account.Profile;
using MyeaMobileApp.View.Admin;
using MyeaMobileApp.View.Apps;
using MyeaMobileApp.View.Donations;
using MyeaMobileApp.View.Funding;
using MyeaMobileApp.View.Games.Main;
using MyeaMobileApp.View.Games.O2tapper.MainGame;
using MyeaMobileApp.View.Games.Petigotchi.MainGame;
using MyeaMobileApp.View.Goals;
using MyeaMobileApp.View.Lottery.History;
using MyeaMobileApp.View.Lottery.LotteryMain;
using MyeaMobileApp.View.Lottery.OwnedTickets;
using MyeaMobileApp.View.Lottery.PuchaseTickets;
using MyeaMobileApp.View.Lottery.Rules;
using MyeaMobileApp.View.Main;
using MyeaMobileApp.View.Media;
using MyeaMobileApp.View.News;
using MyeaMobileApp.View.Newsletter;
using MyeaMobileApp.View.Services;
using MyeaMobileApp.View.Timeline;
using MyeaMobileApp.View.Users.ForgotLogin;
using MyeaMobileApp.View.Users.Login;
using MyeaMobileApp.View.Users.Register;
using MyeaMobileApp.ViewModel.About;
using MyeaMobileApp.ViewModel.Account.Badges;
using MyeaMobileApp.ViewModel.Account.EditProfile;
using MyeaMobileApp.ViewModel.Account.InviteFriends;
using MyeaMobileApp.ViewModel.Account.Manage;
using MyeaMobileApp.ViewModel.Account.Profile;
using MyeaMobileApp.ViewModel.Admin;
using MyeaMobileApp.ViewModel.Apps;
using MyeaMobileApp.ViewModel.Donations;
using MyeaMobileApp.ViewModel.Funding;
using MyeaMobileApp.ViewModel.Games.Main;
using MyeaMobileApp.ViewModel.Games.O2tapper.MainGame;
using MyeaMobileApp.ViewModel.Games.Petigotchi.MainGame;
using MyeaMobileApp.ViewModel.Goals;
using MyeaMobileApp.ViewModel.Lottery.History;
using MyeaMobileApp.ViewModel.Lottery.LotteryMain;
using MyeaMobileApp.ViewModel.Lottery.OwnedTickets;
using MyeaMobileApp.ViewModel.Lottery.PuchaseTickets;
using MyeaMobileApp.ViewModel.Lottery.Rules;
using MyeaMobileApp.ViewModel.Main;
using MyeaMobileApp.ViewModel.Media;
using MyeaMobileApp.ViewModel.News;
using MyeaMobileApp.ViewModel.Newsletter;
using MyeaMobileApp.ViewModel.Services;
using MyeaMobileApp.ViewModel.Timeline;
using MyeaMobileApp.ViewModel.Users.Login;
using MyeaMobileApp.ViewModel.Users.Register;
using SkiaSharp.Views.Maui.Controls.Hosting;
using MyeaMobileApp.View.Events.CreateEvent;
using MyeaMobileApp.ViewModel.Events.CreateEvent;
using MyeaMobileApp.View.Events.Main;
using MyeaMobileApp.ViewModel.Events.Main;
using MyeaMobileApp.Model.Events;
using MyeaMobileApp.Model.Achievements;
using MyeaMobileApp.View.Account.Achievements;
using MyeaMobileApp.ViewModel.Account.Achievements;

namespace MyeaMobileApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("SegoeIcons.ttf", "Segoe Fluent Icons");
                    fonts.AddFont("Seven-Segment.ttf", "Seven Segment");
                });
            /* Pages and ViewModels */
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();
            /* User */
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<RegisterPageViewModel>();
            builder.Services.AddSingleton<ProfilePage>();
            builder.Services.AddSingleton<ProfilePageViewModel>();
            builder.Services.AddSingleton<InviteFriendsPage>();
            builder.Services.AddSingleton<InviteFriendsPageViewModel>();
            builder.Services.AddSingleton<EditProfilePage>();
            builder.Services.AddSingleton<EditProfilePageViewModel>();
            builder.Services.AddSingleton<ManageAccountPage>();
            builder.Services.AddSingleton<ManageAccountPageViewModel>();
            builder.Services.AddSingleton<ForgotLoginPage>();
            builder.Services.AddSingleton<ForgotLoginPageViewModel>();
            builder.Services.AddSingleton<AchievementsPage>();
            builder.Services.AddSingleton<AchievementsPageViewModel>();
            /* Admin */
            builder.Services.AddSingleton<AdminMainPage>();
            builder.Services.AddSingleton<AdminMainPageViewModel>();
            /* General */
            builder.Services.AddSingleton<NewsReelPage>();
            builder.Services.AddSingleton<NewsReelPageViewModel>();
            /* Lottery */
            builder.Services.AddSingleton<LotteryMainPage>();
            builder.Services.AddSingleton<LotteryMainPageViewModel>();
            builder.Services.AddSingleton<PurchaseLotteryTicketsPage>();
            builder.Services.AddSingleton<PurchaseLotteryTicketsPageViewModel>();
            builder.Services.AddSingleton<OwnedLotteryTicketsPage>();
            builder.Services.AddSingleton<OwnedLotteryTicketsPageViewModel>();
            builder.Services.AddSingleton<LotteryRulesPage>();
            builder.Services.AddSingleton<LotteryRulesPageViewModel>();
            builder.Services.AddSingleton<WinningNumbersHistoryPage>();
            builder.Services.AddSingleton<WinningNumbersHistoryPageViewModel>();
            builder.Services.AddSingleton<AboutUsPage>();
            builder.Services.AddSingleton<AboutUsPageViewModel>();
            builder.Services.AddSingleton<ServicesPage>();
            builder.Services.AddSingleton<ServicesPageViewModel>();
            builder.Services.AddSingleton<AppsMainPage>();
            builder.Services.AddSingleton<AppsMainPageViewModel>();
            builder.Services.AddSingleton<FundingPage>();
            builder.Services.AddSingleton<FundingPageViewModel>();
            builder.Services.AddSingleton<DonationsPage>();
            builder.Services.AddSingleton<DonationsPageViewModel>();
            builder.Services.AddSingleton<GoalsPage>();
            builder.Services.AddSingleton<GoalsPageViewModel>();
            builder.Services.AddSingleton<BadgesPage>();
            builder.Services.AddSingleton<BadgesPageViewModel>();
            builder.Services.AddSingleton<TimelinePage>();
            builder.Services.AddSingleton<TimelinePageViewModel>();
            builder.Services.AddSingleton<NewsletterSignUpPage>();
            builder.Services.AddSingleton<NewsletterSignUpPageViewModel>();
            builder.Services.AddSingleton<MediaCampaignMainPage>();
            builder.Services.AddSingleton<MediaCampaignMainPageViewModel>();
            /* Events */
            builder.Services.AddSingleton<EventsMainPage>();
            builder.Services.AddSingleton<EventsMainPageViewModel>();
            builder.Services.AddSingleton<CreateEventPage>();
            builder.Services.AddSingleton<CreateEventPageViewModel>();
            /* Games */
            builder.Services.AddSingleton<GamesMainPage>();
            builder.Services.AddSingleton<GamesMainPageViewModel>();
            /* Petigotchi */
            builder.Services.AddSingleton<PetigotchiPage>();
            builder.Services.AddSingleton<PetigotchiPageViewModel>();
            /* O2 Tapper */
            builder.Services.AddSingleton<O2tapperMainPage>();
            builder.Services.AddSingleton<O2tapperMainPageViewModel>();
            /* Models */
            builder.Services.AddSingleton<UserModel>();
            builder.Services.AddSingleton<ProfileModel>();
            builder.Services.AddSingleton<NewsStoryModel>();
            builder.Services.AddSingleton<BadgeModel>();
            builder.Services.AddSingleton<LotteryTicketModel>();
            builder.Services.AddSingleton<LotteryDrawModel>();
            builder.Services.AddSingleton<LotteryTicketResultModel>();
            builder.Services.AddSingleton<PetigotchiModel>();
            builder.Services.AddSingleton<O2tapperModel>();
            builder.Services.AddSingleton<WebProductModel>();
            builder.Services.AddSingleton<AppProductModel>();
            builder.Services.AddSingleton<AchievementModel>();
            builder.Services.AddSingleton<PlannedEventModel>();
            builder.Services.AddSingleton<AdvertModel>();
            /* Api services */
            builder.Services.AddSingleton<UserApiService>();
            builder.Services.AddSingleton<LoginApi>();
            builder.Services.AddSingleton<NewsletterApiService>();
            builder.Services.AddSingleton<LotteryApiService>();
            builder.Services.AddSingleton<AchievementsAndBadgesApiService>();
            builder.Services.AddSingleton<ScoreAndLevelApiService>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
