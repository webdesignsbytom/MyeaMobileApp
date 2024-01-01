using MyeaMobileApp.ViewModel.Donations;

namespace MyeaMobileApp.View.Donations;

public partial class DonationsPage : ContentPage
{
	public DonationsPageViewModel ViewModel { get; set; }
    public DonationsPage(DonationsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}