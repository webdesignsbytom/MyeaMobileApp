using MyeaMobileApp.ViewModel.SocialMedia;

namespace MyeaMobileApp.View.SocialMedia;

public partial class SocialMediaMainPage : ContentPage
{
	public SocialMediaMainPageViewModel ViewModel { get; set; }
	public SocialMediaMainPage(SocialMediaMainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}