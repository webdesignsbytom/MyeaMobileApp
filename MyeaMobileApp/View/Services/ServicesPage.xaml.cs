using MyeaMobileApp.ViewModel.Services;

namespace MyeaMobileApp.View.Services;

public partial class ServicesPage : ContentPage
{
	public ServicesPageViewModel ViewModel { get; set; }
    public ServicesPage(ServicesPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}