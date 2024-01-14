using MyeaMobileApp.ViewModel.Events.Main;

namespace MyeaMobileApp.View.Events.Main;

public partial class EventsMainPage : ContentPage
{
	public EventsMainPageViewModel ViewModel { get; set; }
    public EventsMainPage(EventsMainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}