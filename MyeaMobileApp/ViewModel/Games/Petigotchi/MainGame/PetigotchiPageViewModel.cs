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

        // Menu options
        [ObservableProperty]
        private bool isFoodMenuVisible = false;        
        
        [ObservableProperty]
        private bool isSettingsMenuVisible = false;        
        
        [ObservableProperty]
        private bool isPlayMenuVisible = false;        
        
        [ObservableProperty]
        private int health;        
        
        [ObservableProperty]
        private int hunger;        
        
        [ObservableProperty]
        private int happiness;        
        
        [ObservableProperty]
        private int cleanliness;        
        
        [ObservableProperty]
        private string petName;

        public PetigotchiPageViewModel()
        {
            Console.WriteLine("VM1111111111111111111111111111");
            CreateGameBitmapAnimations();
            // Start game loop
            SetupMovementTimer();
            SetPetStats();
        }

        private void SetPetStats()
        {
            Health = Petigotchi.Health;
            Hunger = Petigotchi.Hunger;
            Happiness = Petigotchi.Happiness;
            Cleanliness = Petigotchi.Cleanliness;
            PetName = Petigotchi.PetName;
        }

        [RelayCommand]
        public async Task OpenFoodMenu()
        {
            IsFoodMenuVisible = true;
        }        
        
        [RelayCommand]
        public async Task CloseFoodMenu()
        {
            IsFoodMenuVisible = false;
        }

        private void SetupMovementTimer()
        {
            Console.WriteLine("VM333333333333333333333333333");

            movementTimer = new System.Timers.Timer(1000); 
            movementTimer.Elapsed += OnMovementTimerElapsed;
            movementTimer.AutoReset = true;
            movementTimer.Enabled = true;
        }

        private void OnMovementTimerElapsed(object sender, ElapsedEventArgs e)
        {
        }

        // Camvas
        public double deviceCanvasWidth;
        public double deviceCanvasHeight;

        private System.Timers.Timer movementTimer;

        // Game Images
        private SKBitmap PetBitmap;


        public PetigotchiModel Petigotchi = new();


        // Add properties for animation
        public bool MovingToLeftCorner { get; private set; } = false;

        private bool isStartingAnimationDrawn = false;

        // Set canvas from codebehind
        public void SetCanvas(SKCanvas canvas)
        {
            gameCanvas = canvas;

            var screenMetrics = DeviceDisplay.MainDisplayInfo; // Get the screen metrics

            // Set the canvas size to match the screen size
            deviceCanvasWidth = (double)screenMetrics.Width / screenMetrics.Density;
            deviceCanvasHeight = (double)screenMetrics.Height / screenMetrics.Density;

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

            // Calculate the center position
            double centerX = (deviceCanvasWidth - PetBitmap.Width) / 2;
            double centerY = (deviceCanvasHeight - PetBitmap.Height) / 2;

            Console.WriteLine($"XXXXXXXXXXX {centerX}:{centerY}");

            Petigotchi.UpdatePetigotchiPosition(centerX, centerY);

            // Set animations
            var petPos = mat.Invert().MapPoint(100, 220);

            Console.WriteLine($"YYYYYYYYYYYYY {petPos.X}:{petPos.Y}");

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
                double targetX = 0; // Assuming 0 is the leftmost position
                double targetY = deviceCanvasHeight - PetBitmap.Height; // Bottom of the canvas

                // Define the speed of movement
                double speed = 2.0f;

                // Calculate the direction vector
                double directionX = targetX - Petigotchi.Xpos;
                double directionY = targetY - Petigotchi.Ypos;

                // Normalize the direction
                double magnitude = (double)Math.Sqrt(directionX * directionX + directionY * directionY);
                if (magnitude > 0)
                {
                    directionX /= magnitude;
                    directionY /= magnitude;
                }

                // Move the pet towards the target
                Petigotchi.Xpos += directionX * speed;
                Petigotchi.Ypos += directionY * speed;

                // Check if the pet has reached the target position
                if (Math.Abs(Petigotchi.Xpos - targetX) < speed && Math.Abs(Petigotchi.Ypos - targetY) < speed)
                {
                    Petigotchi.Xpos = targetX;
                    Petigotchi.Ypos = targetY;
                    MovingToLeftCorner = false; // Stop moving
                }
            }
        }

        // Open Settings
        [RelayCommand]
        public async Task OpenSettingsMenu()
        {
            IsSettingsMenuVisible = true;
        }           
        
        // Close Settings
        [RelayCommand]
        public async Task CloseSettingsMenu()
        {
            IsSettingsMenuVisible = false;
        }              
        
        // Open play
        [RelayCommand]
        public async Task OpenPlayMenu()
        {
            IsPlayMenuVisible = true;
        }           
        
        // Close play
        [RelayCommand]
        public async Task ClosePlayMenu()
        {
            IsPlayMenuVisible = false;
        }           
        
        // Home
        [RelayCommand]
        public async Task NavigateToHomePage()
        {
            await Shell.Current.GoToAsync("///MainPage");
        }
    }
}
