using MyeaMobileApp.ViewModel.Lottery.OwnedTickets;

namespace MyeaMobileApp.View.Lottery.OwnedTickets;

public partial class OwnedLotteryTicketsPage : ContentPage
{
	public OwnedLotteryTicketsPageViewModel ViewModel { get; set; }
    public OwnedLotteryTicketsPage(OwnedLotteryTicketsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}