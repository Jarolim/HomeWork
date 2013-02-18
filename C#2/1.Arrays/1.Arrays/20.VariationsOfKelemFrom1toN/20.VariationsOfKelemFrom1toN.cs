using System;

class VariationsOfKElem
{
	static void Main()
	{
		/*Write a program that reads two numbers N and K and generates all the variations of
		  K elements from the set [1..N]. Example:
	      N = 3, K = 2  {1, 1}, {1, 2}, {1, 3}, {2, 1}, {2, 2}, {2, 3}, {3, 1}, {3, 2}, {3, 3}*/
		int n = int.Parse(Console.ReadLine());
		int k = int.Parse(Console.ReadLine());

		for (int i = 0; i < Math.Pow(n, k); i++)
		{
			int conv = i;
			int[] num = new int[k];
			for (int j = 0; j < k; j++)
			{
				num[k - j - 1] = conv % n;
				conv = conv / n;
			}

			Console.Write("{0}{1}", '{', num[0] + 1);
			for (int j = 1; j < k; j++)
			{
				Console.Write(", {0}", num[j] + 1);
			}
			Console.WriteLine("}");
		}
	}
}

