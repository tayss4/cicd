using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.Trafego.ViewModel
{
    public class PrevisaoCreateViewModel
    {
        [Display(Name = "Previsão ID")]
        public int PrevisaoId { get; set; }

        [DataType(DataType.Date)]
        public DateTime Hora { get; set; }

        [StringLength(50, ErrorMessage = "Máximo de 100 caracteres.")]
        [Display(Name = "Melhor Alternativa")]
        public string MelhorAlternativa { get; set; }

        [Required(ErrorMessage = "O número de carros é obrigatório.")]
        [Display(Name = "Número de carros")]
        public int NumeroCarros { get; set; }

        [Required(ErrorMessage = "Cruzamento ID é obrigatório.")]
        [Display(Name = "Cruzamento ID")]
        [Range(1, int.MaxValue, ErrorMessage = "O Cruzamento selecionado é inválido.")]
        public int CruzamentoId { get; set; }

        [Display(Name = "Cruzamentos")]
        public SelectList Cruzamentos { get; set; }

        public PrevisaoCreateViewModel() 
        { 
            Cruzamentos = new SelectList(Enumerable.Empty<SelectListItem>());   
        }    
    }
}
