using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cyan.Domain.Common;

namespace Cyan.Domain.Entities
{
    public class BetHistory : Audit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BetHistoryId { get; set; }
        public string? Event { get; set; }
        public string? Market { get; set; } //Mercado
        public double Odds { get; set; } //Cuota
        public double BetAmount { get; set; } //Apuesta
        public double PayoutAmount { get; set; } //Pago
        public double Discount { get; set; }
        
        public bool IsWon { get; set; } //Ganado o Perdido

        public string? HouseBetName { get; set; } //Casa de Apuestas  FK
        public int? UserId { get; set; }   //FK 

        [NotMapped]
        public double PayoutFinal {  //Pago
            get{ 
                return this.IsWon ? this.PayoutAmount - this.BetAmount - this.Discount : 0 - this.BetAmount; 
            }  
        } 
    }
}
