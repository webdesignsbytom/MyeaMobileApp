using MyeaMobileApp.ViewModel.Apps;

namespace MyeaMobileApp.View.Apps;

public partial class AppsMainPage : ContentPage
{
	public AppsMainPageViewModel ViewModel { get; set; }
    public AppsMainPage(AppsMainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}