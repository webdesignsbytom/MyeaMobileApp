using MyeaMobileApp.ViewModel.Account.EditProfile;

namespace MyeaMobileApp.View.Account.EditProfile;

public partial class EditProfilePage : ContentPage
{
	public EditProfilePageViewModel ViewModel { get; set; }
    public EditProfilePage(EditProfilePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}