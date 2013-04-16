using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* Tasks 1 , 2 , 4 , 5 , 6 , 9 , 10 , 11 from the Homework*/
namespace MobilePhoneDevice
{
    public class GSM
    {
        // fields:
        private string model; //1
        private string manufacturer; //2
        private decimal? price; //3
        public string owner; //4
        public Battery battery; //5
        public Display display; //6
        
        //defining static field for IPhone 4S
        
        public static Battery iPhoneBattery = new Battery("LiIon" , 31.5 , 7.6); //8
        public static Display iPhoneDisplay = new Display(3.5 , 16000000); //9
        private static GSM iPhone4S = new GSM("IPhone4S" ,"Apple",999, "Jack Dexter",iPhoneBattery , iPhoneDisplay ); //7
        private List<Call> callHistory = new List<Call>(); //10

        // properties:
        public string Model //1
        {
            get
            {
                return this.model;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentException("Invalid Model!");
                }
                this.model = value;
            }
        }

        public string Manufacturer //2
        {
            get 
            {
                return this.manufacturer;
            }
            set 
            {
                if (value == null)
                {
                    throw new ArgumentException("Invalid Manufacturer!");
                }
                this.manufacturer = value;
            }
        }

        public decimal? Price //3
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Must be a positive number!");
                }
                try
                {
                    this.price = value;
                }
                catch (FormatException)
                {
                    throw new FormatException("Has to be a positive number!");
                }
                this.price = value;
            }
        }

        public string Owner //4
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }

        public Display Display //5
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
            }
        }

        public Battery CurrentBattery //6
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }

        public static GSM IPhone4S //7
        {
            get
            {
                return iPhone4S;
            }
            set 
            {
                iPhone4S = value;
            }
        }

        public static Battery IPhoneBattery //8
        {
            get
            {
                return iPhoneBattery;
            }
            set 
            {
                iPhoneBattery = value;
            }
        }

        public static Display IPhoneDisplay //9
        {
            get
            {
                return iPhoneDisplay;
            }
            set 
            {
                iPhoneDisplay = value;
            }
        }

        public List<Call> CallHistory //10
        {
            get 
            { 
                return this.callHistory; 
            }
            set 
            {
                this.callHistory = value;
            }
        }

        public string CallHistoryToString
        {
            get
            {
                StringBuilder callHistoryInfo = new StringBuilder();
                for (int i = 0; i < callHistory.Count; i++)
                {
                    callHistoryInfo.AppendLine(this.callHistory[i].ToString());
                }
                return callHistoryInfo.ToString();
            }
        }

        // TODO CallHistoryToString

        // constructors:

        public GSM(string model, string manufacturer)
            : this(model, manufacturer, null, null, null, null)
        {
            this.model = model;
            this.manufacturer = manufacturer;            
        }

        public GSM(string model, string manufacturer, decimal? price)
            : this(manufacturer, model, price, null, null, null)
        {
            this.model = model;
            this.manufacturer = manufacturer;        
            this.price = price;
        }

        public GSM(string model, string manufacturer, decimal? price, string owner)
            : this(manufacturer, model, price, owner, null, null)
        {
            this.model = model;
            this.manufacturer = manufacturer;     
            this.price = price;
            this.Owner = owner;
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, Battery battery)
            : this(manufacturer, model, price, owner, battery, null)
        {
            this.model = model;
            this.manufacturer = manufacturer;
            this.price = price;
            this.Owner = owner;
            this.battery = battery;
        }

        public GSM(string model, string manufacturer, decimal? price, string owner, Battery battery, Display display)
        {
            this.model = model;
            this.manufacturer = manufacturer;   
            this.price = price;
            this.Owner = owner;
            this.battery = battery;
            this.Display = display;
        }

        // methods:

        //method to add a call to the history
        public void AddCall(Call call)   
        {
            this.callHistory.Add(call);
        }

        //method to clear the call history
        public void ClearHistory()
        {
            this.callHistory.Clear();
        }

        //method to delete a call from the call history
        public void DeleteCall(Call call)
        {
            for (int i = 0; i < this.callHistory.Count; i++)
            {
                if (this.callHistory[i].DialedPhoneNumber == call.DialedPhoneNumber &&
                    this.callHistory[i].CallDateTime == call.CallDateTime &&
                    this.callHistory[i].Duritation == call.Duritation)
                {
                    this.callHistory.RemoveAt(i);
                }
            }
        }

        //method to calculate price for the calls:
        public double CalculatePrice(double pricePerMinute)
        {
            double totalPrice = 0;
            double talkedMinutes = 0;
            uint temp = 0; // variable that will help to round minutes;

            for (int i = 0; i < callHistory.Count; i++)
            {
                temp = this.callHistory[i].Duritation / 60;
                talkedMinutes = Convert.ToDouble(this.callHistory[i].Duritation) / 60;
                if (talkedMinutes > temp)
                {
                    talkedMinutes = temp + 1;
                }
                totalPrice += (talkedMinutes * pricePerMinute);
            }
            return totalPrice;
        }

        //method to override to string:
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine("****************");
            info.AppendLine("***Phone Info***");
            info.AppendLine("****************");
            info.AppendLine();
            info.AppendFormat("Model: {0}", this.Model.ToString()).AppendLine();
            info.AppendFormat("Manufacturer: {0}", this.manufacturer.ToString()).AppendLine();        
            info.AppendFormat("Price: {0}", this.Price.ToString()).AppendLine();
            info.AppendFormat("Owner: {0}", this.Owner.ToString()).AppendLine();
            if (this.battery != null)
            {
                info.AppendLine(this.battery.ToString());
            }
            if (this.Display != null)
            {
                info.AppendLine(this.Display.ToString());
            }
            return info.ToString();
        }
    }
}
