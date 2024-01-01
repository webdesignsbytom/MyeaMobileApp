using MyeaMobileApp.ViewModel.Games.O2tapper.MainGame;

namespace MyeaMobileApp.View.Games.O2tapper.MainGame;

public partial class O2tapperMainPage : ContentPage
{
	public O2tapperMainPageViewModel ViewModel { get; set; }
    public O2tapperMainPage(O2tapperMainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}