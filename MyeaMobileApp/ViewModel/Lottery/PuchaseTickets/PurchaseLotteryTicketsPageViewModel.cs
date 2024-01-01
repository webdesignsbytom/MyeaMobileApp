using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MyeaMobileApp.ViewModel.Lottery.PuchaseTickets
{
    public partial class PurchaseLotteryTicketsPageViewModel
    {
        public ObservableCollection<int> SelectedNumbers { get; set; } = new();

        [RelayCommand]
        public async Task SelectNumber(string numberString)
        {
            if (int.TryParse(numberString, out int number))
            {
                Debug.WriteLine($"Button {number} clicked.");
                SelectedNumbers.Add((int)number);
            }
            else
            {
                Debug.WriteLine("Invalid number format.");
            }
        }

        [RelayCommand]
        public async Task NavigateToLotteryMain()
        {
            await Shell.Current.GoToAsync("///LotteryMainPage");
        }
    }
}
