namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
	private readonly App PropriedadesApp;

	public ContratacaoHospedagem()
	{
		InitializeComponent();
		PropriedadesApp = (App)Application.Current;
		pckQuarto.ItemsSource = PropriedadesApp.Quartos;
		dtpckCheckin.MinimumDate = DateTime.Now;
		dtpckCheckin.MaximumDate = DateTime.Now.AddMonths(1);
        dtpckCheckout.MinimumDate = dtpckCheckin.Date?.AddDays(1);
        dtpckCheckout.MaximumDate = dtpckCheckin.Date?.AddMonths(6);
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

    private async void dtpckCheckin_DateSelected(object sender, DateChangedEventArgs e)
    {
        try
        {
            DatePicker checkin = (DatePicker)sender;
            dtpckCheckout.MinimumDate = checkin.Date?.AddDays(1);
            dtpckCheckout.MaximumDate = checkin.Date?.AddMonths(6);
        }
        catch (Exception ex)
        {
            await DisplayAlertAsync("Ops...", $"Ocorreu um erro: {ex.Message}", "OK");
        }
    }
}