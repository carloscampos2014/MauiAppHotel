namespace MauiAppHotel.Models;

public class HospedagemModel
{
    public QuartoModel QuartoSelecionado { get; set; } = new QuartoModel();

    public int QtdAdultos { get; set; }

    public int QtdCriancas { get; set; }

    public DateTime DataCheckin { get; set; }

    public DateTime DataCheckout { get; set; }

    public int Estadia => DataCheckout.Subtract(DataCheckin).Days;

    public double ValorTotal
    {
        get
        {
            double valorAdultos = QtdAdultos * QuartoSelecionado.ValorDiariaAdulto;
            double valorCriancas = QtdCriancas * QuartoSelecionado.ValorDiariaCrianca; 

            double total = (valorAdultos + valorCriancas) * Estadia;

            return total;
        }
    }
}
