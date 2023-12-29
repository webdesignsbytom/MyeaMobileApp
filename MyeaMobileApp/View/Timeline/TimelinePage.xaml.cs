using MyeaMobileApp.ViewModel.Timeline;

namespace MyeaMobileApp.View.Timeline;

public partial class TimelinePage : ContentPage
{
	public TimelinePageViewModel ViewModel { get; set; }
	public TimelinePage(TimelinePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}