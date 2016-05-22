using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Rss2Email
{
    class XmlParser
    {
        public static Channel Parse(out List<Item> items, Stream source)
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(source); 
                XmlNode channelNode = doc.DocumentElement["channel"];                
                var itemList = new List<Item>();

                string language = "";
                string title = "";
                string description = "";
                string link = "";

                foreach (XmlNode node in channelNode)
                {
                    switch (node.Name)
                    {
                        case "description":
                            description = node.InnerText;
                            break;
                        case "language":
                            language = node.InnerText;
                            break;
                        case "title":
                            title = node.InnerText;
                            break;
                        case "link":
                            link = node.InnerText;
                            break;
                        case "item":
                            itemList.Add(new Item(node["title"].InnerText, node["link"].InnerText, node["description"].InnerText,
                                node["category"].InnerText, node["pubDate"].InnerText));
                            break;
                    }
                }
                Channel channel = new Channel(language, title, description, link);
                items = itemList;
                return channel;
            }
            catch (NullReferenceException e)
            {
                System.Console.WriteLine(e.StackTrace);
                items = null;
                return null;
            }

        }
    }
}
