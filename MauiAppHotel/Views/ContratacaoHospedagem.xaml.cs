namespace MauiAppHotel.Views;

public partial class ContratacaoHospedagem : ContentPage
{
	private readonly App PropriedadesApp;

	public ContratacaoHospedagem()
	{
		InitializeComponent();
		PropriedadesApp = (App)Application.Current;
		pckQuarto.ItemsSource = PropriedadesApp.Quartos;
        pckQuarto.SelectedIndex = 0;
        dtpckCheckin.MinimumDate = DateTime.Now;
		dtpckCheckin.MaximumDate = DateTime.Now.AddMonths(1);
        dtpckCheckout.MinimumDate = dtpckCheckin.Date?.AddDays(1);
        dtpckCheckout.MaximumDate = dtpckCheckin.Date?.AddMonths(6);
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			var hospedagem = new Models.HospedagemModel()
            {
                DataCheckin = dtpckCheckin.Date.Value,
                DataCheckout = dtpckCheckout.Date.Value,
                QtdAdultos = (int)stpAdultos.Value,
                QtdCriancas = (int)stpCriancas.Value,
                QuartoSelecionado = (Models.QuartoModel)pckQuarto.SelectedItem
            };

            await Navigation.PushAsync(new HospedagemContratada()
            {
                BindingContext = hospedagem,
            });
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