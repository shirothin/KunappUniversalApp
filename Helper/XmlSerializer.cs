using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace NavigationMenuSample.Helper
{
	public class XmlSerializer<T>
		where T : class, new()
	{
		public static T Deserialize(string xml)
		{
			return Deserialize(xml, Encoding.UTF8);
		}

		public static T Deserialize(string xml, Encoding encoding)
		{
			if (string.IsNullOrEmpty(xml))
				throw new ArgumentException("XML cannot be null or empty", "xml");
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
			using (MemoryStream memoryStream = new MemoryStream(encoding.GetBytes(xml)))
			{
				using (XmlReader xmlReader = XmlReader.Create(memoryStream))
				{
					return (T)xmlSerializer.Deserialize(xmlReader);
				}
			}
		}

		public static string Serialize(T source)
		{
			// indented XML by default
			return Serialize(source, null);
		}

		public static string Serialize(T source, XmlSerializerNamespaces namespaces)
		{
			if (source == null)
				throw new ArgumentNullException("source", "Object to serialize cannot be null");
			string xml = null;
			XmlSerializer serializer = new XmlSerializer(source.GetType());
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (XmlWriter xmlWriter = XmlWriter.Create(memoryStream))
				{
					System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(T));
					x.Serialize(xmlWriter, source, namespaces);
					// Do not place here to StreamReader !
				}
				memoryStream.Position = 0; // rewind the stream before reading back.
				using (StreamReader sr = new StreamReader(memoryStream))
				{
					xml = sr.ReadToEnd();
				}
			}
			return xml;
		}
	}
}
