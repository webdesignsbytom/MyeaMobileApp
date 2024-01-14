using MyeaMobileApp.ViewModel.Events.CreateEvent;

namespace MyeaMobileApp.View.Events.CreateEvent;

public partial class CreateEventPage : ContentPage
{
	public CreateEventPageViewModel ViewModel { get; set; }
    public CreateEventPage(CreateEventPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}