using System.ComponentModel.DataAnnotations;

namespace SureBet.Models
{
    public class BetData
    {
        [Key]
       public int Id { get; set; }
       public string ?Deporte { get; set; }
       public string ?Evento { get; set; }
       
       public string ?Mercado { get; set; }

       public string ?Competicion { get; set; }

       public Double Cuota { get; set; }

       public Double Beneficio { get; set; }
       public string ?CasaApuesta   { get; set; }

       public DateTime Fecha { get; set; }

       public Double Limite { get; set; }

        
    }
}
