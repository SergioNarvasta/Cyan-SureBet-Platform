using System.ComponentModel.DataAnnotations;

namespace SureBet.Models
{
    public class ApuestaPrincipal
    {
        [Key]
        public int CodApuestaPr { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre de Apuesta")]
        public string ?Descripcion { get; set; }

    }
}
