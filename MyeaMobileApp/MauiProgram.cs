using Microsoft.Extensions.Logging;
using MyeaMobileApp.Model;
using MyeaMobileApp.Services.User;
using MyeaMobileApp.View.About;
using MyeaMobileApp.View.Account.Badges;
using MyeaMobileApp.View.Account.Profile;
using MyeaMobileApp.View.Funding;
using MyeaMobileApp.View.Games.Petigotchi;
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
using MyeaMobileApp.View.Timeline;
using MyeaMobileApp.View.Users.Login;
using MyeaMobileApp.View.Users.Register;
using MyeaMobileApp.ViewModel.About;
using MyeaMobileApp.ViewModel.Account.Badges;
using MyeaMobileApp.ViewModel.Account.Profile;
using MyeaMobileApp.ViewModel.Funding;
using MyeaMobileApp.ViewModel.Games.Petigotchi;
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
using MyeaMobileApp.ViewModel.Timeline;
using MyeaMobileApp.ViewModel.Users.Login;
using MyeaMobileApp.ViewModel.Users.Register;

namespace MyeaMobileApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddSingleton<LoginPage>();
            builder.Services.AddSingleton<LoginPageViewModel>();
            builder.Services.AddSingleton<RegisterPage>();
            builder.Services.AddSingleton<RegisterPageViewModel>();
            builder.Services.AddSingleton<NewsReelPage>();
            builder.Services.AddSingleton<NewsReelPageViewModel>();
            builder.Services.AddSingleton<ProfilePage>();
            builder.Services.AddSingleton<ProfilePageViewModel>();
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
            builder.Services.AddSingleton<FundingPage>();
            builder.Services.AddSingleton<FundingPageViewModel>();
            builder.Services.AddSingleton<GoalsPage>();
            builder.Services.AddSingleton<GoalsPageViewModel>();
            builder.Services.AddSingleton<BadgesPage>();
            builder.Services.AddSingleton<BadgesPageViewModel>();
            builder.Services.AddSingleton<TimelinePage>();
            builder.Services.AddSingleton<TimelinePageViewModel>();
            builder.Services.AddSingleton<PetigotchiPage>();
            builder.Services.AddSingleton<PetigotchiPageViewModel>();
            builder.Services.AddSingleton<NewsletterSignUpPage>();
            builder.Services.AddSingleton<NewsletterSignUpPageViewModel>();
            builder.Services.AddSingleton<MediaCampaignMainPage>();
            builder.Services.AddSingleton<MediaCampaignMainPageViewModel>();
            builder.Services.AddSingleton<UserModel>();
            builder.Services.AddSingleton<NewsStoryModel>();
            builder.Services.AddSingleton<BadgeModel>();
            builder.Services.AddSingleton<UserApiService>();


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
