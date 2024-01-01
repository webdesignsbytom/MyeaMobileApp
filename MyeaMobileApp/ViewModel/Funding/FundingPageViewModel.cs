using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Funding
{
    public partial class FundingPageViewModel : ObservableObject
    {
        
        // Open shop externally
        [RelayCommand]
        public async Task NavigateAwayToShop()
        {
            string url = "https://google.com";
            await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
        }   
        
        // Back to main lottery page
        [RelayCommand]
        public async Task NavigateToLotteryMain()
        {
            await Shell.Current.GoToAsync("///LotteryMainPage");
        }        
        
        // Back to main lottery page
        [RelayCommand]
        public async Task NavigateToDonationsPage()
        {
            await Shell.Current.GoToAsync("///DonationsPage");
        }

        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
