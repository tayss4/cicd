using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.Trafego.ViewModel
{
    public class RegistroCreateViewModel
    {
        [Display(Name = "Registro ID")]
        public int RegistroId { get; set; }

        [DataType(DataType.Date)]
        public DateTime HoraAbertura { get; set; }

        [DataType(DataType.Date)]
        public DateTime HoraFechamento { get; set; }

        [Required(ErrorMessage = "O número de carros é obrigatório.")]
        [Display(Name = "Número de carros")]
        public int NumeroCarros { get; set; }

        [Required(ErrorMessage = "Cruzamento ID é obrigatório.")]
        [Display(Name = "Cruzamento ID")]
        [Range(1, int.MaxValue, ErrorMessage = "O Cruzamento selecionado é inválido.")]
        public int CruzamentoId { get; set; }

        [Display(Name = "Cruzamentos")]
        public SelectList Cruzamentos { get; set; }

        public RegistroCreateViewModel()
        {
            Cruzamentos = new SelectList(Enumerable.Empty<SelectListItem>());
        }
    }
}
