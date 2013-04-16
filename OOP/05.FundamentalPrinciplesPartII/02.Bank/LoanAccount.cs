using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


	public class LoanAccount : BankAccount, IDepositable
	{
		//Constructors:
		public LoanAccount(Customer customer, decimal balance, decimal interestRate)
			: base(customer, balance, interestRate)
		{ }

		//Methods:
		public void AddDeposit(decimal deposit)
		{
			if (deposit < 0)
			{
				throw new ArgumentOutOfRangeException("You cannot deposit a negative number of money!");
			}
			else
			{
				this.Balance += deposit;
			}
		}

		public override decimal InterestAmountForPeriod(int months)
		{
			if (this.Customer.GetType().ToString() == "IndividualCustomer")
			{
				if (months <= 3)
				{
					return 0;
				}
				else
				{
					return (this.Balance * this.InterestRate) * (months - 3);
				}
			}
			else
			{
				if (months <=2)
				{
					return 0;
				}
				else
				{
					return (this.Balance * this.InterestRate) * (months-2);
				}
			}
		}
	}

