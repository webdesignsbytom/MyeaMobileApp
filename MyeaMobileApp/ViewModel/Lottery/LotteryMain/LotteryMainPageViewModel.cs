using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model.User;
using MyeaMobileApp.Services;
using System.Timers;

namespace MyeaMobileApp.ViewModel.Lottery.LotteryMain
{
    public partial class LotteryMainPageViewModel : ObservableObject
    {
        public UserModel User { get; set; }

        public LotteryApiService LotteryApi { get; set; }

        private System.Timers.Timer _timer;
        private string _countdownText;

        [ObservableProperty]
        private string countdownTimerText;        
        
        [ObservableProperty]
        private string lotteryPrize;

        [ObservableProperty]
        private DateTime nextDrawDate;

        public LotteryMainPageViewModel(UserModel user, LotteryApiService lotteryApiService)
        {
            User = user;
            LotteryApi = lotteryApiService;

            LoadLotteryDrawData();
            CountdownTimerText = "00 : 00 : 00 : 00"; // Placeholder text
            LotteryPrize = "£000"; // Placeholder text
            SetupCountdownTimer();
        }

        private async void LoadLotteryDrawData()
        {
            var lotteryDraw = await LotteryApi.GetNextLotteryDraw();

            if (lotteryDraw != null)
            {
                LotteryPrize = $"£{lotteryDraw.Prize}";
                NextDrawDate = lotteryDraw.DrawDate;
            }
        }

        private void SetupCountdownTimer()
        {
            _timer = new System.Timers.Timer(1000); // Update every second
            _timer.Elapsed += UpdateCountdownTimer;
            _timer.Start();
        }

        private void UpdateCountdownTimer(object sender, ElapsedEventArgs e)
        {
            var timeRemaining = NextDrawDate - DateTime.Now;

            if (timeRemaining.Ticks < 0)
            {
                CountdownTimerText = "Draw is happening!";
                _timer.Stop(); // Optionally stop the timer if the draw is over
            }
            else
            {
                CountdownTimerText = $"{timeRemaining.Days}d {timeRemaining.Hours}h {timeRemaining.Minutes}m {timeRemaining.Seconds}s";
            }
        }

        [RelayCommand]
        public async Task NavigateToPuchaseTicketsPage()
        {
            if (!User.UserIsLoggedIn)
            {
                await Shell.Current.GoToAsync("///LoginPage");
            }
            else
            {
                await Shell.Current.GoToAsync("///PurchaseLotteryTicketsPage");
            }
        }     
        
        [RelayCommand]
        public async Task NavigateToOwnedTicketsPage()
        {
            if (!User.UserIsLoggedIn)
            {
                await Shell.Current.GoToAsync("///LoginPage");
            }
            else
            {
                await Shell.Current.GoToAsync("///OwnedLotteryTicketsPage");
            }
        }        
        
        [RelayCommand]
        public async Task NavigateToLotteryRulesPage()
        {
            await Shell.Current.GoToAsync("///LotteryRulesPage");
        }                
        
        // Win history
        [RelayCommand]
        public async Task NavigateToWinningNumbersHistoryPage()
        {
            await Shell.Current.GoToAsync("///WinningNumbersHistoryPage");
        }        

        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
