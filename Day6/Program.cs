namespace Day6
{
    internal class Program
    {
        static string file = "signal.txt";
        static void CalculateSignal(int numberOfLetters)
        {
            StreamReader sr = new StreamReader($@"Data\{file}");
            string line = sr.ReadLine();

            for (int i = 0; i < line.Length - numberOfLetters; i++)
            {
                bool isgood = true;
                List<char> letters = new List<char>();
                for (int j = 0; j < numberOfLetters; j++)
                {
                    if (letters.Contains(line[i + j]))
                    {
                        isgood = false;
                        break;
                    }
                    letters.Add(line[i + j]);
                }
                if (isgood)
                {
                    Console.WriteLine(i + numberOfLetters);
                    break;
                }
            }
            sr.Close();
        }

        static void Main(string[] args)
        {
            //PART 1
            Console.WriteLine("PART 1");
            CalculateSignal(4);
            
            //PART 2
            Console.WriteLine("PART 2");
            CalculateSignal(14);
        }
    }
}