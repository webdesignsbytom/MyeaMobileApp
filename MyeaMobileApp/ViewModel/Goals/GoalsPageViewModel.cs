﻿using CommunityToolkit.Mvvm.Input;

namespace MyeaMobileApp.ViewModel.Goals
{
    public partial class GoalsPageViewModel
    {
        // Navigate home
        [RelayCommand]
        public async Task NavigateToMainPage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
