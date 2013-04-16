using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Define a class InvalidRangeException<T> that holds information about 
  an error condition related to invalid range. It should hold error 
  message and a range definition [start … end].
	Write a sample application that demonstrates the 
  InvalidRangeException<int> and InvalidRangeException<DateTime> 
  by entering numbers in the range [1..100] and dates in the range [1.1.1980 … 31.12.2013].*/
namespace _03.InvalidRangeExeption
{
	public class InvalidRangeExeption<T> : Exception
	{
		//Fields with properties:
		public T Start { get; set; }
		public T End { get; set; }

		//Constructors:
		public InvalidRangeExeption(string message, T start, T end)
			: base(message)
		{
			this.Start = start;
			this.End = end;
		}
	}
}
