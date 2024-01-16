using MyeaMobileApp.ViewModel.Games.Snake;
using SkiaSharp;
using SkiaSharp.Views.Maui;

namespace MyeaMobileApp.View.Games.Snake;

public partial class SnakeGamePage : ContentPage
{
	public SnakeGamePageViewModel ViewModel { get; set; }
    public SnakeGamePage(SnakeGamePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}

    private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
    {
        Console.WriteLine("CB222222222222222222222222");

        SKImageInfo info = e.Info;
        SKSurface surface = e.Surface;
        var canvas = surface.Canvas; // Assign the canvas to the property
        canvasView.IgnorePixelScaling = true;

        canvas.Clear(SKColors.White);
    }
}