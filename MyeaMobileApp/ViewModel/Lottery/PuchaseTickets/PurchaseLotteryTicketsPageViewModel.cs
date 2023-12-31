using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace MyeaMobileApp.ViewModel.Lottery.PuchaseTickets
{
    public partial class PurchaseLotteryTicketsPageViewModel
    {
        [RelayCommand]
        public async Task SelectNumber(string numberString)
        {
            if (int.TryParse(numberString, out int number))
            {
                Debug.WriteLine($"Button {number} clicked.");
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
