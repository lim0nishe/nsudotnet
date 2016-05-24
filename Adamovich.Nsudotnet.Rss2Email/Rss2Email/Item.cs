using System.Text;
using System.Xml.Serialization;

namespace Rss2Email
{
    [XmlRoot("item")]
    public class Item : Record
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("category")]
        public string Category { get; set; }

        [XmlElement("pubDate")]
        public string PubDate { get; set; }

        //[XmlElement("pubDate")]
        //public string ProxyDate
        //{
        //    set { PubDate = DateTime.Parse(value); }
        //}

        public Item(string title, string link, string description, string category, string pubDate)
        {
            Title = title;
            Link = link;
            Description = description;
            Category = category;
            PubDate = pubDate;
        }

        public Item(){}

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(Title);
            builder.AppendLine(Link);
            builder.AppendLine(Description);
            builder.Append(PubDate);
            builder.Append("\nCategory: ");
            builder.AppendLine(Category);
            builder.AppendLine("-------------------------------------------------------------------------------");
            return builder.ToString();
        }

        public override bool Equals(object obj)
        {
            Item anotherItem = obj as Item;
            if (anotherItem == null)
                return false;
            if ((this.PubDate == anotherItem.PubDate) && (this.Category == anotherItem.Category) && 
                (this.Description == anotherItem.Description) && (this.Link == anotherItem.Link) && 
                (this.Title == anotherItem.Title))
                return true;
            return false;
        }
    }
}
