using Microsoft.AspNetCore.Mvc.Rendering;

namespace Fiap.Web.Trafego.Models
{
    public class HorarioPico
    {
        public int HorarioPicoId { get; set; }
        public DateTime HoraInicio { get; set; }
        public DateTime HoraTermino { get; set; }
        public int CruzamentoId { get; set; }
        public Cruzamento? Cruzamento { get; set; }
        public HorarioPico()
        {
                
        }

        public HorarioPico(int horarioPicoId, DateTime horaInicio, DateTime horaTermino, int cruzamentoId, Cruzamento Cruzamento)
        {
            HorarioPicoId = horarioPicoId;
            HoraInicio = horaInicio;
            HoraTermino = horaTermino;
            CruzamentoId = cruzamentoId;
            Cruzamento = Cruzamento;
        }
    }
}
