using System;

class ConvertIntoWords0to999
{
    static void Main()
    {
        /*Write a program that converts a number in the range [0...999] to a text corresponding to its English pronunciation. Examples:
	        0  "Zero"
	        273  "Two hundred seventy three"
	        400  "Four hundred"
	        501  "Five hundred and one"
	        711  "Severn hundred and eleven"*/
        Console.Write("Please enter a number in the range [0...999]: ");
        int number = int.Parse(Console.ReadLine());

        byte digitOne;
        byte digitTwo;
        byte digitThree;

        if (number >= 100 && number < 1000)
        {
            digitOne = (byte)(number / 100);
            digitTwo = (byte)((number % 100) / 10);
            digitThree = (byte)(number % 10);
            if (digitThree != 0 || digitTwo != 0)
            {
                switch (digitOne)
                {
                    case 1:
                        Console.Write("One hundred ");
                        break;
                    case 2:
                        Console.Write("Two hundred ");
                        break;
                    case 3:
                        Console.Write("Three hundred ");
                        break;
                    case 4:
                        Console.Write("Four hundred ");
                        break;
                    case 5:
                        Console.Write("Five hundred ");
                        break;
                    case 6:
                        Console.Write("Six hundred ");
                        break;
                    case 7:
                        Console.Write("Seven hundred ");
                        break;
                    case 8:
                        Console.Write("Eight hundred ");
                        break;
                    case 9:
                        Console.Write("Nine hundred ");
                        break;
                }
            }
            if (digitTwo == 0 && digitThree != 0)
            {
                switch (digitThree)
                {
                    case 1:
                        Console.WriteLine("and one");
                        break;
                    case 2:
                        Console.WriteLine("and two");
                        break;
                    case 3:
                        Console.WriteLine("and three");
                        break;
                    case 4:
                        Console.WriteLine("and four");
                        break;
                    case 5:
                        Console.WriteLine("and five");
                        break;
                    case 6:
                        Console.WriteLine("and six");
                        break;
                    case 7:
                        Console.WriteLine("and seven");
                        break;
                    case 8:
                        Console.WriteLine("and eight");
                        break;
                    case 9:
                        Console.WriteLine("and nine");
                        break;
                }
            }
            if (digitTwo == 1)
            {
                switch (digitThree)
                {
                    case 1:
                        Console.WriteLine("and eleven");
                        break;
                    case 2:
                        Console.WriteLine("and twelve");
                        break;
                    case 3:
                        Console.WriteLine("and thirteen");
                        break;
                    case 4:
                        Console.WriteLine("and fourteen");
                        break;
                    case 5:
                        Console.WriteLine("and fifteen");
                        break;
                    case 6:
                        Console.WriteLine("and sixteen");
                        break;
                    case 7:
                        Console.WriteLine("and seventeen");
                        break;
                    case 8:
                        Console.WriteLine("and sighteen");
                        break;
                    case 9:
                        Console.WriteLine("and nineteen");
                        break;
                }
            }
            if (digitTwo == 0 && digitThree == 0)
            {
                switch (digitOne)
                {
                    case 1:
                        Console.Write("One hundred ");
                        break;
                    case 2:
                        Console.Write("Two hundred ");
                        break;
                    case 3:
                        Console.Write("Three hundred ");
                        break;
                    case 4:
                        Console.Write("Four hundred ");
                        break;
                    case 5:
                        Console.Write("Five hundred ");
                        break;
                    case 6:
                        Console.Write("Six hundred ");
                        break;
                    case 7:
                        Console.Write("Seven hundred ");
                        break;
                    case 8:
                        Console.Write("Eight hundred ");
                        break;
                    case 9:
                        Console.Write("Nine hundred ");
                        break;
                }
            }
            if ((digitTwo > 1 && digitTwo <= 9) || digitTwo == 0)
            {
                switch (digitTwo)
                {
                    case 2:
                        Console.Write("and twenty ");
                        break;        
                    case 3:           
                        Console.Write("and thirty ");
                        break;         
                    case 4:            
                        Console.Write("and fourty ");
                        break;         
                    case 5:            
                        Console.Write("and fifty ");
                        break;         
                    case 6:            
                        Console.Write("and sixty ");
                        break;         
                    case 7:            
                        Console.Write("and seventy ");
                        break;         
                    case 8:            
                        Console.Write("and eighty ");
                        break;         
                    case 9:            
                        Console.Write("and ninety ");
                        break;
                    default:
                        break;
                }
                if (digitTwo != 0)
                {
                    switch (digitThree)
                    {
                        case 1:
                            Console.WriteLine("one");
                            break;
                        case 2:
                            Console.WriteLine("two");
                            break;
                        case 3:
                            Console.WriteLine("three");
                            break;
                        case 4:
                            Console.WriteLine("four");
                            break;
                        case 5:
                            Console.WriteLine("five");
                            break;
                        case 6:
                            Console.WriteLine("six");
                            break;
                        case 7:
                            Console.WriteLine("seven");
                            break;
                        case 8:
                            Console.WriteLine("eight");
                            break;
                        case 9:
                            Console.WriteLine("nine");
                            break;
                        default:
                            Console.WriteLine();
                            break;
                    }
                }
            }
        }
        if (number >= 10 && number < 100)
        {
            digitOne = (byte)(number / 10);
            digitTwo = (byte)(number % 10);
            if (digitOne == 1)
            {
                switch (digitTwo)
                {
                    case 0:
                        Console.WriteLine("Ten ");
                        break;
                    case 1:
                        Console.WriteLine("Eleven");
                        break;
                    case 2:
                        Console.WriteLine("Twelve");
                        break;
                    case 3:
                        Console.WriteLine("Thirteen");
                        break;
                    case 4:
                        Console.WriteLine("Fourteen");
                        break;
                    case 5:
                        Console.WriteLine("Fifteen");
                        break;
                    case 6:
                        Console.WriteLine("Sixteen");
                        break;
                    case 7:
                        Console.WriteLine("Seventeen");
                        break;
                    case 8:
                        Console.WriteLine("Eighteen");
                        break;
                    case 9:
                        Console.WriteLine("Nineteen");
                        break;
                }
            }
            if (digitOne > 1 && digitOne <= 9)
            {
                switch (digitOne)
                {
                    case 2:
                        Console.Write("Twenty ");
                        break;
                    case 3:
                        Console.Write("Thirty ");
                        break;
                    case 4:
                        Console.Write("Fourty ");
                        break;
                    case 5:
                        Console.Write("Fifty ");
                        break;
                    case 6:
                        Console.Write("Sixty ");
                        break;
                    case 7:
                        Console.Write("Seventy ");
                        break;
                    case 8:
                        Console.Write("Eighty ");
                        break;
                    case 9:
                        Console.Write("Ninety ");
                        break;
                }
                switch (digitTwo)
                {
                    case 1:
                        Console.WriteLine("One");
                        break;
                    case 2:
                        Console.WriteLine("Two");
                        break;
                    case 3:
                        Console.WriteLine("Three");
                        break;
                    case 4:
                        Console.WriteLine("Four");
                        break;
                    case 5:
                        Console.WriteLine("Five");
                        break;
                    case 6:
                        Console.WriteLine("Six");
                        break;
                    case 7:
                        Console.WriteLine("Seven");
                        break;
                    case 8:
                        Console.WriteLine("Eight");
                        break;
                    case 9:
                        Console.WriteLine("Nine");
                        break;
                    default:
                        Console.WriteLine();
                        break;
                }
            }
        }
        if (number >= 0 && number < 10)
        {
            switch (number)
            {
                case 0:
                    Console.WriteLine("Zero");
                    break;
                case 1:
                    Console.WriteLine("One");
                    break;
                case 2:
                    Console.WriteLine("Two");
                    break;
                case 3:
                    Console.WriteLine("Three");
                    break;
                case 4:
                    Console.WriteLine("Four");
                    break;
                case 5:
                    Console.WriteLine("Five");
                    break;
                case 6:
                    Console.WriteLine("Six");
                    break;
                case 7:
                    Console.WriteLine("Seven");
                    break;
                case 8:
                    Console.WriteLine("Eight");
                    break;
                case 9:
                    Console.WriteLine("Nine");
                    break;
            }
        }
    }
}

