using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Unity_Build_Manager
{
    class XMLSaver
    {
        public string[] loadFromXML(string filePath)
        {
            List<string> stringValues = new List<string>();
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(filePath);

            for(int i = 0; i < xDoc.SelectSingleNode("Builds").Attributes.Count; i++)
            {
                stringValues.Add(xDoc.SelectSingleNode("Builds").Attributes[i].Value);
            }
            

            XmlNodeList builds = xDoc.SelectNodes("Builds/Build");

            

            foreach(XmlNode node in builds)
            {
                stringValues.Add(node.InnerText);
            }

            return stringValues.ToArray();
        }

        public void saveToXML(string filePath, string[] items, bool archive, string buildName)
        {
            if(File.Exists(filePath))
                File.Delete(filePath);

            XmlWriterSettings xWriterSettings = new XmlWriterSettings();
            xWriterSettings.Indent = true;

            using(XmlWriter xWriter = XmlWriter.Create(filePath, xWriterSettings))
            {
                xWriter.WriteStartDocument();

                xWriter.WriteStartElement("Builds");
                if (archive)
                    xWriter.WriteAttributeString("archive", "true");
                else
                    xWriter.WriteAttributeString("archive", "false");

                xWriter.WriteAttributeString("buildName", buildName);

                    for (int i = 0; i < items.Length; i++)
                    {
                        xWriter.WriteStartElement("Build");
                        xWriter.WriteString(items[i]);
                        xWriter.WriteEndElement();
                    }

                xWriter.WriteEndElement();

                xWriter.WriteEndDocument();
            }
        }
    }
}
