using Microsoft.Extensions.DependencyInjection;

namespace MauiAppHotel;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var displayInfo = DeviceDisplay.MainDisplayInfo;

        var screenWidth = displayInfo.Width / displayInfo.Density;
        var screenHeight = displayInfo.Height / displayInfo.Density;

        return new Window(new AppShell())
        {
            IsMaximizable = false,
            IsMinimizable = false,
            Width = 400,
            Height = 600,
            X = (screenWidth - 400) / 2,
            Y = (screenHeight - 600) / 2
        };
    }
}