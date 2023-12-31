namespace MyeaMobileApp.View.Games.Petigotchi.Highscores;

public partial class PetigotchiHighscoresPage : ContentPage
{
	public PetigotchiHighscoresPage ViewModel { get; set; }
    public PetigotchiHighscoresPage(PetigotchiHighscoresPage viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}