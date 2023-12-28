using MyeaMobileApp.ViewModel.Account.Badges;

namespace MyeaMobileApp.View.Account.Badges;

public partial class BadgesPage : ContentPage
{
	public BadgesPageViewModel ViewModel { get; set; }
    public BadgesPage(BadgesPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}