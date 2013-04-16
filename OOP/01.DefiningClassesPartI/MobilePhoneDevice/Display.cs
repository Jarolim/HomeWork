using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobilePhoneDevice
{
    public class Display
    {
        // fields:
        public double? Size { get; set; }
        public double? ColorCount { get; set; }

        // constructors:
        public Display(double? size) : this (size , null)
        {
            this.Size = size;
        }

        public Display(double? size, double? colorCount)
        {
            this.Size = size;
            this.ColorCount = colorCount;
        }
        
        // methods:
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine("-----------------");
            info.AppendLine("=====Display=====");
            info.AppendLine("-----------------");
            info.AppendLine();
            info.AppendFormat("Size: {0}", this.Size.ToString()).AppendLine();
            info.AppendFormat("Colors: {0}", this.ColorCount.ToString()).AppendLine();
            return info.ToString();
        }
    }
}
