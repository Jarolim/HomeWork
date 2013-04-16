using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class PDFDocument : EncryptableBinaryDocument
    {
        public int? NumberOfPages
        {
            get;
            set;
        }

        public PDFDocument(string name, string content = null, string size = null, int? pages = null)
            : base(name, content, size)
        {
            this.NumberOfPages = pages;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "pages")
            {
                this.NumberOfPages = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string,object>("pages", this.NumberOfPages.ToString()));
        }


    }

