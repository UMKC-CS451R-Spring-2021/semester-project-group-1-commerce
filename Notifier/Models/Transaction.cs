using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notifier.Models
{
    public class Transaction
    {
		[Key]
        public int TransactionId { get; set; }

		// user ID from AspNetUser table.
    	public string OwnerID { get; set; }
		
		[Display(Name = "Date & Time")]
        public DateTime TransactionDate { get; set; }

		public DateTime TransactionTime { get; set; }

		public string Location { get; set; }
		
		[Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; set; }
		
		[Display(Name = "Deposit/Withdrawl")]
        public DepoType DepositWithdrawl { get; set; }
		
		[Display(Name = "Transaction Amount")]
		[Column(TypeName = "decimal(18, 2)")]
        public decimal TransAmount { get; set; }
		
        public string Description { get; set; }
        
    }
	public enum DepoType
	{
		[Display(Name = "Deposit")]
		Deposit = 1,

		[Display(Name = "Withdraw")]
		Withdraw = 2
	}
}