namespace MyeaMobileApp.Model
{
    public class NewsStoryModel
    {
        public string StoryId { get; set;}
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string StoryHomeUrl { get; set; } = "https://google.com";
        public string DatePublished { get; set; }

        public string Keywords { get; set; }

        public Command OpenStoryCommand { get; }

        public NewsStoryModel()
        {
            OpenStoryCommand = new Command(() => OpenStory());
        }

        private async void OpenStory()
        {
            if (!string.IsNullOrWhiteSpace(StoryHomeUrl))
            {
                await Browser.OpenAsync(StoryHomeUrl, BrowserLaunchMode.SystemPreferred);
            }
        }
    }
}
