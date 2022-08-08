using System.ComponentModel.DataAnnotations;

namespace IS_SureBet.Models
{
    public class Plataforma
    {
        [Key]
        public int IdPlataforma { get; set; }

        [Display(Name ="Nombre Plataforma")]
        public string ?NombrePlataforma { get; set; }
        [Display(Name = "Limite Plataforma")]
        public double Limite { get; set; }

        [Display(Name = "URL Acceso")]
        public string ?Url    { get; set; }
    }
}
