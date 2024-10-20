using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Trafego.Models
{
    public class Registro
    {
        public int RegistroId { get; set; }
        public DateTime HoraAbertura { get; set; }
        public DateTime HoraFechamento { get; set; }
        public int NumeroCarros { get; set; }
        public int CruzamentoId { get; set; }
        public Cruzamento? Cruzamento { get; set; }
        public Registro()
        {
                
        }

        public Registro(int registroId, DateTime horaAbertura, DateTime horaFechamento, int numeroCarros, int cruzamentoId, Cruzamento Cruzamento)
        {
            RegistroId = registroId;
            HoraAbertura = horaAbertura;
            HoraFechamento = horaFechamento;
            NumeroCarros = numeroCarros;
            CruzamentoId = cruzamentoId;
            Cruzamento = Cruzamento;
        }
    }
}
