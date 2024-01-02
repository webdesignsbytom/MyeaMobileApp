using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model.User;

namespace MyeaMobileApp.ViewModel.Lottery.OwnedTickets
{
    public partial class OwnedLotteryTicketsPageViewModel
    {
        public UserModel User { get; set; }
        public OwnedLotteryTicketsPageViewModel(UserModel user)
        {
            User = user;
        }

        // Buy tickets
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

        // Back to main lottery page
        [RelayCommand]
        public async Task NavigateToLotteryMain()
        {
            await Shell.Current.GoToAsync("///LotteryMainPage");
        }
    }
}
