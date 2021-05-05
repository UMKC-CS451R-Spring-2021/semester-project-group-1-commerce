﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Notifier.Models
{
    public class NotificationRule
    {
		[Key]
        public int RuleID { get; set; }

		// user ID from AspNetUser table.
		public string OwnerID { get; set; }

		[Display(Name = "Date Filter")]
		public TimeShare BeforeAfterDate { get; set; }

		[Display(Name = "Date")]
		[DataType(DataType.Date)]
		public DateTime TransactionDateFilter { get; set; }

		[Display(Name = "Timer Filter")]
		public TimeShare BeforeAfterTime { get; set; }

		[Display(Name = "Time")]
		[DataType(DataType.Time)]
		public DateTime TransactionTimeFilter { get; set; }

		[Display(Name = "Location")]
		public string LocationFilter { get; set; }

		[Display(Name = "Deposit/Withdrawl")]
		public DepoType DepositWithdrawlFilter { get; set; }

		[Display(Name = "Transaction Limiter")]
		public NumComparator MoreLessEqualTrans { get; set; }

		[Display(Name = "Transaction Amount")]
		[Column(TypeName = "decimal(18, 2)")]
		public decimal TransAmountFilter { get; set; }

		public string DescriptionFilter { get; set; }
	}
	public enum TimeShare
	{
		Before = 1,
		After = 2,
		Same = 3
	}

	public enum NumComparator
	{
		Above = 1,
		Below = 2,
		Equals = 3
	}
}
