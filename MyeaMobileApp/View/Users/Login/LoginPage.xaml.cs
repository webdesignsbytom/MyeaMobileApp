using MyeaMobileApp.ViewModel.Users.Login;

namespace MyeaMobileApp.View.Users.Login;

public partial class LoginPage : ContentPage
{
	public LoginPageViewModel ViewModel { get; set; }
	public LoginPage(LoginPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}