using MyeaMobileApp.ViewModel.News;

namespace MyeaMobileApp.View.News;

public partial class NewsReelPage : ContentPage
{
	public NewsReelPageViewModel ViewModel { get; set; }
    public NewsReelPage(NewsReelPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}