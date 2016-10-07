using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            const string fileName = @"D:\file.xml"; 
            Catalog c = new Catalog();
            ReadingFromXmlFile file = new ReadingFromXmlFile();
            var collection = file.GetBooks();
            foreach (var book in collection)
            {
                c.Books.Add(new Book(book));
                
            }
            

            var serializer = new XmlSerializer(typeof(Catalog));
            var stream = new FileStream(fileName, FileMode.Create);
            serializer.Serialize(stream, c);
            stream.Close();
        }
    }
}
