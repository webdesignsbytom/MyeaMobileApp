using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Users.LoginOrRegister
{
    public partial class LoginOrRegisterPageViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task NavigateToRegisterPage()
        {
            await Shell.Current.GoToAsync("///RegisterPage");
        }
    }
}
