﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class TextDocument : Document, IEditable
    {
        public string Charset
        {
            get;
            set;
        }

        public TextDocument(string name, string content=null, string charset=null)
            :base(name, content)
        {
            this.Charset = charset;
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "charset")
            {
                this.Charset = value;
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("charset", this.Charset));
        }
    }

