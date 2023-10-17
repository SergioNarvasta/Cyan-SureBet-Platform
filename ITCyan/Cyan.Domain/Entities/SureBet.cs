using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITCyan.Cyan.Domain
{
    public class SureBet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
       public string ?Sport { get; set; }

       public string ?Event { get; set; }
       
       public string Market { get; set; }

       public string  Competition { get; set; }

       public double Beneficio { get; set; }

       public string ? HouseBet   { get; set; }

       public DateTime EventaDate { get; set; }

       public double LimitAmount { get; set; }

        
    }
}
