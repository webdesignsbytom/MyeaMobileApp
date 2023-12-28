using CommunityToolkit.Mvvm.ComponentModel;
using MyeaMobileApp.Model;
using System.Collections.ObjectModel;

namespace MyeaMobileApp.ViewModel.News
{
    public partial class NewsReelPageViewModel : ObservableObject
    {
        public ObservableCollection<NewsStoryModel> NewsStories { get; set; }

        public NewsReelPageViewModel()
        {
            NewsStories = new ObservableCollection<NewsStoryModel>();
            LoadNewsStories();
        }

        private void LoadNewsStories()
        {
            // Call your API to get news stories and add them to the NewsStories collection
            NewsStories.Add(new NewsStoryModel { Title = "Story 1", Description = "Description 1" });
        }
    }
}
