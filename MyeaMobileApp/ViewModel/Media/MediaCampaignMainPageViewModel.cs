using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Media
{
    public partial class MediaCampaignMainPageViewModel
    {
        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
