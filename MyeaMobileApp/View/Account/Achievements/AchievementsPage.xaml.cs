using MyeaMobileApp.ViewModel.Account.Achievements;

namespace MyeaMobileApp.View.Account.Achievements;

public partial class AchievementsPage : ContentPage
{
	public AchievementsPageViewModel ViewModel { get; set; }
    public AchievementsPage(AchievementsPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}
}