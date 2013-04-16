using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*A bank holds different types of accounts for its customers: deposit accounts,
  loan accounts and mortgage accounts. Customers could be individuals or companies.
  All accounts have customer, balance and interest rate (monthly based). Deposit
  accounts are allowed to deposit and with draw money. Loan and mortgage accounts 
  can only deposit money.
  
  All accounts can calculate their interest amount for a given period (in months).
  In the common case its is calculated as follows: number_of_months * interest_rate.
  Loan accounts have no interest for the first 3 months if are held by individuals
  and for the first 2 months if are held by a company.
  
  Deposit accounts have no interest if their balance is positive and less than 1000.
  Mortgage accounts have ½ interest for the first 12 months for companies and no
  interest for the first 6 months for individuals.
  
  Your task is to write a program to model the bank system by classes and interfaces.
  You should identify the classes, interfaces, base classes and abstract actions and 
  implement the calculation of the interest functionality through overridden methods.*/

	class TestingTheBankProgram
	{
		static void Main()
		{
			//Making customers - individual and company
			CompanyCustomer ood = new CompanyCustomer("OOD");
			IndividualCustomer samuel = new IndividualCustomer("Samuel L. Jackson");

			//Testing some stuff
			DepositAccount samuelDepositAccount = new DepositAccount(samuel , 10000m, 100m);
			DepositAccount oodDepositAccount = new DepositAccount(ood, 10000m, 100m);
			Console.WriteLine("{1} has {0} money.", samuelDepositAccount.Balance, samuelDepositAccount.Customer.Name);
			samuelDepositAccount.WithDrawMoney(500m);
			Console.WriteLine("After we with draw some money he has {0} money." , samuelDepositAccount.Balance);
			samuelDepositAccount.AddDeposit(200m);
			Console.WriteLine("After we deposit some money he has " + samuelDepositAccount.Balance);

			Console.WriteLine();
			Console.WriteLine();

			//Testing the deposit account
			Console.WriteLine("Testing the deposit account:");
			Console.WriteLine("----------------------------");
			Console.WriteLine("The {0} of {2} who is a {1} has interest amount for next 6 mounths: {3} "
			, samuelDepositAccount.GetType(), samuelDepositAccount.Customer.GetType(), samuelDepositAccount.Customer.Name, samuelDepositAccount.InterestAmountForPeriod(6));
			Console.WriteLine("The {0} of {2} who is a {1} has interest amount for next 6 mounths: {3} "
				, oodDepositAccount.GetType(), oodDepositAccount.Customer.GetType(), oodDepositAccount.Customer.Name, oodDepositAccount.InterestAmountForPeriod(6));
			Console.WriteLine();
			Console.WriteLine();

			//Testing the loan account
			Console.WriteLine("Testing the loan account:");
			Console.WriteLine("----------------------------");
			LoanAccount samuelLoanAccount = new LoanAccount(samuel, 10000m, 100m);
			Console.WriteLine("The {0} of {2} who is a {1} has interest amount for next 6 mounths: {3} "
				, samuelLoanAccount.GetType(), samuelLoanAccount.Customer.GetType(), samuelLoanAccount.Customer.Name, samuelLoanAccount.InterestAmountForPeriod(6));

			LoanAccount oodLoanAccount = new LoanAccount(ood, 10000m, 100m);
			Console.WriteLine("The {0} of {2} who is a {1} has interest amount for next 6 mounths: {3} "
				, oodLoanAccount.GetType(), oodLoanAccount.Customer.GetType(), oodLoanAccount.Customer.Name, oodLoanAccount.InterestAmountForPeriod(6));
			Console.WriteLine();
			Console.WriteLine();

			//Testing the mortage account
			Console.WriteLine("Testing the mortage account:");
			Console.WriteLine("----------------------------");
			MortageAccount samuelMortageAccount = new MortageAccount(samuel, 10000m, 100m);
			Console.WriteLine("The {0} of {2} who is a {1} has interest amount for next 24 mounths: {3} "
				, samuelMortageAccount.GetType(), samuelMortageAccount.Customer.GetType(), samuelMortageAccount.Customer.Name, samuelMortageAccount.InterestAmountForPeriod(24));
			MortageAccount oodMortageAccount = new MortageAccount(ood, 10000m, 100m);
			Console.WriteLine("The {0} of {2} who is a {1} has interest amount for next 24 mounths: {3} "
				, oodMortageAccount.GetType(), oodMortageAccount.Customer.GetType(), oodMortageAccount.Customer.Name, oodMortageAccount.InterestAmountForPeriod(24));
		}
	}

