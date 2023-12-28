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
            NewsStories.Add(new NewsStoryModel
            {
                Title = "Story 1",
                Description = "Description 1",
                StoryId = "001",
                ImageUrl = "https://example.com/image1.jpg",
                DatePublished = "2023-12-01",
                Keywords = "Keyword1, Keyword2"
            });

            // Additional fake stories
            NewsStories.Add(new NewsStoryModel
            {
                Title = "Innovations in Tech",
                Description = "Exploring the latest breakthroughs in technology.",
                StoryId = "002",
                ImageUrl = "https://example.com/image2.jpg",
                DatePublished = "2023-12-05",
                Keywords = "Technology, Innovation"
            });

            NewsStories.Add(new NewsStoryModel
            {
                Title = "Global Economic Trends",
                Description = "Analyzing the recent shifts in the global economy.",
                StoryId = "003",
                ImageUrl = "https://example.com/image3.jpg",
                DatePublished = "2023-12-10",
                Keywords = "Economy, Global"
            });

            NewsStories.Add(new NewsStoryModel
            {
                Title = "Environmental Challenges Ahead",
                Description = "A deep dive into the environmental issues facing our planet.",
                StoryId = "004",
                ImageUrl = "https://example.com/image4.jpg",
                DatePublished = "2023-12-15",
                Keywords = "Environment, Climate Change"
            });
        }
    }
}
