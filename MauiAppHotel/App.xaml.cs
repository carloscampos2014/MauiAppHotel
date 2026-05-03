using MauiAppHotel.Models;

namespace MauiAppHotel;

public partial class App : Application
{
    public List<QuartoModel> Quartos { get; set; } = new List<QuartoModel>()
    {
        new QuartoModel { Descricao = "Suite Super Luxo", ValorDiariaAdulto = 110.0, ValorDiariaCrianca = 55.0 },
        new QuartoModel { Descricao = "Suite Luxo", ValorDiariaAdulto = 80, ValorDiariaCrianca = 40 },
        new QuartoModel { Descricao = "Suite Single", ValorDiariaAdulto = 50, ValorDiariaCrianca = 25 },
        new QuartoModel { Descricao = "Suite Crise", ValorDiariaAdulto = 25, ValorDiariaCrianca = 12.5 },
    };

    public App()
    {
        InitializeComponent();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var displayInfo = DeviceDisplay.MainDisplayInfo;

        var screenWidth = displayInfo.Width / displayInfo.Density;
        var screenHeight = displayInfo.Height / displayInfo.Density;

        return new Window(new NavigationPage(new Views.ContratacaoHospedagem()))
        {
            IsMaximizable = false,
            IsMinimizable = false,
            Width = 400,
            Height = 600,
            Title = "Hotel App",
            X = (screenWidth - 400) / 2,
            Y = (screenHeight - 600) / 2
        };
    }
}