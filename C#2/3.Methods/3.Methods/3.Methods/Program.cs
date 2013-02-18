using System;

namespace _3.Methods
{
	class Program
	{
		static void Main()
		{
			GetName();
		}

		static void GetName()
		{
			Console.WriteLine("What is your name?");
			string name = Console.ReadLine();
			Console.WriteLine("Hello, {0}!", name);
		}
	}
}
