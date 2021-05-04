using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notifier.Models
{
    public class AmountRule
    {
        [Key]
        public int AmountRuleID { get; set; }

        // user ID from AspNetUser table.
        public string OwnerID { get; set; }

        [Display(Name = "Deposit/Withdraw")]
        public DepoType DepoWith { get; set; }

        [Display(Name = "Greater/Lesser/Equal")]
        public NumComparator GreaterLess { get; set; }

        [Display(Name = "Amount")]

        [Column(TypeName = "decimal(18, 2)")]
        public decimal amountNotification { get; set; }
    }
    public enum NumComparator
    {
        Above = 1,
        Below = 2,
        Equals = 3
    }
}
