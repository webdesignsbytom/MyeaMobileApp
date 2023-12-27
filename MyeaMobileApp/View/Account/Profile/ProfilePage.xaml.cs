using MyeaMobileApp.ViewModel.Account.Profile;

namespace MyeaMobileApp.View.Account.Profile;

public partial class ProfilePage : ContentPage
{
	public ProfilePageViewModel ViewModel { get; set; }
	public ProfilePage(ProfilePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}