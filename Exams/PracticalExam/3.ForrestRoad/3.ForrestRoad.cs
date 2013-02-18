using System;

class ForrestRoad
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		int pace = n;
		int face = n;
		int mace = n;
		int bace = n;
		int gace = n;
		//top
		Console.Write("*");
		for (int i = 0; i < n-1; i++)
		{
			Console.Write(".");
		}
		Console.WriteLine();
		//top mid
		for (int i = 0; i < n-2; i++)
		{
			for (int j = 0; j < face-n; j++)
			{
				Console.Write(".");
			}
			face++;
			Console.Write(".");
			Console.Write("*");
			
			for (int k = 0; k < mace-2; k++)
			{
				Console.Write(".");
			}
			mace--;
			Console.WriteLine();
		}

		//bottom mid
		for (int i = 0; i < n-1; i++)
		{
			for (int j = 0; j < bace-1; j++)
			{
				Console.Write(".");
			}
			bace--;
			Console.Write("*");

			for (int l = 0; l < gace-n; l++)
			{
				Console.Write(".");
			}
			gace++;
			Console.WriteLine();
		}
		//bottom
		Console.Write("*");
		for (int i = 0; i < n-1; i++)
		{
			Console.Write(".");
		}
		Console.WriteLine();
	}
}

