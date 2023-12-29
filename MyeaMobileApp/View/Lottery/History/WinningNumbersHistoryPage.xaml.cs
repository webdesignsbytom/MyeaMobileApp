using MyeaMobileApp.ViewModel.Lottery.History;

namespace MyeaMobileApp.View.Lottery.History;

public partial class WinningNumbersHistoryPage : ContentPage
{
	public WinningNumbersHistoryPageViewModel ViewModel { get; set; }
    public WinningNumbersHistoryPage(WinningNumbersHistoryPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}