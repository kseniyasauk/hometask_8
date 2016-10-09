using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Serialization
{
    class ReadingFromXmlFile
    {
        public Dictionary<string, List<string>> GetBooks()
        {
            //XDocument xd = XDocument.Load(@"D:\ht8\hometask_8\Serialization\Books.xml");
            XDocument xd = XDocument.Load(@"..\..\Books.xml");

            Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
            

            var books = xd.Elements()
                .First()
                .Elements();
            foreach (var book in books)
            {
                List<string> attList = new List<string>();
                string id = book.FirstAttribute.ToString();
                var attributes = book.Elements();
                //bool flag = !attributes.ToList().Exists(el => el.Name.LocalName.Equals("isbn"));
                
                foreach (var attr in attributes)
                {
                    if (attr.Name.LocalName == "isbn")
                    {
                        //break;
                        continue;
                    }
                    //attList.Add(flag ? attr.Value : "");
                    attList.Add(attr.Value);
                }
                dictionary.Add(id, attList);
            }
            return dictionary;
        }
        
    }
}
