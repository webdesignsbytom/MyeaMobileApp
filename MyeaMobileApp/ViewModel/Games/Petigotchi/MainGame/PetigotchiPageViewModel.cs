using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MyeaMobileApp.Model;
using MyeaMobileApp.Model.Games;
using MyeaMobileApp.Model.User;
using MyeaMobileApp.Services.Games;
using SkiaSharp;
using System.Reflection;
using System.Timers;
using Timer = System.Timers.Timer;

namespace MyeaMobileApp.ViewModel.Games.Petigotchi.MainGame
{
    public partial class PetigotchiPageViewModel : ObservableObject
    {
        public PetigotchiApiService PetigotchiApi { get; set; }
        public PetigotchiModel PetigotchiModel { get; set; }
        public UserModel User { get; set; }
        public ProfileModel Profile { get; set; }

        public SKCanvas? gameCanvas;

        // Menu options
        [ObservableProperty]
        private bool isRenamePetVisible = false;

        [ObservableProperty]
        private bool isFoodMenuVisible = false;

        [ObservableProperty]
        private bool isSettingsMenuVisible = false;

        [ObservableProperty]
        private bool isPlayMenuVisible = false;

        [ObservableProperty]
        private bool isFirstTimeNamingVisible = true;

        // Player bools
        private bool IsFirstTimeNaming = true;

        // Pet Stats
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

        private string PetId;

        [ObservableProperty]
        private string newPetName;

        // Max Stats
        private int MaxHunger = 100;

        // Timers
        // Game play
        public Timer gamePlayTimer;
        // Hunger
        public Timer petHungerTimer;

        // Movement
        private float moveStep = 1.0f;
        private float totalMovement = 0;
        private const float MaxMovement = 50.0f;

        public PetigotchiPageViewModel(PetigotchiApiService petigotchiApi, UserModel user, PetigotchiModel petigotchiModel, ProfileModel profileModel)
        {
            PetigotchiApi = petigotchiApi;
            PetigotchiModel = petigotchiModel;
            User = user;
            Profile = profileModel;

            Console.WriteLine("VM1111111111111111111111111111");


            // Start game loop
            SetUpGame();
        }

        public void SetUpGame() 
        {
            Console.WriteLine("VM222222222222222222222222222222222");
            // Create animations to use in game
            CreateGameBitmapAnimations();
            Console.WriteLine("VM2222222222222223333333333333333333");
            // Set stats from model
            SetUserStats();
            SetPetStats();
            SetTimers();
            Console.WriteLine("VM2222222222222224444444444444444");
        }        
       


        private void SetTimers()
        {
            SetHungerTimer();
            SetGameTimer();
        }
        public void CreateGameBitmapAnimations()
        {
            Console.WriteLine("VMCreateGameBitmapAnimations");
            // Image source
            string imageSource = "MyeaMobileApp.Resources.Images.Games.";

            using var petCatBitmapStream = Assembly.GetExecutingAssembly().GetManifestResourceStream($"{imageSource}cat1.png");
            petBitmap = SKBitmap.Decode(petCatBitmapStream).Resize(new SKImageInfo(200, 300), SKFilterQuality.Low);
        }

        private void SetHungerTimer()
        {
            petHungerTimer = new Timer(TimeSpan.FromSeconds(2).TotalMilliseconds);
            petHungerTimer.Elapsed += OnHungerTimerElapsed; // Separate handler
            petHungerTimer.AutoReset = true;
            petHungerTimer.Enabled = true;
        }

        private void SetGameTimer()
        {
            gamePlayTimer = new Timer(TimeSpan.FromMilliseconds(32.0f).TotalMilliseconds);
            gamePlayTimer.Elapsed += OnGameTimerElapsed; // Separate handler
            gamePlayTimer.AutoReset = true;
            gamePlayTimer.Enabled = true;
        }

        private void OnHungerTimerElapsed(object source, ElapsedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Console.WriteLine("@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");
                Hunger++;
                PetigotchiModel.Hunger = Hunger;
                if (PetigotchiModel.Hunger >= MaxHunger)
                {
                    PetigotchiModel.PetIsAlive = false;
                    // Additional logic for hunger timer
                }
            });
        }

        private void OnGameTimerElapsed(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("##############################");
            MainThread.BeginInvokeOnMainThread(() =>
            {
                PetigotchiModel.UpdatePetPosition((float)moveStep, (float)0);
            });
        }

        
        private void SetUserStats()
        {
            IsFirstTimeNaming = User.IsFirstTimeNaming;
        }

        private void SetPetStats()
        {
            Health = PetigotchiModel.Health;
            Hunger = PetigotchiModel.Hunger;
            Happiness = PetigotchiModel.Happiness;
            Cleanliness = PetigotchiModel.Cleanliness;
            PetName = PetigotchiModel.PetName;
            PetId = PetigotchiModel.PetId;
        }


        // Camvas
        public double deviceCanvasWidth;
        public double deviceCanvasHeight;

        // Game Images
        private SKBitmap petBitmap;




        // Add properties for animation
        public bool MovingToLeftCorner { get; private set; } = false;

        private bool isStartingAnimationDrawn = false;

        // Set canvas from codebehind
        public void GameLoop(SKCanvas canvas)
        {
            gameCanvas = canvas;

            var screenMetrics = DeviceDisplay.MainDisplayInfo; // Get the screen metrics

            // Set the canvas size to match the screen size
            deviceCanvasWidth = (double)screenMetrics.Width / screenMetrics.Density;
            deviceCanvasHeight = (double)screenMetrics.Height / screenMetrics.Density;
        }


        public void DrawGameAnimations()
        {
            Console.WriteLine("VMDrawStartingAnimation");

            if (gameCanvas == null)
            {
                throw new InvalidOperationException("gameCanvas must be set to an instance of an object");
            }

            var mat = SKMatrix.CreateScale(1.0f, 1.0f);

            var catPos = mat.Invert().MapPoint((float)PetigotchiModel.Xpos, (float)PetigotchiModel.Ypos);
            gameCanvas.DrawBitmap(petBitmap, new SKPoint(catPos.X, catPos.Y), new SKPaint());

            // Calculate the center position
            double centerX = (deviceCanvasWidth - petBitmap.Width) / 2;
            double centerY = (deviceCanvasHeight - petBitmap.Height) / 2;
            Console.WriteLine($"XXXXXXXXXXX {centerX}:{centerY}");
        }


        // Name pet            
        public int bonusAmount = 50;
        [ObservableProperty]
        public bool isUpdatingName = false;        
        [ObservableProperty]
        public bool isNameButtonVisible = true;

        [RelayCommand]
        public async Task ChangeNameApi()
        {
            IsNameButtonVisible = false;
            IsUpdatingName = true;
            Console.WriteLine($"ABCBDBDBCBSB");

            if (IsFirstTimeNaming)
            {
                string result = await PetigotchiApi.UpdatePetigotchiName(NewPetName, User.UserId, PetId);
                Console.WriteLine($"XXXXXXXXXXXX {result}");
                IsUpdatingName = false;
                PetName = result;
                Profile.UpdateScoreByAmount(bonusAmount);
                CloseNamingMenu();
            }
            else
            {
                await PetigotchiApi.UpdatePetigotchiName(NewPetName, User.UserId, PetId);
                IsUpdatingName = false;
            }
        }


        // Navigate to highscores
        [RelayCommand]
        public async Task NavigateToHighscoresPage()
        {
            await Shell.Current.GoToAsync("///PetigotchiHighscoresPage");
        }

        // Open website
        [RelayCommand]
        public async Task OpenWebGamesPage()
        {
            // Logic to open myecoapp.org page
            string url = "https://www.mecoapp.org/games2";
            Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
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

        [RelayCommand]
        public async Task OpenNamingMenu()
        {
            IsRenamePetVisible = true;
        }

        [RelayCommand]
        public async Task CloseNamingMenu()
        {
            IsRenamePetVisible = false;
        }

        [RelayCommand]
        public async Task EatCheese()
        {
            Hunger = Math.Max(0, Hunger - 50);
        }

        [RelayCommand]
        public async Task EatTaco()
        {
            Hunger = Math.Max(0, Hunger - 10);
        }        
        
        [RelayCommand]
        public async Task PlayBallGames()
        {
            Happiness += 10;
        }

        [RelayCommand]
        public async Task PlayVideoGames()
        {
            Happiness += 50;
        }

        [RelayCommand]
        public async Task PlayCardGames()
        {
            Happiness += 75;
        }
    }
}
