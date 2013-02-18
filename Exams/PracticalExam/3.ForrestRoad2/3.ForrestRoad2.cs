using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.ForrestRoad2
{
	class ForrestRoad2
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < 2*(n-1); i++)
			{
				if (i < n-1)
				{
					string dots = new string('.', i+1);
					string stars = new string('*', 1);
					Console.Write(dots);
					Console.Write(stars);
					string dodats = new string('.', ((n-2)-i));
					Console.Write(dodats);
					Console.WriteLine();	
				}
				if (i >= n-1)
				{
					string dots = new string('.', (n - i) + (2));
					string stars = new string('*', 1);
					string dodats = new string('.', i -3);
					Console.Write(dots);
					Console.Write(stars);
					Console.Write(dodats);
					Console.WriteLine();
				}
			}
		}
	}
}
