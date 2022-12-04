namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "sectors.txt";
            StreamReader sr = new StreamReader(@$"Data\{file}");

            int counter1 = 0;
            int counter2 = 0;

            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();

                //PREP DATA
                string[] elves = line.Split(',');
                string[] sector1 = elves[0].Split('-');
                string[] sector2 = elves[1].Split('-');
                int[] s1 = {
                    Convert.ToInt32(sector1[0]),
                    Convert.ToInt32(sector1[1])
                };
                int[] s2 = {
                    Convert.ToInt32(sector2[0]),
                    Convert.ToInt32(sector2[1])
                    };

                if ((s1[0] >= s2[0] && s1[1] <= s2[1]) || (s2[0] >= s1[0] && s2[1] <= s1[1]))
                {
                    counter1++;
                }
                if ((s1[0] >= s2[0] && s1[0] <= s2[1]) || (s2[0] >= s1[0] && s2[0] <= s1[1]))
                {
                    counter2++;
                }
            }
            sr.Close();
            Console.WriteLine("PART 1");
            Console.WriteLine(counter1);
            Console.WriteLine("PART 2");
            Console.WriteLine(counter2);

        }
    }
}