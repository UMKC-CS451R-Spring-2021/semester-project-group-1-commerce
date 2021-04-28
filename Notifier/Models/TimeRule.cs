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

        [Display(Name = "Timer Filter")]
        public TimeShare BeforeAfterTime { get; set; }

        [Display(Name = "Time")]
        [DataType(DataType.Time)]
        public DateTime TransactionTimeFilter { get; set; }
    }
    public enum TimeShare
    {
        Before = 1,
        After = 2,
        Same = 3
    }
}
