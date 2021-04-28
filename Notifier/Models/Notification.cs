using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notifier.Models
{
    public class Notification
    {
        [Key]
        public int NotificationID { get; set;}
        public string OwnerID { get; set; }
        public string Reason {get; set;}
        [Display(Name = "Date Notified")]
        public DateTime CreationDate { get; set; }
        public int transactionID { get; set; }
        public bool IsRead {get; set;}
    }
}
