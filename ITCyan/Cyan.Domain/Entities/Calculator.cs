using System.ComponentModel.DataAnnotations;

namespace IS_SureBet.Models
{
    public class Calculator
    {
        [Key]
        public int IdCalculator{ get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Nombre de Apuesta")]
        public string ?Descripcion { get; set; }

        [StringLength(20)]
        public double Cuota { get; set; }
        public double Probabilidad { get; set; }
        public double Apuesta { get; set; }
        [Display(Name = "Moneda de Transaccion")]
        public string ?Moneda { get; set; }
        public double Beneficio { get; set; }

    }
}
