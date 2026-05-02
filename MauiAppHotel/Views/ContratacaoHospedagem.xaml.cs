namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
	public ContratacaoHospedagem()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			await Navigation.PushAsync(new HospedagemContratada());
		}
		catch (Exception ex)
		{
			await DisplayAlertAsync("Ops...", $"Ocorreu um erro: {ex.Message}", "OK");
        }
    }
}