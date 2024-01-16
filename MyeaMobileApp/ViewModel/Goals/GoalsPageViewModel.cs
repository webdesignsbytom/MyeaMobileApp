﻿using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Goals
{
    public partial class GoalsPageViewModel
    {
        // Navigate contact
        [RelayCommand]
        public async Task NavigateToContactMainPage()
        {
            await Shell.Current.GoToAsync("///ContactMainPage");
        }

        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
