using MyeaMobileApp.ViewModel.Admin;

namespace MyeaMobileApp.View.Admin;

public partial class AdminMainPage : ContentPage
{
	public AdminMainPageViewModel ViewModel { get; set; }
    public AdminMainPage(AdminMainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}