using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Lottery.Rules
{
    public partial class LotteryRulesPageViewModel
    {
        [RelayCommand]
        public async Task NavigateToPuchaseTicketsPage()
        {
            await Shell.Current.GoToAsync("///PurchaseLotteryTicketsPage");
        }

        [RelayCommand]
        public async Task NavigateToLotteryMain()
        {
            await Shell.Current.GoToAsync("///LotteryMainPage");
        }
    }
}
