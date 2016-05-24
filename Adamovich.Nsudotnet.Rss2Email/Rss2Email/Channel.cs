using System.Text;
using System.Xml.Serialization;

namespace Rss2Email
{
    [XmlRoot("channel")]
    public class Channel : Record
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        [XmlElement("link")]
        public string Link { get; set; }

        [XmlElement("language")]
        public string Language { get; set; }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine("-------------------------------------------------------------------------------");
            builder.Append("Language: ");
            builder.AppendLine(Language);
            builder.Append(Title);
            builder.Append(": ");
            builder.AppendLine(Description);
            builder.AppendLine(Link);
            builder.AppendLine("-------------------------------------------------------------------------------");
            return builder.ToString();
        }

        public Channel(string language, string title, string description, string link)
        {
            Title = title;
            Description = description;
            Link = link;
            Language = language;
        }

        public Channel()
        {
            Title = "";
            Description = "";
            Link = "";
            Language = "";
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
