
using System.ComponentModel.DataAnnotations;

namespace IS_SureBet.Models
{
    public class HouseBet
    {
        [Key]
        public int Id { get; set; }

        [Display(Name ="Nombre Plataforma")]
        public string  Name { get; set; }
        public string ? Description { get; set; }
        [Display(Name = "Limite Plataforma")]
        public double Limit { get; set; }

        [Display(Name = "URL Acceso")]
        public string Url    { get; set; }
        public string IsActive { get; set; }
    }
}
