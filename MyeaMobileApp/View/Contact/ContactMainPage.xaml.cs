using MyeaMobileApp.ViewModel.Contact;

namespace MyeaMobileApp.View.Contact;

public partial class ContactMainPage : ContentPage
{
	public ContactMainPageViewModel ViewModel { get; set; }
    public ContactMainPage(ContactMainPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}