using System.ComponentModel;
using System.IO;
using System.Numerics;

namespace Day2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PART 1
            Console.WriteLine("PART 1");
            string file = "tournament.txt";
            StreamReader sr = new StreamReader($@"Data\{file}");

            List<Round> rounds = new List<Round>();

            int sumOfPoints = 0;

            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                rounds.Add(new Round(line[0], line[2]));
            }
            sr.Close();

            foreach (Round r in rounds)
            {
                sumOfPoints += r.PlayerScore;
            }
            Console.WriteLine($"Total Score: {sumOfPoints}");

            //PART 2
            Console.WriteLine("\nPART 2");
            sr = new StreamReader($@"Data\{file}");

            rounds = new List<Round>();

            sumOfPoints = 0;

            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                ChosenFigure cf= CalculateChosenFigure(line[0], line[2]);
                
                rounds.Add(new Round(line[0], cf));
            }
            sr.Close();

            foreach (Round r in rounds)
            {
                sumOfPoints += r.PlayerScore;
            }
            Console.WriteLine($"Total Score: {sumOfPoints}");
        }

        static ChosenFigure CalculateChosenFigure(char oponent, char result)
        {
            switch (oponent)
            {
                //A = Rock
                case 'A':
                    switch (result)
                    {
                        case 'X':
                            return ChosenFigure.Scissors;
                        case 'Y':
                            return ChosenFigure.Rock;
                        case 'Z':
                            return ChosenFigure.Paper;
                    }
                    break;
                //B = Paper
                case 'B':
                    switch (result)
                    {
                        case 'X':
                            return ChosenFigure.Rock;
                        case 'Y':
                            return ChosenFigure.Paper;
                        case 'Z':
                            return ChosenFigure.Scissors;
                    }
                    break;
                //C = Scissors
                case 'C':
                    switch (result)
                    {
                        case 'X':
                            return ChosenFigure.Paper;
                        case 'Y':
                            return ChosenFigure.Scissors;
                        case 'Z':
                            return ChosenFigure.Rock;
                    }
                    break;
            }
            //placeholdeer bcs reasons
            return ChosenFigure.Rock;
        }
    }
}