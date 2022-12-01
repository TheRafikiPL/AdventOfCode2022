using System.IO;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "calories.txt";
            StreamReader sr = new StreamReader(@$"Data\{file}");
            List<int> elves = new List<int>();

            int i = 0;
            elves.Add(0);

            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if(line=="")
                {
                    i++;
                    elves.Add(0);
                    continue;
                }
                elves[i] += Convert.ToInt32(line);
            }
            sr.Close();
            elves.Sort();
            elves.Reverse();
            Console.WriteLine($"Elf 1 = {elves[0]}");
            Console.WriteLine($"Elf 2 = {elves[1]}");
            Console.WriteLine($"Elf 3 = {elves[2]}");
            Console.WriteLine($"Elfy = {elves[0] + elves[1] + elves[2]}");
        }
    }
}