using System;

class SandGlass
{
	static void Main()
	{
		int n = int.Parse(Console.ReadLine());
		int iace = n;
		int jace = n;
		int kace = n;
		int lace = n;
		int pace = n;
		int sace = n;
		int tace = n;
		int mace = n;
		int minusTop = 2;
		int minusBot = 3;
		int temp = 0;
		//min top half
		for (int i = 0; i < iace-minusTop; i++)
		{
			minusTop++;
			for (int j = 0; j < jace-(n-1); j++)
			{
				Console.Write(".");
			}
			jace++;
			
			for (int k = 0; k < kace - 2; k++)
			{
				Console.Write("*");
			}
			kace = kace - 2;
			
			for (int l = 0; l < lace - (n - 1); l++)
			{
				Console.Write(".");
			}
			lace++;
			Console.WriteLine();
		}
		//mid bottom half
		for (int p = 0; p < pace - minusBot; p++)
		{
			minusBot++;
			
			for (int s = 0; s < sace-(n-3); s++)
			{
				
				Console.Write(".");
			}
			sace--;
			
			

			for (int t = 0; t < tace-(n-3); t++)
			{
				Console.Write("*");
			}
			tace = tace + 2;
			for (int m = 0; m < mace-(n-1); m++)
			{
				Console.Write(".");
			}
			mace++;
			Console.WriteLine();
		}
	}
}