using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Users.Login
{
    public partial class LoginPageViewModel : ObservableObject
    {
        [RelayCommand]
        public async Task NavigateToRegisterPage()
        {
            await Shell.Current.GoToAsync("///RegisterPage");
        }
    }
}
