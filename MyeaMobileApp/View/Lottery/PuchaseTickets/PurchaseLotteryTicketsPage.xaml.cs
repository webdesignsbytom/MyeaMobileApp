using MyeaMobileApp.ViewModel.Lottery.PuchaseTickets;

namespace MyeaMobileApp.View.Lottery.PuchaseTickets;

public partial class PurchaseLotteryTicketsPage : ContentPage
{
	public PurchaseLotteryTicketsPageViewModel ViewModel { get; set; }
    public PurchaseLotteryTicketsPage(PurchaseLotteryTicketsPageViewModel viewModel)

    {
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}