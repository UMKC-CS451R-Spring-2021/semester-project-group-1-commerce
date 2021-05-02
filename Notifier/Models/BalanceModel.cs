using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notifier.Models
{
    public class BalanceModel
    {
        [Key]
        public int BalanceID { get; set; }
        public string OwnerID { get; set; }

        [Column(TypeName = "decimal(18, 2)")]

        [Display(Name = "Initial Balance")]
        public decimal BalanceAmount { get; set; }
        public string OwnerName { get; set; }
    }
}
