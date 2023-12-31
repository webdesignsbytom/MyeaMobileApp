using MyeaMobileApp.ViewModel.Funding;

namespace MyeaMobileApp.View.Funding;

public partial class FundingPage : ContentPage
{
	public FundingPageViewModel ViewModel { get; set; }
    public FundingPage(FundingPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}