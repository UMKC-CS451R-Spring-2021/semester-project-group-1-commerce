using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notifier.Models
{
    public class NotificationRule
    {
		public int RuleID { get; set; }

		// user ID from AspNetUser table.
		public string OwnerID { get; set; }

		[Display(Name = "Date Filter")]
		public String BeforeAfterDate;

		[Display(Name = "Date")]
		[DataType(DataType.Date)]
		public DateTime TransactionDateFilter { get; set; }

		[Display(Name = "Timer Filter")]
		public String BeforeAfterTime;

		[Display(Name = "Time")]
		[DataType(DataType.Time)]
		public DateTime TransactionTimeFilter { get; set; }

		[Display(Name = "Location")]
		public string LocationFilter { get; set; }

		[Display(Name = "Deposit/Withdrawl")]
		public string DepositWithdrawlFilter { get; set; }

		[Display(Name = "Transaction Limiter")]
		public String MoreLessEqualTrans;

		[Display(Name = "Transaction Amount")]
		[Column(TypeName = "decimal(18, 2)")]
		public decimal TransAmountFilter { get; set; }

		public string DescriptionFilter { get; set; }
	}
}
