using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace Serialization
{
    [Serializable]
    [XmlType (TypeName = "catalog")]
    public class Catalog
    {
        [XmlArray]
        public List<Book> Books { get; set; } = new List<Book>();
        
    }

    [Serializable]
    [XmlType (TypeName = "book")]
    public class Book
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement ("isbn")]
        public string Isbn { get; set; }

        [XmlElement("author")]
        public string Author { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("genre")]
        public Genre  Gen{ get; set; }

        [XmlElement("publisher")]
        public string Publisher { get; set; }

        [XmlElement("publish_date")]
        public DateTime PublishDate { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("registration_date")]
        public DateTime RegistrationDate { get; set; }

        public Book(KeyValuePair<string,List<string>> book)
        {
            this.Id = book.Key;

            //if(!book.Value.First().Equals("")) { this.Isbn = book.Value.First();}

            this.Author = book.Value[0];

            this.Title = book.Value[1];

            string gen = book.Value[2];
            switch (gen)
            {
                case "Computer":
                    this.Gen = Genre.Computer;
                    break;
                case "Fantasy":
                    this.Gen = Genre.Fantasy;
                    break;
                case "Romance":
                    this.Gen = Genre.Romance;
                    break;
                case "Horror":
                    this.Gen = Genre.Horror;
                    break;
                case "Science Fiction":
                    this.Gen = Genre.ScienceFiction;
                    break;
                    //default:
                    //    throw new ArgumentException();

            }
                
            this.Publisher = book.Value[3];

            string publishDate = book.Value[4];
            IFormatProvider culture = CultureInfo.CurrentCulture.DateTimeFormat;
            this.PublishDate = DateTime.ParseExact(publishDate, "yyyy-MM-dd", culture);

            this.Description = book.Value[5];

            string registrationDate = book.Value[6];
            this.RegistrationDate = DateTime.ParseExact(registrationDate, "yyyy-MM-dd", culture);
            
        }
    }

    public enum Genre
    {
        [XmlEnum]
        Computer,
        [XmlEnum]
        Fantasy,
        [XmlEnum]
        Romance,
        [XmlEnum]
        Horror,
        [XmlEnum]
        ScienceFiction,
    }
}
