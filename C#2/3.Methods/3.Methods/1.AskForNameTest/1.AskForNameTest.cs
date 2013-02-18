using System;

namespace _1.AskForNameTest
{
	class AskForNameTest
	{
		/*Write a method that asks the user for his name and prints
		  “Hello, <name>” (for example, “Hello, Peter!”). Write a program to test this method.*/
		static void GetName()
		{
			Console.Write("What is your name?: ");
			string name = Console.ReadLine();
			Console.WriteLine("Hello, {0}!", name);
		}
		
		static void Main()
		{
			GetName();
		}
	}
}