using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.FirTree2
{
	class FirTree2
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				if (i < n-1)
				{
					string dots = new string('.', (n - 2) - i);
					string stars = new string('*', 1 + i * 2);
					Console.Write(dots);
					Console.Write(stars);
					Console.Write(dots);
					Console.WriteLine();
				}
				if (i == n-1)
				{
					string dots = new string('.', (n - 2));
					string stars = new string('*' , 1);
					Console.Write(dots);
					Console.Write(stars);
					Console.Write(dots);
					Console.WriteLine();
				}
			}	
		}
	}
}
