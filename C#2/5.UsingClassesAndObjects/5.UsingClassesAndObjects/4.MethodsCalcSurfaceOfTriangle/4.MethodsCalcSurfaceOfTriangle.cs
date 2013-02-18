using System;

class MethodsCalcSurfaceOfTriangle
{
	/*Write methods that calculate the surface of a triangle by given:
		Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.*/
	static void SurfaceOfTriangle1(int a, int ha)
	{
		double s = a * ha / 2;
		Console.WriteLine("The surface of the triangle is {0}", s);
	}
	static void SurfaceOfTriangle2(int a, int b, int c)
	{
		double p = (a + b + c) / 2;
		double s = Math.Sqrt(p * (p - a) * (p - b) * (p - c));
		Console.WriteLine("The surface of the triangle is {0}", s);
	}
	static void SurfaceOfTriangle3(int a, int b, double c)
	{
		double angle = Math.PI * c / 180;
		double s = a * b * Math.Sin(angle) / 2;
		Console.WriteLine("The surface of the triangle is {0}", s);
	}

	static void Main()
	{
		Console.WriteLine("Type '1','2' or '3' for: \n 1-Side and an altitude to it \n 2-Three sides \n 3-Two sides and an angle between them");
		string choise = Console.ReadLine();
		if (choise == "1")
		{
			Console.WriteLine("Enter side:");
			int a = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter altitude:");
			int ha = int.Parse(Console.ReadLine());
			SurfaceOfTriangle1(a, ha);
		}
		else if (choise == "2")
		{
			Console.WriteLine("Enter first side:");
			int a = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter second side:");
			int b = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter third side:");
			int c = int.Parse(Console.ReadLine());
			SurfaceOfTriangle2(a, b, c);
		}
		else if (choise == "3")
		{
			Console.WriteLine("Enter first side:");
			int a = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter second side:");
			int b = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter angle between them:");
			double c = double.Parse(Console.ReadLine());
			SurfaceOfTriangle3(a, b, c);
		}
		else Console.WriteLine("Invalid input!");
	}
}


