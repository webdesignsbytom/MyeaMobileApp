using MyeaMobileApp.ViewModel.Games.Main;

namespace MyeaMobileApp.View.Games.Main;

public partial class GamesMainPage : ContentPage
{
	public GamesMainPageViewModel ViewModel { get; set; }
	public GamesMainPage(GamesMainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}