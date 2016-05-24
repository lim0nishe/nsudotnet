using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Rss2Email
{
    class XmlParser
    {
        public static Channel Parse(out List<Item> items, Stream source)
        {
            try
            {
                var doc = XDocument.Load(source); 
                 
                var itemList = new List<Item>();

                XElement channelElement = doc.Descendants("channel").First();
                XmlSerializer channelSerializer = new XmlSerializer(typeof(Channel));

                Channel channel = channelSerializer.Deserialize(channelElement.CreateReader()) as Channel;

                XmlSerializer itemSerializer = new XmlSerializer(typeof(Item));
                IEnumerable<XElement> xmlItems = channelElement.Descendants("item");
                foreach (var item in xmlItems)
                {
                    Item tmp = itemSerializer.Deserialize(item.CreateReader()) as Item;
                    itemList.Add(tmp);
                }

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
