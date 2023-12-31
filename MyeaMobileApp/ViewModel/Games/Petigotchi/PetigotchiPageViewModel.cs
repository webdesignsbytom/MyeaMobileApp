using CommunityToolkit.Mvvm.ComponentModel;
using MyeaMobileApp.Model;
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
            Console.WriteLine("LOAD XXXXXXXXXXXXXXXXXXXXXXX");
            Debug.WriteLine("LOAD XXXXXXXXXXXXXXXXXXXXXXX");
            CreateGameBitmapAnimations();
        }

        // Camvas
        private float deviceCanvasWidth;
        private float deviceCanvasHeight;

        // Game Images
        private SKBitmap PetBitmap;

        public PetigotchiModel PetigotchiModel = new(100, 100);

        // Set canvas from codebehind
        public void SetCanvas(SKCanvas canvas)
        {
            Debug.WriteLine("SSSSSSSSSSSSSSSSSSSSSSET");
            Console.WriteLine("SSSSSSSSSSSSSSSSSSSSSSET");
            gameCanvas = canvas;
        }


        public void CreateGameBitmapAnimations()
        {
            Debug.WriteLine("11111111111111111111111111111");
            Console.WriteLine("11111111111111111111111111111");
            string imageSource = "MyeaMobileApp.Resources.Images.Games.";

            using var petCatBitmapStream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{imageSource}cat1.png");
            PetBitmap = SKBitmap.Decode(petCatBitmapStream).Resize(new SKImageInfo(200, 300), SKFilterQuality.Low);
        }


        public void DrawStartingAnimation()
        {
            Debug.WriteLine("22222222222222222222222222");
            Console.WriteLine("2222222222222222222222222222");
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
    }
}
