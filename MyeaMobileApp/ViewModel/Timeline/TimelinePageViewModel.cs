using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Timeline
{
    public partial class TimelinePageViewModel
    {
        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
