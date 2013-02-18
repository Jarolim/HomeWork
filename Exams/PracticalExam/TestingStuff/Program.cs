using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandGlass
{
	class Program
	{
		static void Main(string[] args)
		{
			int n = int.Parse(Console.ReadLine());

			for (int i = 0; i < n; i++)
			{
				if (i <= n / 2)
				{
					string dots = new string('.', i);
					string stars = new string('*', n - 2 * i);
					Console.Write(dots);
					Console.Write(stars);
					Console.Write(dots);
					Console.WriteLine();
				}
				if (i > n / 2)
				{
					string dots = new string('.', n - (i + 1));
					string stars = new string('*', 2 * i - (n-2));
					Console.Write(dots);
					Console.Write(stars);
					Console.Write(dots);
					Console.WriteLine();
				}
			}
		}
	}
}

