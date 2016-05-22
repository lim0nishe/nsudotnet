using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace NumberGuesser
{
    class Session
    {
        private const int MinValue = 0;
        private const int MaxValue = 100;

        public string PlayerName { get; set; }

        private readonly string[] _humiliations = {"You are weak, {0}", "Stupid little {0}", "OMG, WHY ARE U SUCH A FOOL, {0}?",
            "Bullshit, {0}", "Two wrongs don't make a right, {0}, take your parents as an example",
            "If I wanted to kill myself I'd climb your ego and jump to your IQ, {0}" };

        
        private string[] _history;

        public void Play()
        {
            _history = new string[1000];
            var random = new Random();
            int target = random.Next(MinValue, MaxValue + 1);
            string tmp;
            int answer;
            DateTime startTime = DateTime.Now;

            Console.WriteLine(
                $"Wanna play a game? ]:) Try to guess the number I put forth. Range: {MinValue} - {MaxValue}");
            for (var count = 1; count <= 1000; count++)
            {
                tmp = Console.ReadLine();
                if (string.IsNullOrEmpty(tmp))
                {
                    count--;
                    continue;
                }
                if (tmp.Equals("q"))
                {
                    Console.WriteLine("Good Bye");
                    return;
                }
                try
                {
                    answer = int.Parse(tmp);
                }
                catch (FormatException)
                {
                    Console.WriteLine("I need a natural number, man");
                    count--;
                    continue;
                }
                if (answer == target)
                {
                    // будем считать, что никто не станет играть днями напролет
                    int time = (DateTime.Now.Minute - startTime.Minute) + (DateTime.Now.Hour - startTime.Hour)*60;

                    var builder = new StringBuilder();
                    builder.Append("Ok, you are right\n");
                    builder.Append("Number of attempts: ");
                    builder.Append(count.ToString());
                    builder.Append("\nYour answers: ");
                    _history[count - 1] = answer + " Right!"; 
                    Console.WriteLine(builder.ToString());
                    for(var i =0; i < count; i++)
                    {
                        Console.WriteLine(_history[i]);
                    }
                    Console.WriteLine($"Your time is: {time}");
                    return;
                }
                else
                {
                    var builder = new StringBuilder();
                    builder.Append(answer);
                    if (count%4 == 0)
                    {
                        Console.WriteLine(_humiliations[random.Next(0, 6)], PlayerName);
                    }
                    if (answer > target)
                    {
                        Console.WriteLine("Your answer is greater than target number");
                        builder.Append(" > target number");
                    }
                    else
                    {
                        Console.WriteLine("Your answer less than target number");
                        builder.Append(" < target number");
                    }
                    _history[count - 1] = builder.ToString();
                }
               
            }
        }
    }
}
