using System.Diagnostics;

namespace MyeaMobileApp.Controls.Social;

public partial class SocialMediaCta : ContentView
{
	public SocialMediaCta()
	{
		InitializeComponent();
	}

    private void InstagramButton_Clicked(object sender, EventArgs e)
    {
        // Logic to open Instagram page
        string url = "https://www.instagram.com/myea";
        Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
    }

    private void FacebookButton_Clicked(object sender, EventArgs e)
    {
        // Logic to open Facebook page
        string url = "https://www.facebook.com/myea";
        Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
    }

    private void ThreadsButton_Clicked(object sender, EventArgs e)
    {
        // Logic to open Threads page
        string url = "https://threads.example.com";
        Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
    }

    private void YoutubeButton_Clicked(object sender, EventArgs e)
    {
        // Logic to open youtube page
        string url = "https://youtube.com/myea";
        Browser.OpenAsync(url, BrowserLaunchMode.SystemPreferred);
    }
}