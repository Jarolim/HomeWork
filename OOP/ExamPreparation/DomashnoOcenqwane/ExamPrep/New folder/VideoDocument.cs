using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class VideoDocument : MultimediaDocument
    {
        public int? FrameRate
        {
            get;
            set;
        }

        public VideoDocument(string name, string content = null, string size = null, int? length = null, int? framerate = null)
            : base(name, content, size, length)
        {
            this.FrameRate = framerate;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "framerate")
            {
                this.FrameRate = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("framerate", this.FrameRate.ToString()));
            base.SaveAllProperties(output);
        }
    }

