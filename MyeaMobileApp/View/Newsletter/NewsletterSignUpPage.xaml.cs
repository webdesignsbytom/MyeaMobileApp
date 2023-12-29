using MyeaMobileApp.ViewModel.Newsletter;

namespace MyeaMobileApp.View.Newsletter;

public partial class NewsletterSignUpPage : ContentPage
{
	public NewsletterSignUpPageViewModel ViewModel { get; set; }
    public NewsletterSignUpPage(NewsletterSignUpPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}