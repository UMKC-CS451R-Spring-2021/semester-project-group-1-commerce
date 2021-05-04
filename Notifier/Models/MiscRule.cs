using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notifier.Models
{
    public class MiscRule
    {
        [Key]
        public int MiscRuleID { get; set; }

        // user ID from AspNetUser table.
        public string OwnerID { get; set; }
        [Display(Name = "Overdraft Notifications")]
        public bool wantOverdraft { get; set; }
        [Display(Name = "Deposit Notifications")]
        public bool wantAllDeposit { get; set; }
        [Display(Name = "Withdraw Notifications")]
        public bool wantAllWithdraw { get; set; }
    }
}
