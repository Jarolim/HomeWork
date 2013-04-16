using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


	public class DepositAccount : BankAccount, IDepositable, IWithDrawable
	{
		//Constructors:
		public DepositAccount(Customer customer, decimal balance, decimal interestRate)
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

		public void WithDrawMoney(decimal drawMoney)
		{
			if (drawMoney < 0)
			{
				throw new ArgumentOutOfRangeException("You cannot draw a negative number of money!");
			}
			else
			{
				this.Balance -= drawMoney;
			}
		}

		public override decimal InterestAmountForPeriod(int months)
		{
			if (this.Balance <= 1000 && this.Balance >= 0)
			{
				return 0;
			}
			else
			{
				return (this.Balance * this.InterestRate) * months;
			}
		}
	}

