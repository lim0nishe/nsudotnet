using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Hello! Please, entre your name: ");
                string input;
                while (string.IsNullOrEmpty(input = Console.ReadLine()))
                {
                    Console.WriteLine("Enter your name, please: ");
                }
                Session session = new Session();
                session.PlayerName = input;
                session.Play();
                Console.WriteLine("Type <y> if you wanna play again");
                input = Console.ReadLine();
                if (!input.Equals("y"))
                    return;
            }
        }
    }
}
