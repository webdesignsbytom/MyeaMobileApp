using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model.Games;
using Newtonsoft.Json.Bson;
using SkiaSharp;
using System.Diagnostics;
using System.Reflection;

namespace MyeaMobileApp.ViewModel.Games.Petigotchi
{
    public partial class PetigotchiPageViewModel : ObservableObject
    {
        public SKCanvas? gameCanvas;
        
        public PetigotchiPageViewModel()
        {
            CreateGameBitmapAnimations();
        }

        // Camvas
        public float deviceCanvasWidth;
        public float deviceCanvasHeight;

        // Game Images
        private SKBitmap PetBitmap;

        public PetigotchiModel PetigotchiModel = new(100, 100);

        // Set canvas from codebehind
        public void SetCanvas(SKCanvas canvas)
        {
            gameCanvas = canvas;
        }


        public void CreateGameBitmapAnimations()
        {
            string imageSource = "MyeaMobileApp.Resources.Images.Games.";

            using var petCatBitmapStream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{imageSource}cat1.png");
            PetBitmap = SKBitmap.Decode(petCatBitmapStream).Resize(new SKImageInfo(200, 300), SKFilterQuality.Low);
        }


        public void DrawStartingAnimation()
        {

            if (gameCanvas == null)
            {
                throw new InvalidOperationException("gameCanvas must be set to an instance of an object");
            }

            var mat = SKMatrix.CreateScale(1.0f, 1.0f);

            deviceCanvasWidth = gameCanvas.DeviceClipBounds.Width;
            deviceCanvasHeight = gameCanvas.DeviceClipBounds.Height;

            // Set animations
            var petPos = mat.Invert().MapPoint(PetigotchiModel.Xpos, PetigotchiModel.Ypos);
            gameCanvas.DrawBitmap(PetBitmap, new SKPoint(petPos.X, petPos.Y), new SKPaint());
        }

        // Navigate to highscores
        [RelayCommand]
        public async Task NavigateToHighscoresPage()
        {
            await Shell.Current.GoToAsync("///PetigotchiHighscoresPage");
        }

        // Open Settings
        [RelayCommand]
        public async Task OpenGameSettingsContainer()
        {
            return;
        }        
        
        
    }
}
