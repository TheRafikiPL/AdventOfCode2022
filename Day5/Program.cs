namespace Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "cargo.txt";
            StreamReader sr  = new StreamReader(@$"Data\{file}");

            string line = sr.ReadLine();
            List<string> supplies = new List<string>();

            for (int i = 1, indeks = 0; i < line.Length - 1; i += 4, indeks++)
            {
                supplies.Add("");
            }
            while (line[1]!='1')
            {
                for (int i = 1, indeks = 0; i < line.Length - 1; i += 4, indeks++)
                {
                    if (line[i] != ' ')
                    {
                        supplies[indeks] += line[i];
                    }
                }
                line = sr.ReadLine();
            }
            sr.ReadLine();
            while(!sr.EndOfStream)
            {
                string[] commands = sr.ReadLine().Split(' ');
                int count = Convert.ToInt32(commands[1]);
                int from = Convert.ToInt32(commands[3]);
                int to = Convert.ToInt32(commands[5]);

                string tmp = "";
                for (int i = 0; i < count; i++)
                {
                    tmp = supplies[from - 1][i]+tmp;
                }
                supplies[to-1]=tmp+supplies[to-1];
                tmp = "";
                for (int i = count; i < supplies[from-1].Length; i++)
                {
                    tmp += supplies[from - 1][i];
                }
                supplies[from - 1] = tmp;
            }
            sr.Close();
            Console.WriteLine("PART 1");
            foreach(string s in supplies)
            {
                Console.Write(s[0]);
            }

            //PART 2

            sr = new StreamReader(@$"Data\{file}");

            line = sr.ReadLine();
            supplies = new List<string>();

            for (int i = 1, indeks = 0; i < line.Length - 1; i += 4, indeks++)
            {
                supplies.Add("");
            }
            while (line[1] != '1')
            {
                for (int i = 1, indeks = 0; i < line.Length - 1; i += 4, indeks++)
                {
                    if (line[i] != ' ')
                    {
                        supplies[indeks] += line[i];
                    }
                }
                line = sr.ReadLine();
            }
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string[] commands = sr.ReadLine().Split(' ');
                int count = Convert.ToInt32(commands[1]);
                int from = Convert.ToInt32(commands[3]);
                int to = Convert.ToInt32(commands[5]);

                string tmp = "";
                for (int i = 0; i < count; i++)
                {
                    tmp += supplies[from - 1][i];
                }
                supplies[to - 1] = tmp + supplies[to - 1];
                tmp = "";
                for (int i = count; i < supplies[from - 1].Length; i++)
                {
                    tmp += supplies[from - 1][i];
                }
                supplies[from - 1] = tmp;
            }
            sr.Close();
            Console.WriteLine("\n\nPART 2");
            foreach (string s in supplies)
            {
                Console.Write(s[0]);
            }
        }
    }
}