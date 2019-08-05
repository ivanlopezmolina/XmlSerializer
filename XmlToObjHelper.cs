using MyProject.Core.Exceptions;
using System;
using System.IO;
using System.Xml.Serialization;

namespace MyProject.Helpers
{
    public static class XmlToObjHelper
    {
        public static T Serialize<T>(string xml)
        {
            T objReturn = default(T);

            using(TextReader reader = new StringReader(xml))
            {
                try
                {
                    objReturn = (T)new XmlSerializer(typeof(T)).Deserialize(reader);
                }
                catch(InvalidOperationException ex)
                {
                    throw new CustomDeserializationException(ex);
                }
            }

            return objReturn;
        }
    }
}