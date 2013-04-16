﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AudioDocument : MultimediaDocuments
{
    public int? SampleRateHz { get; set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "samplerate")
        {
            this.SampleRateHz = Int32.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }
    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        base.SaveAllProperties(output);
        output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRateHz));
    }
}

