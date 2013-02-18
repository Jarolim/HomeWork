using System;

class InvalidNumber
{
	/*Write a program that reads an integer number and calculates and prints its square root. 
		If the number is invalid or negative, print "Invalid number". 
		In all cases finally print "Good bye". Use try-catch-finally.*/
	static void Main()
	{
		try
		{
			int n = int.Parse(Console.ReadLine());

			if (n < 0) throw new FormatException();

			Console.WriteLine(Math.Sqrt(n));
		}

		catch (ArgumentNullException)
		{
			Console.Error.WriteLine("Invalid number!");
		}

		catch (FormatException)
		{
			Console.Error.WriteLine("Invalid number!");
		}

		catch (OverflowException)
		{
			Console.Error.WriteLine("Invalid number!");
		}

		finally
		{
			Console.WriteLine("Good bye!");
		}
	}
}

