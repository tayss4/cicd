using System.ComponentModel.DataAnnotations;

namespace Fiap.Web.Trafego.ViewModel
{
    public class CruzamentoCreateViewModel
    {
        [Display(Name = "Cruzamento ID")]
        public int CruzamentoId { get; set; }

        [Required(ErrorMessage = "Rua 1 é obrigatória.")]
        [Display(Name = "Rua 1")]
        [StringLength(50, ErrorMessage = "O nome da rua não pode exceder 50 caracteres.")]
        public string Rua1 { get; set; }

        [Required(ErrorMessage = "Rua 2 é obrigatória.")]
        [Display(Name = "Rua 2")]
        [StringLength(50, ErrorMessage = "O nome da rua não pode exceder 50 caracteres.")]
        public string Rua2 { get; set; }
    }
}
