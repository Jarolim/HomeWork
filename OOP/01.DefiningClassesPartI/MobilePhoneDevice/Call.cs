using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Task 8 : Create a class Call to hold a call performed through a GSM. 
  It should contain date, time, dialed phone number and duration (in seconds).*/
namespace MobilePhoneDevice
{
    
    public class Call
    {
        // fields:
        private DateTime callDateTime = new DateTime();
        private string dialedPhoneNumber;
        private uint duritation;

        // properties:
        public DateTime CallDateTime
        {
            get 
            {
                return this.callDateTime;
            }
            set 
            {
                this.callDateTime = value;
            }
        }

        public string DialedPhoneNumber
        {
            get 
            {
                return this.dialedPhoneNumber;
            }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid phone number!");
                }
                this.dialedPhoneNumber = value;
            }
        }

        public uint Duritation
        {
            get 
            { 
                return this.duritation; 
            }
            set 
            { 
               this.duritation = value; 
            }
        }

        // constructors:

        public Call(DateTime callDateTime, string dialedPhoneNumber, uint duritation)
        {
            this.CallDateTime = callDateTime;
            this.DialedPhoneNumber = dialedPhoneNumber;
            this.Duritation = duritation;
        }
        
        // methods:

        public override string ToString()
        {
            StringBuilder callInfo = new StringBuilder();
            callInfo.AppendFormat("Date and Time: {0}", this.callDateTime.ToString()).AppendLine();
            callInfo.AppendFormat("Number: {0}", this.dialedPhoneNumber.ToString()).AppendLine();
            callInfo.AppendFormat("Duration: {0}", this.duritation.ToString()).AppendLine();
            return callInfo.ToString();
        }
    }
}
