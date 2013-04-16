using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class ExcelDocument : OfficeDocument
    {
        public int? Rows
        {
            get;
            set;
        }

        public int? Cols
        {
            get;
            set;
        }

        public ExcelDocument(string name, string content = null, string size = null, string version = null, int? rows = null, int? cols = null)
            : base(name, content, size, version)
        {
            this.Rows = rows;
            this.Cols = cols;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "rows")
            {
                this.Rows = int.Parse(value);
            }
            else if (key == "cols")
            {
                this.Cols = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("rows", this.Rows.ToString()));
            output.Add(new KeyValuePair<string, object>("cols", this.Cols.ToString()));
            base.SaveAllProperties(output);
        }
    }
