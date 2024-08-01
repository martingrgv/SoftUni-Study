using System.ComponentModel.DataAnnotations;
using System.Xml;
using System.Xml.Serialization;

namespace Cadastre.Utilities
{
    public static class XmlSerializerHelper
    {
        public static T? Deserialize<T>(string xmlDocument, string rootName)       
        {
            if (string.IsNullOrEmpty(xmlDocument))
            {
                throw new ArgumentException("Xml document cannot be null or empty!");
            }

            if (string.IsNullOrEmpty(rootName))
            {
                throw new ArgumentException("Root name cannot be null or empty!");
            }

            var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));

            var reader = new StringReader(xmlDocument);
            return (T?)serializer.Deserialize(reader);
        }

        public static string Serialize<T>(T obj, string rootName)
        {
            if (obj == null)
            {
                throw new ArgumentException("Cannot serialize null object reference!");
            }

            if (string.IsNullOrEmpty(rootName))
            {
                throw new ArgumentException("Root name cannot be null or empty!");
            }

            var serializer = new XmlSerializer(typeof(T), new XmlRootAttribute(rootName));
            var xmlNamespaces = new XmlSerializerNamespaces();
            xmlNamespaces.Add(string.Empty, string.Empty);

            using (var writer = new StringWriter())
            {
                serializer.Serialize(writer, obj, xmlNamespaces);
                return writer.ToString().TrimEnd();
            }
        }
    }
}
