using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model.User;
using MyeaMobileApp.Services.Events;
using System.Windows.Input;

namespace MyeaMobileApp.ViewModel.Events.CreateEvent
{
    public partial class CreateEventPageViewModel : ObservableObject
    {
        public EcoEventsApiService EcoEventsApi { get; set; }
        public UserModel User { get; set; }

        [ObservableProperty]
        public string? eventTitle;
        [ObservableProperty]
        public string? eventLocation;
        [ObservableProperty]
        public string? eventInfo;
        [ObservableProperty]
        public ImageSource selectedImage;
        [ObservableProperty]
        public DateTime? eventDate;

        public CreateEventPageViewModel(EcoEventsApiService ecoEventsApi, UserModel user)
        {
            EcoEventsApi = ecoEventsApi;
            User = user;
        }

        // Post new event
        [RelayCommand]
        public async Task PostNewEvent()
        {
           await EcoEventsApi.CreateNewEcoEvent(User.UserId, EventDate, EventTitle, EventLocation, EventInfo, SelectedImage);
        }

        [RelayCommand]
        public async void SelectImage()
        {
            try
            {
                var result = await MediaPicker.PickPhotoAsync();
                if (result != null)
                {
                    var stream = await result.OpenReadAsync();
                    SelectedImage = ImageSource.FromStream(() => stream);
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions
            }
        }

        // Navigate back ot events main
        [RelayCommand]
        public async Task NavigateToEventsMainPage()
        {
            await Shell.Current.GoToAsync("///EventsMainPage");
        }
    }
}

