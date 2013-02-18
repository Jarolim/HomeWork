using System;

class Trapezoid
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		int face = n;
		int mace = n;
		for (int p = 0; p < n; p++)
		{
			Console.Write(".");
		}
		for (int p = 0; p < n; p++)
		{
			Console.Write("*");
		}
		Console.WriteLine();
		for (int i = 0; i < n-1; i++)
		{
			for (int j = 0; j < face-1; j=j+1)
			{
				Console.Write(".");
			}
			face--;
			Console.Write("*");
			for (int k = 0; k < mace-1; k++)
			{
				
				Console.Write(".");
			}
			mace++;
			Console.Write("*");
			Console.WriteLine();
		}
		for (int s = 0; s < 2*n; s++)
		{
			Console.Write("*");
		}
		Console.WriteLine();
	}
}

