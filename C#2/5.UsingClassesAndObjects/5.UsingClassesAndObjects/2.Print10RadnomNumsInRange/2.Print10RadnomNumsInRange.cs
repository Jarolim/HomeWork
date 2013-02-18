using System;

class Print10RandomNumsInRange
{
	static void Main()
	{
		/*Write a program that generates and prints to the console 10 random values in the range [100, 200].*/
		Random random = new Random();
		for (int number = 1; number <= 10; number++)
		{
			int randomNumber = random.Next(100, 201);
			Console.Write("{0} ", randomNumber);
			Console.WriteLine();
		}
	}
}

