using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Task 7: Write a class GSMTest to test the GSM class:
        *Create an array of few instances of the GSM class.
        *Display the information about the GSMs in the array.
        *Display the information about the static property IPhone4S.*/
namespace MobilePhoneDevice
{
    class GSMTest
    {
        static void Main(string[] args)
        {
            //Create an array of few instances of the GSM class.
            GSM[] gsmArray = new GSM[3];
            Display display = new Display(4.8, 16000000);
            Battery battery = new Battery("NiMH", 30.7, 6.7);
            battery.batteryType = BatteryType.NiMH;

            //initialize the phones
            gsmArray[0] = new GSM("Galaxy SIII", "Samsung", 870, "Samuel L. Jackson", battery, display);
            gsmArray[1] = new GSM("Milestone 2", "Motorola", 300, "Garry Barlow", battery, display);
            gsmArray[2] = new GSM("Sony", "Xperia 8", 220, "Zigs Gugenheim", battery, display);

            //Display the information about the GSMs in the array.
            for (int i = 0; i < gsmArray.Length; i++)
            {
                Console.WriteLine(gsmArray[i]);
            }

            //Display the information about the static property IPhone4S
            Console.WriteLine(GSM.IPhone4S);          
        }
    }
}
