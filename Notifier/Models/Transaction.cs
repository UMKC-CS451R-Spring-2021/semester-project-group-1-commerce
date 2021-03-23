using System;
using System.ComponentModel.DataAnnotations;

namespace Notifier.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }

		// user ID from AspNetUser table.
    	public string OwnerID { get; set; }
		
        [DataType(DataType.Date)]
        public DateTime TransactionDate { get; set; }
		
        [DataType(DataType.Time)]
        public DateTime TransactionTime { get; set; }
		public string Location { get; set; }
        public decimal Balance { get; set; }
        public string DepositWithdrawl { get; set; }
        public decimal TransAmount { get; set; }
        public string Description { get; set; }
        
    }
}