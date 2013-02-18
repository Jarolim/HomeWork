using System;

class SolverForQuadraticEquation
{
    static void Main()
    {
        /*Write a program that enters the coefficients a, b and c of a quadratic equation
       a*x2 + b*x + c = 0*/
        Console.WriteLine("We are going to solve the equation ax^2 + bx + c = 0");
        double a, b, c, x1, x2, discriminant;
        Console.Write("Pleace enter 'a' : ");
        a = double.Parse(Console.ReadLine());
        Console.Write("Pleace enter 'b' : ");
        b = double.Parse(Console.ReadLine());
        Console.Write("Pleace enter 'c' : ");
        c = double.Parse(Console.ReadLine());
        if (a == 0)
        {
            Console.WriteLine("This is not a quadratic equation");
        }
        else
        {
            discriminant = (b * b) - (4 * a * c);
            if (discriminant < 0)
            {
                Console.WriteLine("Your quadratic equation doesn't have real roots, because the discriminant is {0} ", discriminant);
            }
            else if (discriminant == 0)
            {
                x1 = -(b / (2 * a));
                Console.WriteLine("Discriminant is 0, and root 'x1'='x2'={0} ", x1);
            }
            else if (discriminant > 0)
            {
                x1 = (-b + Math.Sqrt(discriminant)) / 2 * a;
                x2 = (-b - Math.Sqrt(discriminant)) / 2 * a;
                Console.WriteLine("Root 'x1' is : {0}", x1);
                Console.WriteLine("Root 'x2' is : {0}", x2);
            }
        }
    }
}

