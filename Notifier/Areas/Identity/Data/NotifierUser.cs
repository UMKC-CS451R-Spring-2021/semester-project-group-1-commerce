using System;
using Microsoft.AspNetCore.Identity;

namespace Notifier.Areas.Identity.Data
{
    public class NotifierUser : IdentityUser
    {
        [PersonalData]
        public string Name { get; set; }
        [PersonalData]
        public DateTime DOB { get; set; }
    }
}