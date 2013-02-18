using System;

class BankAccountAppropriateVariables
{
    static void Main()
    {
        /*A bank account has a holder name (first name, middle name and last name), available
          amount of money (balance), bank name, IBAN, BIC code and 3 credit card numbers 
          associated with the account. Declare the variables needed to keep the information
          for a single bank account using the appropriate data types and descriptive names.*/
        string holderName = "Stefan Stefanov Stefanov";       
        decimal balance = 3200000400.50M;; 
        string bankName = "UTL Bank";
        string iban = "BGUN32143423423423423423";
        string bicCode = "CBS212222";
        ulong firstCardNumber = 435444444444;
        ulong secondCardNumber = 322234455666;
        ulong thirdCardNumber = 4345343453453;
        Console.WriteLine("Holder's name: {0} \nBalance: {1} \nBank name: {2} \nIBAN: {3} \nBIC: {4} \nCard numbers: {5} ; {6} ; {7}"
            , holderName, balance, bankName, iban, bicCode, firstCardNumber, secondCardNumber, thirdCardNumber);
    }
}

