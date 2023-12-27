﻿using Microsoft.Extensions.Logging;
using MyeaMobileApp.View.Account.Profile;
using MyeaMobileApp.View.Lottery.LotteryMain;
using MyeaMobileApp.View.Main;
using MyeaMobileApp.View.News;
using MyeaMobileApp.View.Users.Login;
using MyeaMobileApp.View.Users.Register;
using MyeaMobileApp.ViewModel.Account.Profile;
using MyeaMobileApp.ViewModel.Lottery.LotteryMain;
using MyeaMobileApp.ViewModel.Main;
using MyeaMobileApp.ViewModel.News;
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


#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
