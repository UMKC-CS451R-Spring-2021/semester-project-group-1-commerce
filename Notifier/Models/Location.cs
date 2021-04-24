using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notifier.Models
{
    public class Location
    {
        [Key]
        public int LocationRuleID { get; set; }

        // user ID from AspNetUser table.
        public string OwnerID { get; set; }

        public string location { get; set; }
    }
}
