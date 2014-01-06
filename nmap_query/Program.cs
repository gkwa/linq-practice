using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Xml;
using System.Text;
using System.Configuration;
using System.IO;
using System.Reflection;


namespace nmap_query
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "nmap_query.nmap_results.xml";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();

                ////   XElement books = XElement.Load(@"books.xml");
                XElement nmr = XElement.Parse(result);

                var query = (from host in nmr.Descendants("host")
                             from port in host.Descendants("port")
                             where ((string)port.Attribute("protocol") == "udp" &&
                             (((string)port.Attribute("portid") == "1771") || ((string)port.Attribute("portid") == "1770") &&
                             (((string)port.Element("state").Attribute("state") == "open")) || ((string)port.Element("state").Attribute("state") == "open|filtered")
                             )) select host);

                foreach (XElement address in query.Elements("address"))
                {
                    if ((string)address.Attribute("addrtype") == "ipv4")
                        Console.WriteLine((string)address.Attribute("addr"));


                }
            }
        }
    }
}
