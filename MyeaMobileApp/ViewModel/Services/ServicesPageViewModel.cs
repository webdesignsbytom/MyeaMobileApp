﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Services
{
    public partial class ServicesPageViewModel : ObservableObject
    {
        // Navigate to media
        [RelayCommand]
        public async Task NavigateToMediaPage()
        {
            await Shell.Current.GoToAsync("///MediaCampaignMainPage");
        }           
        
        // Navigate to media
        [RelayCommand]
        public async Task NavigateToAppsPage()
        {
            await Shell.Current.GoToAsync("///AppsMainPage");
        }          
        
        // Navigate to games
        [RelayCommand]
        public async Task NavigateToGamesPage()
        {
            await Shell.Current.GoToAsync("///GamesMainPage");
        }        
        
        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
