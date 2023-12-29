using MyeaMobileApp.ViewModel.Games.Petigotchi;

namespace MyeaMobileApp.View.Games.Petigotchi;

public partial class PetigotchiPage : ContentPage
{
	public PetigotchiPageViewModel ViewModel { get; set; }
    public PetigotchiPage(PetigotchiPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}