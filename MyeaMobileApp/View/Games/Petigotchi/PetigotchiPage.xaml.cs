using MyeaMobileApp.ViewModel.Games.Petigotchi;
using SkiaSharp;
using SkiaSharp.Views.Maui;

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
        SKSurface surface = e.Surface;
        var canvas = surface.Canvas; // Assign the canvas to the property
        canvasView.IgnorePixelScaling = true;

        canvas.Clear();
        ViewModel.SetCanvas(canvas);
    }
}