using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public abstract class MultimediaDocument : BinaryDocument
    {
        public int? Length
        {
            get;
            protected set;
        }

        public MultimediaDocument(string name, string content = null, string size = null, int? length = null)
            :base(name, content, size)
        {
            this.Length = length;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "length")
            {
                this.Length = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string,object>("length", this.Length.ToString()));
            base.SaveAllProperties(output);
        }
    }
