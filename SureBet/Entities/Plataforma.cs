using System.ComponentModel.DataAnnotations;

namespace SureBet.Entities
{
    public class Plataforma
    {
        [Key]
        public int CodPlataforma { get; set; }

        [Display(Name ="Nombre Plataforma")]
        public string ?NombrePlataforma { get; set; }

        public Double Limite { get; set; }

        public string ?url    { get; set; }
    }
}
