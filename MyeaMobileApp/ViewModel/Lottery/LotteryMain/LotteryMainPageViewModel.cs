using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model;
using System.Timers;

namespace MyeaMobileApp.ViewModel.Lottery.LotteryMain
{
    public partial class LotteryMainPageViewModel : ObservableObject
    {
        public UserModel User { get; set; }
        private System.Timers.Timer _timer;
        private string _countdownText;

        [ObservableProperty]
        private string countdownTimerText;

        public LotteryMainPageViewModel(UserModel user)
        {
            User = user;
            CountdownTimerText = "00 : 00 : 00 : 00"; // Placeholder text
            SetupCountdownTimer();
        }

        private void SetupCountdownTimer()
        {
            _timer = new System.Timers.Timer(1000); // Update every second
            _timer.Elapsed += UpdateCountdownTimer;
            _timer.Start();
        }

        private void UpdateCountdownTimer(object sender, ElapsedEventArgs e)
        {
            var nextDraw = GetNextDrawTime();
            var timeRemaining = nextDraw - DateTime.Now;

            if (timeRemaining.Ticks < 0)
            {
                CountdownTimerText = "Draw is happening!";
            }
            else
            {
                CountdownTimerText = $"{timeRemaining.Days}d {timeRemaining.Hours}h {timeRemaining.Minutes}m {timeRemaining.Seconds}s";
            }
        }

        private DateTime GetNextDrawTime()
        {
            var now = DateTime.Now;
            var nextFriday = now.AddDays((int)DayOfWeek.Friday - (int)now.DayOfWeek + (now.DayOfWeek > DayOfWeek.Friday ? 7 : 0));
            return new DateTime(nextFriday.Year, nextFriday.Month, nextFriday.Day, 19, 0, 0); // Next Friday at 7 PM
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

        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
