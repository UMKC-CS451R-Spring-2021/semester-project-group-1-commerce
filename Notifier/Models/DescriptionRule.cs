using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notifier.Models
{
    public class DescriptionRule
    {
        [Key]
        public int DescriptionRuleID { get; set; }

        // user ID from AspNetUser table.
        public string OwnerID { get; set; }

        public string descriptionNotification { get; set; }
    }
}
