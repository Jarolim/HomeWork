using System;

class LeastMajorityMultiple
{
	static void Main()
	{
		byte a = byte.Parse(Console.ReadLine());
		byte b = byte.Parse(Console.ReadLine());
		byte c = byte.Parse(Console.ReadLine());
		byte d = byte.Parse(Console.ReadLine());
		byte e = byte.Parse(Console.ReadLine());
		byte face = 0;
		for (int i = 1; ; i++)
		{
			if (i % a == 0)
			{
				face++;
			}
			if (i % b == 0)
			{
				face++;
			}
			if (i % c == 0)
			{
				face++;
			}
			if (i % d == 0)
			{
				face++;
			}
			if (i % e == 0)
			{
				face++;
			}
			if (face >= 3)
			{
				Console.WriteLine(i);
				break;
			}
			face = 0;
		}
	}
}

