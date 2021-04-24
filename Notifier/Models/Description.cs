using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notifier.Models
{
    public class Description
    {
        [Key]
        public int DescriptionRuleID { get; set; }

        // user ID from AspNetUser table.
        public string OwnerID { get; set; }

        public string description { get; set; }
    }
}
