using MyeaMobileApp.ViewModel.Games.Petigotchi;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using System.Diagnostics;

namespace MyeaMobileApp.View.Games.Petigotchi;

public partial class PetigotchiPage : ContentPage
{
	public PetigotchiPageViewModel ViewModel { get; set; }
    public PetigotchiPage(PetigotchiPageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = ViewModel = viewModel;
	}

    private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
    {
        Debug.WriteLine("OOOOOOOOOOOOOOOOOOOOOOO");
        Console.WriteLine("OOOOOOOOOOOOOOOOOOOOOOOO");

        SKImageInfo info = e.Info;
        SKSurface surface = e.Surface;
        var canvas = surface.Canvas; // Assign the canvas to the property
        canvasView.IgnorePixelScaling = true;

        canvas.Clear(SKColors.Black);
        ViewModel.SetCanvas(canvas);

        Debug.WriteLine("KKKKKKKKKKKKKKKKKKKKKKKKK");
        Console.WriteLine("KKKKKKKKKKKKKKKKKKKKKKKKK");

        ViewModel.DrawStartingAnimation();

        // Get the centre of the canvas
        float centreX = info.Rect.MidX;
        float centreY = info.Rect.MidY;
    }
}