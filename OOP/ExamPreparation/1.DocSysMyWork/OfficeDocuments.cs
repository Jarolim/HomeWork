﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public abstract class OfficeDocuments : EncryptableDocuments
    {
        public string Version { get; set; }

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

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("version", this.Version));
        }
    }
