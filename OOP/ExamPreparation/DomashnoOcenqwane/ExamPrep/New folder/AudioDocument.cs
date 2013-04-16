using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public class AudioDocument : MultimediaDocument
    {
        public int? SampleRate
        {
            get;
            set;
        }

        public AudioDocument(string name, string content = null, string size = null, int? length = null, int? samplerate = null)
            :base(name, content, size, length)
        {
            this.SampleRate = samplerate;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "samplerate")
            {
                this.SampleRate = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string,object>("samplerate", this.SampleRate.ToString()));
            base.SaveAllProperties(output);
        }
    }

