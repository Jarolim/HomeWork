using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Create a hierarchy Dog, Frog, Cat, Kitten, Tomcat and define useful constructors 
  and methods. Dogs, frogs and cats are Animals. All animals can produce sound 
  (specified by the ISound interface). Kittens and tomcats are cats. All animals 
  are described by age, name and sex. Kittens can be only female and tomcats can 
  be only male. Each animal produces a specific sound. Create arrays of different 
  kinds of animals and calculate the average age of each kind of animal using a 
  static method (you may use LINQ).*/
namespace _03.AnimalsHierarchy
{
	class TestAnimalHierarchy
	{
		static void Main(string[] args)
		{
			Cat[] cats =
            {
                new Cat(6,"Samuel Jackson","Male"),
                new Cat(5,"Gugenheim","Female"),
                new Cat(4,"Loreal","Male"),
				new Cat(3,"Dumbeldore","Male"),
				new Cat(2,"Shnizzel","Female"),
            };
			Console.WriteLine("The average age of the cats is: {0}", Animal.Average(cats));
			
			Dog[] dogs =
            {
                new Dog(7,"Rex","Male"),
                new Dog(8,"Jarolim","Male"),
                new Dog(9,"Roli","Male")
            };
			Console.WriteLine("The average age of the dogs is: {0}", Animal.Average(dogs));
			
			Frog[] frogs =
            {
                new Frog(1,"Clark","Male"),
                new Frog(1,"Crank","Male"),
                new Frog(1,"Dot","Male")
            };
			Console.WriteLine("The average age of the frogs is: {0}", Animal.Average(frogs));

			Console.WriteLine();
			Console.WriteLine();

			Console.WriteLine("Animals like to make sounds if they are hungry:");
			Console.WriteLine();
			cats[0].MakeSound();
			dogs[2].MakeSound();
			frogs[2].MakeSound();

			Console.WriteLine();
			Console.WriteLine();

			Console.WriteLine("Tom cats and Kittens too:");
			Console.WriteLine();
			TomCat tomCat = new TomCat(10, "TheGodfather");
			tomCat.MakeSound();
			Console.WriteLine("It is: " + tomCat.Sex);
			Kitten kitten = new Kitten(4, "Pebbles");
			kitten.MakeSound();
			Console.Write("It is: " + kitten.Sex);
			Console.WriteLine();
		}
	}
}
