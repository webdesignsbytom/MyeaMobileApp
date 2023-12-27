using MyeaMobileApp.ViewModel.Users.LoginOrRegister;

namespace MyeaMobileApp.View.Users.LoginOrRegister;

public partial class LoginOrRegisterPage : ContentPage
{
	public LoginOrRegisterPageViewModel ViewModel { get; set; }
    public LoginOrRegisterPage(LoginOrRegisterPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}