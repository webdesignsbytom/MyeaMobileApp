using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model.Games;
using Newtonsoft.Json.Bson;
using SkiaSharp;
using System.Diagnostics;
using System.Reflection;
using System.Timers;

namespace MyeaMobileApp.ViewModel.Games.Petigotchi.MainGame
{
    public partial class PetigotchiPageViewModel : ObservableObject
    {
        public SKCanvas? gameCanvas;
        
        public PetigotchiPageViewModel()
        {
            Console.WriteLine("VM1111111111111111111111111111");
            CreateGameBitmapAnimations();
            SetupMovementTimer();
        }

        private void SetupMovementTimer()
        {
            Console.WriteLine("VM333333333333333333333333333");

            movementTimer = new System.Timers.Timer(5000); 
            movementTimer.Elapsed += OnMovementTimerElapsed;
            movementTimer.AutoReset = true;
            movementTimer.Enabled = true;
        }

        private void OnMovementTimerElapsed(object sender, ElapsedEventArgs e)
        {
            // Execute on the UI thread if necessary
            Device.BeginInvokeOnMainThread(MoveToLeftCorner);
        }

        // Camvas
        public float deviceCanvasWidth;
        public float deviceCanvasHeight;

        private System.Timers.Timer movementTimer;

        // Game Images
        private SKBitmap PetBitmap;

        public PetigotchiModel PetigotchiModel = new(100, 100);

        // Add properties for animation
        public bool MovingToLeftCorner { get; private set; } = false;

        private bool isStartingAnimationDrawn = false;

        // Set canvas from codebehind
        public void SetCanvas(SKCanvas canvas)
        {
            gameCanvas = canvas;
            if (!isStartingAnimationDrawn)
            {
                // Draw starting animation
                isStartingAnimationDrawn = true;
                DrawStartingAnimation(); 
            }
        }


        public void CreateGameBitmapAnimations()
        {
            Console.WriteLine("VM22222222222222222222222222222");

            string imageSource = "MyeaMobileApp.Resources.Images.Games.";

            using var petCatBitmapStream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{imageSource}cat1.png");
            PetBitmap = SKBitmap.Decode(petCatBitmapStream).Resize(new SKImageInfo(200, 300), SKFilterQuality.Low);
        }


        public void DrawStartingAnimation()
        {
            Console.WriteLine("VM44444444444444444444444444444444");

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

        public void MoveToLeftCorner()
        {
            Console.WriteLine("VM55555555555555555555555555555555");

            MovingToLeftCorner = true;
        }

        // Navigate to highscores
        [RelayCommand]
        public async Task NavigateToHighscoresPage()
        {
            await Shell.Current.GoToAsync("///PetigotchiHighscoresPage");
        }

        // Update pet's position
        public void UpdatePetPosition()
        {
            Console.WriteLine("VM66666666666666666666666666");

            if (MovingToLeftCorner)
            {
                // Define the target position (bottom left corner)
                float targetX = 0; // Assuming 0 is the leftmost position
                float targetY = deviceCanvasHeight - PetBitmap.Height; // Bottom of the canvas

                // Define the speed of movement
                float speed = 2.0f;

                // Calculate the direction vector
                float directionX = targetX - PetigotchiModel.Xpos;
                float directionY = targetY - PetigotchiModel.Ypos;

                // Normalize the direction
                float magnitude = (float)Math.Sqrt(directionX * directionX + directionY * directionY);
                if (magnitude > 0)
                {
                    directionX /= magnitude;
                    directionY /= magnitude;
                }

                // Move the pet towards the target
                PetigotchiModel.Xpos += directionX * speed;
                PetigotchiModel.Ypos += directionY * speed;

                // Check if the pet has reached the target position
                if (Math.Abs(PetigotchiModel.Xpos - targetX) < speed && Math.Abs(PetigotchiModel.Ypos - targetY) < speed)
                {
                    PetigotchiModel.Xpos = targetX;
                    PetigotchiModel.Ypos = targetY;
                    MovingToLeftCorner = false; // Stop moving
                }
            }
        }

        // Open Settings
        [RelayCommand]
        public async Task OpenGameSettingsContainer()
        {
            return;
        }           
        
        // Home
        [RelayCommand]
        public async Task NavigateToHomePage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
