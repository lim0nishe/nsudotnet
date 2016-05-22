using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rss2Email
{
    class Channel : Record
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string Language { get; set; }
        // можно добавить картинку

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.Append("-------------------------------------------------------------------------------\n");
            builder.Append("Language: ");
            builder.Append(Language);
            builder.Append("\n");
            builder.Append(Title);
            builder.Append(": ");
            builder.Append(Description);
            builder.Append("\n");
            builder.Append(Link);
            builder.Append("\n-------------------------------------------------------------------------------\n");
            return builder.ToString();
        }

        public Channel(string language, string title, string description, string link)
        {
            Title = title;
            Description = description;
            Link = link;
            Language = language;
        }

        public override bool Equals(object obj)
        {
            var anotherChannel = obj as Channel;
            if (anotherChannel == null)
                return false;
            if ((this.Title == anotherChannel.Title) && (this.Description == anotherChannel.Description) &&
                (this.Language == anotherChannel.Language) && (this.Link == anotherChannel.Link))
                return true;
            return false;
        }
    }
}
