using System.ComponentModel.DataAnnotations;

namespace SureBet.Models
{
    public class Plataforma
    {
        [Key]
        public int CodPlataforma { get; set; }

        [Display(Name ="Nombre Plataforma")]
        public string ?NombPlataforma { get; set; }
    }
}
