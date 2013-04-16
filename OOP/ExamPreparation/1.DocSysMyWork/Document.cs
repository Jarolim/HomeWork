using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Document : IDocument
{
    public string Name { get; private set; }

    public string Content { get; private set; }
   
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
            throw new ArgumentException("Key '"+ key + "' not found");
        }
    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name" , this.Name));
        output.Add(new KeyValuePair<string, object>("content", this.Content));
    }

    public override string ToString()
    {
        List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();
        this.SaveAllProperties(properties);
        properties.Sort();
        StringBuilder result = new StringBuilder();
        result.Append(this.GetType().Name);
        result.Append("[");
        foreach (var prop in properties)
        {
            result.AppendFormat("{0}={1}", prop.Key,prop.Value);
        }
        result.Append("]");
        return result.ToString();
    }
}

