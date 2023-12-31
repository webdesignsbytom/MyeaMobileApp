using MyeaMobileApp.ViewModel.Account.InviteFriends;

namespace MyeaMobileApp.View.Account.InviteFriends;

public partial class InviteFriendsPage : ContentPage
{
	public InviteFriendsPageViewModel ViewModel { get; set; }
    public InviteFriendsPage(InviteFriendsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}