using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model.Products;
using System.Collections.ObjectModel;

namespace MyeaMobileApp.ViewModel.Apps
{
    public partial class AppsMainPageViewModel : ObservableObject
    {
        public ObservableCollection<WebProductModel> WebProducts { get; set; }
        public ObservableCollection<AppProductModel> AppProducts { get; set; }

        public AppsMainPageViewModel()
        {
            WebProducts = new ObservableCollection<WebProductModel>()
            {
                new WebProductModel {
                    Name = "MyEco Shop",
                    Url = "https://myecoapp.shop",
                    ImageUrl = "https://ecosmartsolutions.com/image.jpg",
                    Description = "Our website where we sell using dropshipping so we have no outgoing costs, and all profits go towards the environment and our projects"
                    },
                new WebProductModel {
                    Name = "MyEco Home",
                    Url = "https://myecoapp.org/myecohome",
                    ImageUrl = "https://greeninnovate.com/image.jpg",
                    Description = "We created a series of homepages you can set your browser to, all with interesting features you will enjoy and that makes us a small amount of money per use."
                    },
            };            
            
            AppProducts = new ObservableCollection<AppProductModel>()
            {
                new AppProductModel {
                    Name = "Cat App",
                    Url = "https://catapp.com",
                    ImageUrl = "https://ecosmartsolutions.com/image.jpg",
                    Description = "Just a great app full of cats for you to enjoy. It also tracks cat data to help learn about them."
                    },
            };
        }

        // Open website
        [RelayCommand]
        public async Task VisitWebsite(string url)
        {
            if (!string.IsNullOrWhiteSpace(url))
            {
                await Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
            }
        }


        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
