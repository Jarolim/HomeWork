using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

	public abstract class BankAccount
	{
		//Fields:
		private Customer customer;
		private decimal balance;
		private decimal interestRate;

		//Properties:
		public Customer Customer
		{
			get
			{
				return this.customer;
			}
			set
			{
				this.customer = value;
			}
		}

		public decimal Balance
		{
			get
			{
				return this.balance;
			}
			set
			{
				this.balance = value;
			}
		}

		public decimal InterestRate
		{
			get
			{
				return this.interestRate;
			}
			set
			{
				this.interestRate = value;
			}
		}

		//Constructors:
		public BankAccount(Customer customer , decimal balance , decimal interestRate)
		{
			this.Customer= customer;
			this.Balance = balance;
			this.InterestRate = interestRate;
		}

		//Methods:
		public virtual decimal InterestAmountForPeriod(int months)
		{
			return (this.Balance * this.InterestRate) * months;
		}
	}

