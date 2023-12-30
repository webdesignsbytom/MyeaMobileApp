using CommunityToolkit.Mvvm.ComponentModel;
using SkiaSharp;

namespace MyeaMobileApp.ViewModel.Games.Petigotchi
{
    public partial class PetigotchiPageViewModel : ObservableObject
    {
        public SKCanvas? gameCanvas;

        // Set canvas from codebehind
        public void SetCanvas(SKCanvas canvas)
        {
            gameCanvas = canvas;
        }
    }
}
