using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class AudioDocument : MultimediaDocument
{
    public long? SampleRate { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "sampleRate")
        {
            this.SampleRate = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }

    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {


        output.Add(new KeyValuePair<string, object>("sampleRate", this.SampleRate));
        base.SaveAllProperties(output);

    }
}

