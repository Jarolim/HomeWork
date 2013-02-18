using System;

class FirTree
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		int jace = n;
		int kace = n;
		int lace = n;
		int mace = n;
		int pace = n;
		int qace = n;
		int race = n;
		//top without last 2 rows
		for (int i = 0; i < n - 2; i++)
		{
			for (int j = 0; j < jace-2; j++)
			{
				Console.Write(".");
			}
			jace--;	
			for (int k = 0; k < kace-(n-1); k++)
			{
				for (int l = 0; l < lace-n+1; l++)
				{
					Console.Write("*");
				}
				lace = lace + 2;	
			}
			for (int m = 0; m < mace - 2; m++)
			{
				Console.Write(".");
			}
			mace--;
			Console.WriteLine();
		}
		//penultimate row
		for (int p = 0; p < (pace-2)*2 + 1; p++)
		{
			Console.Write("*");
		}
		Console.WriteLine();
		//last row
		for (int q = 0; q < qace-2; q++)
		{
			Console.Write(".");			
		}
		Console.Write("*");
		for (int r = 0; r < race-2; r++)
		{
			Console.Write(".");
		}
		Console.WriteLine();
	}
}
