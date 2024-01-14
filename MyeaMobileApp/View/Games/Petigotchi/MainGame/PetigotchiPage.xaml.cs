using MyeaMobileApp.ViewModel.Games.Petigotchi.MainGame;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using System.Diagnostics;

namespace MyeaMobileApp.View.Games.Petigotchi.MainGame;

public partial class PetigotchiPage : ContentPage
{
	public PetigotchiPageViewModel ViewModel { get; set; }
    public PetigotchiPage(PetigotchiPageViewModel viewModel)
	{
        Console.WriteLine("CB1111111111111111111111111111");
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

        canvas.Clear(SKColors.Black);
        ViewModel.SetCanvas(canvas);

        ViewModel.UpdatePetPosition();
        ViewModel.DrawStartingAnimation();

        // Invalidate the canvas to cause a redraw
        // canvasView.InvalidateSurface();
        Console.WriteLine("CB333333333333333333333333");

    }
}