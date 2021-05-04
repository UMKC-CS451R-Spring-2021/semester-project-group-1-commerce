using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notifier.Models
{
    public class TimeRule
    {
        [Key]
        public int TimeRuleID { get; set; }

        // user ID from AspNetUser table.
        public string OwnerID { get; set; }

        [Display(Name = "Starting at")]
        [DataType(DataType.Time)]
        public DateTime TransactionTimeFilterFrom { get; set; }

        [Display(Name = "Ending at")]
        [DataType(DataType.Time)]
        public DateTime TransactionTimeFilterUntil { get; set; }
    }
}
