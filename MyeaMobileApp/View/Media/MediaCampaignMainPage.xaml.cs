using MyeaMobileApp.ViewModel.Media;

namespace MyeaMobileApp.View.Media;

public partial class MediaCampaignMainPage : ContentPage
{
	public MediaCampaignMainPageViewModel ViewModel { get; set; }
    public MediaCampaignMainPage(MediaCampaignMainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}