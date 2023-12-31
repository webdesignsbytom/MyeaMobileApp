using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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

            NewsStories.Add(new NewsStoryModel
            {
                Title = "Revolutionary Green Energy Solutions",
                Description = "Unveiling the latest advancements in sustainable energy.",
                StoryId = "005",
                ImageUrl = "https://example.com/image5.jpg",
                DatePublished = "2023-12-20",
                Keywords = "Green Energy, Sustainability"
            });

            NewsStories.Add(new NewsStoryModel
            {
                Title = "The Future of Artificial Intelligence",
                Description = "Exploring how AI is transforming industries and daily life.",
                StoryId = "006",
                ImageUrl = "https://example.com/image6.jpg",
                DatePublished = "2023-12-25",
                Keywords = "AI, Technology"
            });

            NewsStories.Add(new NewsStoryModel
            {
                Title = "Conservation Efforts in the Amazon Rainforest",
                Description = "A look at ongoing efforts to save one of Earth's most vital ecosystems.",
                StoryId = "007",
                ImageUrl = "https://example.com/image7.jpg",
                DatePublished = "2023-12-30",
                Keywords = "Conservation, Environment"
            });

            NewsStories.Add(new NewsStoryModel
            {
                Title = "Breakthroughs in Medical Research",
                Description = "Recent discoveries that could change the face of healthcare.",
                StoryId = "008",
                ImageUrl = "https://example.com/image8.jpg",
                DatePublished = "2024-01-04",
                Keywords = "Healthcare, Medical Innovation"
            });

            NewsStories.Add(new NewsStoryModel
            {
                Title = "Exploring the Depths: Oceanography Advances",
                Description = "New findings from the uncharted territories of our oceans.",
                StoryId = "009",
                ImageUrl = "https://example.com/image9.jpg",
                DatePublished = "2024-01-09",
                Keywords = "Oceanography, Exploration"
            });
        }

        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
