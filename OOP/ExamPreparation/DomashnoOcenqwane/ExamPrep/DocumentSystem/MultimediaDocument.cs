using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public abstract class OfficeDocument : BinaryDocument
    {
        public string Version { get; protected set; }

        public override void LoadProperty(string key, string value) 
        {
            if (key == "version")
            {
                this.Version = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(
            IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("version", this.Version));
            base.SaveAllProperties(output);
        }
    
    }
}
