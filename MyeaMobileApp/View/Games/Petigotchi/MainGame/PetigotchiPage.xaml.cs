using MyeaMobileApp.ViewModel.Games.Petigotchi.MainGame;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using System.Diagnostics;

namespace MyeaMobileApp.View.Games.Petigotchi.MainGame;

public partial class PetigotchiPage : ContentPage
{
	public PetigotchiPageViewModel ViewModel { get; set; }

    public bool SetCanvasFirst { get; set; } = false;

    public PetigotchiPage(PetigotchiPageViewModel viewModel)
	{
        Console.WriteLine("CCCCCCCCCCCCCBBBBBBBBBBBBBBBBB111111111111111111111111111111111");
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}

    private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
    {
        Console.WriteLine("CCCCCCCCCBBBBBBB2222222222222222222222222222222222222222");

        SKImageInfo info = e.Info;
        SKSurface surface = e.Surface;
        var canvas = surface.Canvas; // Assign the canvas to the property

        canvasView.IgnorePixelScaling = true;
        canvas.Clear(SKColors.White);

        // Set canvas in viewmodel - required
        ViewModel.GameLoop(canvas);

        // Invalidate the canvas to cause a redraw
        canvasView.InvalidateSurface();
        Console.WriteLine("CCCCCCCCCCCBBBBBBBBBBB333333333333333333333333333333333");
        Console.WriteLine("CB END");
        Console.WriteLine("");
        Console.WriteLine("");
    }
}