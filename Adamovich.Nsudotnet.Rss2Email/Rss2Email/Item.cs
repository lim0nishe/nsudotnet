using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rss2Email
{
    class Item : Record
    {
        public string Title { get; set; }
        public string Link { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime PubDate { get; set; }

        public Item(string title, string link, string description, string category, string pubDate)
        {
            Title = title;
            Link = link;
            Description = description;
            Category = category;
            PubDate = DateTime.Parse(pubDate);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append(Title);
            builder.Append("\n");
            builder.Append(Link);
            builder.Append("\n");
            builder.Append(Description);
            builder.Append("\n");
            builder.Append(PubDate);
            builder.Append("\nCategory: ");
            builder.Append(Category);
            builder.Append("\n-------------------------------------------------------------------------------\n");
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
