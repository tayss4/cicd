namespace Fiap.Web.Trafego.Models
{
    public class Cruzamento
    {
        public int CruzamentoId { get; set; }
        public string Rua1 { get; set; }
        public string Rua2 { get; set; }

        public Cruzamento()
        {
                
        }

        public Cruzamento(int cruzamentoId, string rua1, string rua2)
        {
            CruzamentoId = cruzamentoId;
            Rua1 = rua1;
            Rua2 = rua2;
        }
    }
}
