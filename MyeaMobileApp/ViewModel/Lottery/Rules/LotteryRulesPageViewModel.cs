using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model.User;

namespace MyeaMobileApp.ViewModel.Lottery.Rules
{
    public partial class LotteryRulesPageViewModel : ObservableObject
    {
        public UserModel User { get; set; }
        public LotteryRulesPageViewModel(UserModel user) 
        {
            User = user;
        }

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

        [RelayCommand]
        public async Task NavigateToLotteryMain()
        {
            await Shell.Current.GoToAsync("///LotteryMainPage");
        }
    }
}
