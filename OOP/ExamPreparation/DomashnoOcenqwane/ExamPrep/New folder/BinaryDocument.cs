using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class BinaryDocument : Document
    {
        public string Size
        {
            get;
            protected set;
        }

        public BinaryDocument(string name, string content = null, string size = null)
            :base(name, content)
        {
            this.Size = size;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "size")
            {
                this.Size = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("size", this.Size));
        }
    }

