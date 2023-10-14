using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITCyan.Cyan.Domain
{
    public class SureBet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
