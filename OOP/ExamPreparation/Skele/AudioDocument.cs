using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class VideoDocument : MultimediaDocument
{
    public long? FrameRate { get; protected set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "frameRate")
        {
            this.FrameRate = long.Parse(value);
        }
        else
        {
            base.LoadProperty(key, value);
        }

    }

    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {


        output.Add(new KeyValuePair<string, object>("frameRate", this.FrameRate));
        base.SaveAllProperties(output);

    }
}

