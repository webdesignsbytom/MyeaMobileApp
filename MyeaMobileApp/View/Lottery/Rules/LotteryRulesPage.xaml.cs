using MyeaMobileApp.ViewModel.Lottery.Rules;

namespace MyeaMobileApp.View.Lottery.Rules;

public partial class LotteryRulesPage : ContentPage
{
	public LotteryRulesPageViewModel ViewModel { get; set; }
    public LotteryRulesPage(LotteryRulesPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}