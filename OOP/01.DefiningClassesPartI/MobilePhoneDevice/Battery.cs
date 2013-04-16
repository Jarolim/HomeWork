using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneDevice
{
    public class Battery
    {
        // fields:
        public string model { get; set; }
        public double? idleHours { get; set; }
        public double? talkHours { get; set; }
        public BatteryType batteryType { get; set; }

        // properties:
        public string Model 
        {
            get 
            {
                return this.model;
            }
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Invalid battery model!");
                }
                this.model = value;
            }
        }

        public double? IdleHours
        {
            get
            {
                return this.idleHours;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Must be a positive number!");
                }
                this.idleHours = value;
            }
        }

        public double? TalkHours
        {
            get
            {
                return this.talkHours;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Must be a positive number!");
                }
                this.talkHours = value;
            }
        }

        // constructors:
        public Battery(string batteryKind): this( batteryKind , null, null)
        {
            this.model = batteryKind;
        }

        public Battery(string batteryKind, double? idleHours) : this(batteryKind, idleHours, null)
        {
            this.model = batteryKind;
            this.idleHours = idleHours;
        }

        public Battery(string batteryKind, double? idleHours, double? talkHours) 
        {
            this.model = batteryKind;
            this.talkHours = talkHours;
            this.idleHours = idleHours;
        }

        // methods:
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine("-----------------");
            info.AppendLine("=====Battery=====");
            info.AppendLine("-----------------");
            info.AppendLine();
            info.AppendFormat("Model: {0}", this.model.ToString()).AppendLine();
            info.AppendFormat("Idle Hours: {0}", this.idleHours.ToString()).AppendLine();
            info.AppendFormat("Talk Hours: {0}", this.talkHours.ToString()).AppendLine();
            return info.ToString();
        }
    }
}
