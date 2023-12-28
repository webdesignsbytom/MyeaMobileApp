using MyeaMobileApp.ViewModel.Goals;

namespace MyeaMobileApp.View.Goals;

public partial class GoalsPage : ContentPage
{
	public GoalsPageViewModel ViewModel { get; set; }
    public GoalsPage(GoalsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}