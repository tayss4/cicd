namespace Fiap.Web.Trafego.Models
{
    public class Previsao
    {
        public int PrevisaoId { get; set; }
        public DateTime Hora{ get; set; }
        public string MelhorAlternativa { get; set; }
        public int NumeroCarros { get; set; }
        public int CruzamentoId { get; set; }
        public Cruzamento? Cruzamento { get; set; }
        public Previsao()
        {
                
        }

        public Previsao(int previsaoId, DateTime hora, string melhorAlternativa, int numeroCarros, int cruzamentoId, Cruzamento Cruzamento)
        {
            PrevisaoId = previsaoId;
            Hora = hora;
            MelhorAlternativa = melhorAlternativa;
            NumeroCarros = numeroCarros;
            CruzamentoId = cruzamentoId;
            Cruzamento = Cruzamento;
        }
    }
}
