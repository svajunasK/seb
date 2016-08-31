using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ChangeCurrency.Business.Operations.Mappers
{
    public static class XmlNodeMapper
    {
        public static T To<T>(this XmlNode node) where T : class
        {
            var stm = new MemoryStream();

            var stw = new StreamWriter(stm);
            stw.Write(node.OuterXml);
            stw.Flush();

            stm.Position = 0;

            var ser = new XmlSerializer(typeof(T));
            T result = (ser.Deserialize(stm) as T);

            return result;
        }
    }
}
