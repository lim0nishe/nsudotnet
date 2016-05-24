using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Timers;
using Timer = System.Timers.Timer;

namespace Rss2Email
{
    class RSSListener 
    {
        public int Interval { get; set; }
        public string RssAddress { get; set; }
        public static DateTime LastReading;

        private Messager _messager;

        private void GetResult(object sender, ElapsedEventArgs args)
        {
            try
            {
                var wrGetRequest = WebRequest.Create(RssAddress);
                using (Stream xmlStream = wrGetRequest.GetResponse().GetResponseStream())
                {

                    List<Item> news;
                    Channel channel = XmlParser.Parse(out news, xmlStream);

                    _messager.AddRecord(channel);
                    foreach (var tmp in news)
                    {
                        if (DateTime.Parse(tmp.PubDate).CompareTo(LastReading) > 0)
                            _messager.AddRecord(tmp);
                    }
                    LastReading = DateTime.Now;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }

        public void StartListen(string mailAddress, string sender, string password)
        {
            _messager = new Messager { MailAddress = mailAddress, Sender = sender, Password = password };
            using (var timer = new Timer
            {
                Interval = this.Interval,
                AutoReset = true
            })
            {
                timer.Elapsed += GetResult;
                timer.Enabled = true;

                Console.WriteLine("press Enter to stop forwading messages");
                Console.ReadLine();
            }
        }

    }
}
