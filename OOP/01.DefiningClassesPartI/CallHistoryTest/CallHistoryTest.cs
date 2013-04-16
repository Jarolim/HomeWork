using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MobilePhoneDevice;
/* Task 12 : Write a class GSMCallHistoryTest to test the call history functionality of the GSM class.
        *Create an instance of the GSM class.
        *Add few calls.
        *Display the information about the calls.
        *Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
        *Remove the longest call from the history and calculate the total price again.
        *Finally clear the call history and print it.*/
namespace CallHistoryTest
{
    class CallHistoryTest
    {
        static void Main(string[] args)
        {
            //Create an instance of the GSM class.
            Battery phoneBattery = new Battery("NiCd", 30.6, 5.6);
            Display phoneDisplay = new Display(5.0, 16000000);
            GSM phone = new GSM("Galaxy Note", "Samsung", 866, "Goran Bregovic", phoneBattery, phoneDisplay);

            //Add few calls.
            DateTime dateAndTime = new DateTime(2013, 3, 5, 11, 59, 59);
            Call callOne = new Call(dateAndTime, "0888455455", 110);
            Call callTwo = new Call(dateAndTime, "0899455455", 50);
            Call callThree = new Call(dateAndTime, "0886455455", 230);

            phone.AddCall(callOne);
            phone.AddCall(callTwo);
            phone.AddCall(callThree);
            //Display the information about the calls.
            //Assuming that the price per minute is 0.37 calculate and print the total price of the calls in the history.
            Console.WriteLine(phone.CallHistoryToString);
            double price = phone.CalculatePrice(0.37);
            Console.WriteLine("The price for the whole history is {0}", price);

            //Remove the longest call from the history and calculate the total price again.
            uint maxDuritation = uint.MinValue;
            Call callToRemove = new Call(dateAndTime, "0886455455", 0);
            for (int i = 0; i < phone.CallHistory.Count; i++)
            {
                if (phone.CallHistory[i].Duritation > maxDuritation)
                {
                    maxDuritation = phone.CallHistory[i].Duritation;
                    callToRemove = phone.CallHistory[i];
                }
            }
            phone.DeleteCall(callToRemove);
            price = phone.CalculatePrice(0.37);
            Console.WriteLine("The new price after we removed the longest call is {0}", price);

            //Finally clear the call history and print it.
            Console.WriteLine();
            Console.WriteLine("Clearing History...");
            phone.ClearHistory();
            Console.WriteLine("Call History: {0}", phone.CallHistoryToString);
        }
    }
}
