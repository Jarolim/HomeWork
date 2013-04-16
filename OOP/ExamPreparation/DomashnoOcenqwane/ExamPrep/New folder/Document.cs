using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


    public abstract class Document : IDocument
    {
        public string Name
        {
            get;
            protected set;
        }

        public string Content
        {
            get;
            protected set;
        }

        public Document(string name)
        {
            this.Name = name;
            this.Content = String.Empty;
        }

        public Document(string name, string content = null)
        {
            this.Name = name;
            this.Content = content;
        }

       
        public virtual void LoadProperty(string key, string value)
        {
            if (key == "name")
            {
                this.Name = value;
            }
            else if (key == "content")
            {
                this.Content = value;
            }
            else
            {
                throw new KeyNotFoundException(key + " does not exist!");
            }
        }


        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string,object>("name", this.Name));
            output.Add(new KeyValuePair<string,object>("content", this.Content));
        }

        public override string ToString()
        {
            List<KeyValuePair<string, object>> props = new List<KeyValuePair<string, object>>();
            SaveAllProperties(props);
            string ordered =
                String.Join(";", props.OrderBy(x => x.Key).Where(x => (x.Value != null && x.Value != "")).Select(x => x.Key + "=" + x.Value));

            return String.Format("{0}[{1}]", this.GetType().Name, ordered);
        }
    }

