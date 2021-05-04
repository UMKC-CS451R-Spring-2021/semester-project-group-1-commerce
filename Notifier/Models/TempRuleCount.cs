using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Notifier.Models
{
    public class TempRuleCount
    {
        [Key]
        public int RuleCountID { get; set; }
        public string RuleType { get; set; }
        public int TriggeredThisMonth { get; set; }
        public int TriggeredThisYear { get; set; }
        public int Unread { get; set; }
    }
}
