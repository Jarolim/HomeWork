﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public abstract class MultimediaDocuments : BinaryDocument
    {
        public int? Length { get; set; }

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
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("length", this.Length));
        }
    }

