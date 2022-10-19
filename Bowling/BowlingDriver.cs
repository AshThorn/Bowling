using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    public class BowlingDriver
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Default bowling average:" + new BowlingAverage());

            bool repeat = false;
            do
            {
                try
                {
                    Console.Write("\nHow many games were bowled? ");
                    string input = Console.ReadLine();
                    bool validInput = int.TryParse(input, out int numGames);

                    while (!validInput || numGames < 0)
                    {
                        Console.Write("Invalid integer input.\n\nHow many Games were bowled? ");
                        validInput = int.TryParse(Console.ReadLine(), out numGames);
                    }
                    int[] scores = new int[numGames];

                    for (int i = 0; i < numGames; i++)
                    {
                        Console.Write("What was the score for game " + i + "? ");
                        scores[i] = int.Parse(Console.ReadLine());
                    }

                    BowlingAverage avg = new BowlingAverage(scores, numGames);

                    Console.WriteLine(avg);

                }
                catch (BowlingException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.Write("Do you want to average more scores (Y/N)? ");

                repeat = Console.ReadLine() == "Y";//this will technically treat anything that is not a capital Y as a "no" answer
            } while (repeat);
        }
    }
}
