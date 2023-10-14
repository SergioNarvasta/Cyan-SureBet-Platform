using System.ComponentModel.DataAnnotations;

namespace IS_SureBet.Models
{
    public class BetData
    {
        [Key]
       public int IdBet { get; set; }
       public string ?Deporte { get; set; }

       public string ?Evento { get; set; }
       
       public string ?Mercado { get; set; }

       public string ?Competicion { get; set; }

       public double ?Cuota { get; set; }

       public double ?Beneficio { get; set; }

       public string ?CasaApuesta   { get; set; }

       public DateTime Fecha { get; set; }

       public double Limite { get; set; }

        
    }
}
