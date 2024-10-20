using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.Trafego.ViewModel
{
    public class HorarioPicoCreateViewModel
    {
        [Display(Name = "Horario de Pico ID")]
        public int HorarioPicoId { get; set; }

        [DataType(DataType.Date)]
        public DateTime HoraInicio { get; set; }

        [DataType(DataType.Date)]
        public DateTime HoraTermino { get; set; }

        [Required(ErrorMessage = "Cruzamento ID é obrigatório.")]
        [Display(Name = "Cruzamento ID")]
        [Range(1, int.MaxValue, ErrorMessage = "O Cruzamento selecionado é inválido.")]
        public int CruzamentoId { get; set; }

        [Display(Name = "Cruzamentos")]
        public SelectList Cruzamentos { get; set; }
        public HorarioPicoCreateViewModel()
        {
            Cruzamentos = new SelectList(Enumerable.Empty<SelectListItem>());
        }
    }
}
