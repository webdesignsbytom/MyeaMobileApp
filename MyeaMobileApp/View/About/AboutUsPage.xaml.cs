using MyeaMobileApp.ViewModel.About;

namespace MyeaMobileApp.View.About;

public partial class AboutUsPage : ContentPage
{
	public AboutUsPageViewModel ViewModel { get; set; }
	public AboutUsPage(AboutUsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}