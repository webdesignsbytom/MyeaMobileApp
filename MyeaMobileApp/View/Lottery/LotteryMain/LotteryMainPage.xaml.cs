using MyeaMobileApp.ViewModel.Lottery.LotteryMain;

namespace MyeaMobileApp.View.Lottery.LotteryMain;

public partial class LotteryMainPage : ContentPage
{
	public LotteryMainPageViewModel ViewModel { get; set; }
    public LotteryMainPage(LotteryMainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}