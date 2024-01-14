using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model.Lottery;
using System.Collections.ObjectModel;
using Microsoft.Maui.Graphics;

namespace MyeaMobileApp.ViewModel.Lottery.History
{
    public partial class WinningNumbersHistoryPageViewModel : ObservableObject
    {
        public ObservableCollection<LotteryTicketResultModel> LotteryResultHistory { get; set; }

        private readonly List<Color> _colors = new List<Color>
        {
            Colors.Red,
            Colors.Blue,
            Colors.Green,
            Colors.Yellow,
            Colors.Purple
        };

        public WinningNumbersHistoryPageViewModel()
        {
            LotteryResultHistory = new ObservableCollection<LotteryTicketResultModel>();
            LoadTempWinningTickets();
        }

        private void LoadTempWinningTickets()
        {
            // Example lottery number sets with corresponding bonus balls
            var exampleTickets = new List<(List<int> Numbers, int BonusBall)>
            {
                (new List<int> { 5, 40, 23, 44, 1 }, 12),
                (new List<int> { 15, 4, 33, 22, 11 }, 6),
                (new List<int> { 8, 19, 27, 34, 10 }, 15),                
                (new List<int> { 5, 40, 23, 44, 1 }, 12),
                (new List<int> { 15, 4, 33, 22, 11 }, 6),
                (new List<int> { 8, 19, 27, 34, 10 }, 15),                
                (new List<int> { 5, 40, 23, 44, 1 }, 12),
                (new List<int> { 15, 4, 33, 22, 11 }, 6),
                (new List<int> { 8, 19, 27, 34, 10 }, 15),                
                (new List<int> { 5, 40, 23, 44, 1 }, 12),
                (new List<int> { 15, 4, 33, 22, 11 }, 6),
                (new List<int> { 8, 19, 27, 34, 10 }, 15),                
                (new List<int> { 5, 40, 23, 44, 1 }, 12),
                (new List<int> { 15, 4, 33, 22, 11 }, 6),
                (new List<int> { 8, 19, 27, 34, 10 }, 15),
            };

            // Iterate over the example tickets to create ticket models
            for (int i = 0; i < exampleTickets.Count; i++)
            {
                var (numbers, bonusBall) = exampleTickets[i]; // Deconstruct the pair
                var ticket = new LotteryTicketResultModel
                {
                    SelectedNumbers = numbers,
                    BonusBall = bonusBall,
                    BackgroundColor = _colors[i % _colors.Count] // Assign a color from the list
                };
                LotteryResultHistory.Add(ticket);
            }
        }

        // Nav back to lottery main
        [RelayCommand]
        public async Task NavigateToLotteryPage()
        {
            await Shell.Current.GoToAsync("///LotteryMainPage");
        }
    }
}
