using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.AnimalsHierarchy
{
	public class Animal
	{
		//Fields:
		public int age;
		public string name;
		public string sex;

		//Properties:
		public int Age
		{
			get 
			{
				return this.age;
			}
			set 
			{
				this.age = value;
			}
		}

		public string Name
		{
			get
			{
				return this.name;
			}
			set
			{
				this.name = value;
			}
		}

		public string Sex
		{
			get
			{
				return this.sex;
			}
			set
			{
				this.sex = value;
			}
		}

		//Constructors:
		public Animal(int age , string name, string sex)
		{
			this.Age = age;
			this.Name = name;
			this.Sex = sex;
		}

		//Methods:
		public static double Average(Animal[] animalArray)
		{
			double sum = 0;
			for (int i = 0; i < animalArray.Length; i++)
			{
				sum = sum + animalArray[i].Age;
			}
			double sumOfSum = sum / animalArray.Length;
			return sumOfSum;
		}
	}
}
