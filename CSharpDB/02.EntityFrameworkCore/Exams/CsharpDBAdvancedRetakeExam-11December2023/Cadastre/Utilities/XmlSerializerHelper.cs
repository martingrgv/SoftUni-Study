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
    }
}
