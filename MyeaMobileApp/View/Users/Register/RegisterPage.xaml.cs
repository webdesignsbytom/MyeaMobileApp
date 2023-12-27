using MyeaMobileApp.ViewModel.Users.Register;

namespace MyeaMobileApp.View.Users.Register;

public partial class RegisterPage : ContentPage
{
	public RegisterPageViewModel ViewModel { get; set; }
	public RegisterPage(RegisterPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}