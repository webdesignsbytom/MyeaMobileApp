using MyeaMobileApp.ViewModel.Main;

namespace MyeaMobileApp.View.Main
{
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel ViewModel { get; set; }
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = ViewModel = viewModel;
        }

        public MainPage()
        {
        }
    }

}
