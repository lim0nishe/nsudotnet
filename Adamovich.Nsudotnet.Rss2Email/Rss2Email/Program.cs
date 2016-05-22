using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using System.Runtime.Remoting.Messaging;

namespace Rss2Email
{
    class Program
    {
        static void Main(string[] args)
        {
            // Program, arguments: destination email, sender email, password
            try
            {
                RSSListener listener = new RSSListener();
                
                // первое попавшееся значение в прошлом, чтобы при запуске пробрасывались все записи
                // (на самом деле просто смотрел документацию по DateTime.Parse и скопипастил оттуда строку с датой)
                RSSListener.LastReading = DateTime.Parse("03/01/2009 05:42:00 -5:00");
                listener.RssAddress = "https://lenta.ru/rss/top7";

                // проверяем каждые 20 секунд
                listener.Interval = 20000; 
                listener.StartListen(args[0], args[1], args[2]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
        }
    }
}
