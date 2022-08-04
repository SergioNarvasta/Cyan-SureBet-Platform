using System.ComponentModel.DataAnnotations;

namespace SureBet.Entities
{
    public class Plataforma
    {
        [Key]
        public int CodPlataforma { get; set; }

        [Display(Name ="Nombre Plataforma")]
        public string ?NombrePlataforma { get; set; }
        [Display(Name = "Limite Plataforma")]
        public Double Limite { get; set; }

        [Display(Name = "URL Acceso")]
        public string ?Url    { get; set; }
    }
}
