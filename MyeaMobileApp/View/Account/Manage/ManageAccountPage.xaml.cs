using MyeaMobileApp.ViewModel.Account.Manage;

namespace MyeaMobileApp.View.Account.Manage;

public partial class ManageAccountPage : ContentPage
{
	public ManageAccountPageViewModel ViewModel { get; set; }
    public ManageAccountPage(ManageAccountPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}