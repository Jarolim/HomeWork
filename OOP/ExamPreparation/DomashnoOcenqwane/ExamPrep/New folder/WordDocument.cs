using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class WordDocument : OfficeDocument, IEditable
    {
        public int? NumberOfCharacters
        {
            get;
            set;
        }

        public WordDocument(string name, string content = null, string size = null, string version = null, int? chars = null)
            : base(name, content, size, version)
        {
            this.NumberOfCharacters = chars;
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "chars")
            {
                this.NumberOfCharacters = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("chars", this.NumberOfCharacters.ToString()));
            base.SaveAllProperties(output);
        }

        
    }

