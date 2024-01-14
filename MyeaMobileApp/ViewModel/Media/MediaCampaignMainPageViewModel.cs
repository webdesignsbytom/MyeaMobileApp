using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Media
{
    public partial class MediaCampaignMainPageViewModel
    {
        // Navigate home
        [RelayCommand]
        public async Task OpenYoutubePage()
        {
            // Logic to open youtuibe page
            string url = "https://www.youtube.com/channel/UCXK4lqnNYCWpqyaho_pVPNQ";
            await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
        }        
        
        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
