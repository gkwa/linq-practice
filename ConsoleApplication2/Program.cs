using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Reflection;


namespace ConsoleApplication2
{
    class Program
    {
        static void Main(string[] args)
        {

            //            XElement books = XElement.Parse(
            //       @"<books>
            //            <book>
            //            <title>Pro LINQ: Language Integrated Query in C#2010</title>
            //            <author>Joe Rattz</author>
            //            </book>
            //            <book>
            //            <title>Pro .NET 4.0 Parallel Prog ramming in C#</title>
            //            <author>Adam Freeman</author>
            //            </book>
            //            <book>
            //            <title>Pro VB 2010 and the .NET 4.0 Platform</title>
            //            <author>Andrew Troelsen</author>
            //            </book>
            //            </books>");

            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = "ConsoleApplication2.books.xml";

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();

                //   XElement books = XElement.Load(@"books.xml");
                XElement books = XElement.Parse(result);
                var titles =
                from book in books.Elements("book")
                where (string)book.Element("author") == "Joe Rattz"
                select book.Element("title");
                foreach (var title in titles)
                    Console.WriteLine(title.Value);
                Console.Write("Enter to continue...");
                Console.Read();
            }
        }
    }
}
