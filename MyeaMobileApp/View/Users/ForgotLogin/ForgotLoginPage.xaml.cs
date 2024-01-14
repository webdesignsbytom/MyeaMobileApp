using MyeaMobileApp.View.Users.ForgotLogin;

namespace MyeaMobileApp.View.Users.ForgotLogin;

public partial class ForgotLoginPage : ContentPage
{
	public ForgotLoginPageViewModel ViewModel { get; set; }
    public ForgotLoginPage(ForgotLoginPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}