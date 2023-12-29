using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Lottery.LotteryMain
{
    public partial class LotteryMainPageViewModel
    {
        [RelayCommand]
        public async Task NavigateToPuchaseTicketsPage()
        {
            await Shell.Current.GoToAsync("///PurchaseLotteryTicketsPage");
        }        
        
        [RelayCommand]
        public async Task NavigateToOwnedTicketsPage()
        {
            await Shell.Current.GoToAsync("///OwnedLotteryTicketsPage");
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
