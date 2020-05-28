using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public static class XmlParser<T>
{
    public static IList<T> ParseListFromXmlFile(string filepath) 
    {
        //if (!File.Exists(filepath))
        //{
        //    return new List<T>();
        //}

        using (var stream = new StreamReader(filepath))
        {
            var serializer = new XmlSerializer(typeof(List<T>), new XmlRootAttribute("Root"));
            return (List<T>)serializer.Deserialize(stream);
        }


    }
    public static T ParseObjectFromXmlFile(string filepath) 
    {
        //if (!File.Exists(filepath))
        //{
        //    return ;
        //}

        using (var stream = new StreamReader(filepath))
        {
            var serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stream);
        }


    }
}
