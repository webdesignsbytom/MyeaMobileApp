using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model.Events;
using MyeaMobileApp.Services.Events;
using System.Collections.ObjectModel;

namespace MyeaMobileApp.ViewModel.Events.Main
{
    public partial class EventsMainPageViewModel : ObservableObject
    {
        public EcoEventsApiService EcoEventsApi { get; set; }
        public ObservableCollection<PlannedEventModel> EventsList { get; set; }

        [ObservableProperty]
        public bool? isLoading = false;

        [ObservableProperty]
        public bool? isVisible = true;

        public EventsMainPageViewModel(EcoEventsApiService ecoEventsApi) 
        {
            EventsList = new ObservableCollection<PlannedEventModel>();
            EcoEventsApi = ecoEventsApi;
            LoadEvents();
        }

        public async Task LoadEvents()
        {
            IsVisible = false;
            IsLoading = true;

            var events = await EcoEventsApi.GetAllEcoEvents();
            EventsList.Clear();

            foreach (var eventItem in events)
            {
                Console.WriteLine(eventItem.ToString());
                EventsList.Add(eventItem);
            }

            IsVisible = true;
            IsLoading = false;
        }

        // Create event 
        [RelayCommand]
        public async Task NavigateToCreateEventPage()
        {
            await Shell.Current.GoToAsync("///CreateEventPage");
        }        
        
        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
