using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class PDFDocument : EncryptableDocuments
    {
        public int? PagesCount { get; set; }

        public override void LoadProperty(string key, string value)
        {
            if (key == "pages")
            {
                this.PagesCount = Int32.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("pages", this.PagesCount));
        }
    }

