using System.ComponentModel.DataAnnotations;

namespace SureBet.Models
{
    public class BetData
    {
        [Key]
       public int Id { get; set; }
       public string ?Descripcion { get; set; }
        
    }
}
