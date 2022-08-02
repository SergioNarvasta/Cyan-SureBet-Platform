using System.ComponentModel.DataAnnotations;

namespace SureBet.Entities
{
    public class Calculator
    {
        [Key]
        public int CodCalculator{ get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre de Apuesta")]
        public string ?Descripcion { get; set; }
        public Double Cuota { get; set; }
        public Double Probabilidad { get; set; }
        public Double Apuesta { get; set; }
        public string ?Moneda { get; set; }
        public Double Beneficio { get; set; }

    }
}
