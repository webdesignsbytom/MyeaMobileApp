namespace MyeaMobileApp.Controls.Sponsor;

public partial class SponsorAdvertFrame : ContentView
{
    public static readonly BindableProperty SponsorNameProperty = BindableProperty.Create(
        nameof(SponsorName),
        typeof(string),
        typeof(SponsorAdvertFrame),
        default(string),
        propertyChanged: OnSponsorNameChanged);

    public string SponsorName
    {
        get => (string)GetValue(SponsorNameProperty);
        set => SetValue(SponsorNameProperty, value);
    }

    public SponsorAdvertFrame()
    {
        InitializeComponent();
    }

    private static void OnSponsorNameChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (SponsorAdvertFrame)bindable;
        if (control.SponsorLabel != null)
        {
            control.SponsorLabel.Text = $"Sponsored by {(string)newValue}";
        }
    }

}