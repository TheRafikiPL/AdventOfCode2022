namespace Day3
{
    internal class Program
    {
        static int CheckPriority(char c)
        {
            if(c>='a' && c<='z')
            {
                return Convert.ToInt32(c)-96;
            }
            return Convert.ToInt32(c)-38;
        }
        static void Main(string[] args)
        {
            string file = "items.txt";
            StreamReader sr = new StreamReader(@$"Data\{file}");

            //PART 1
            int sum = 0;

            while(!sr.EndOfStream)
            {
                string line=sr.ReadLine();
                Dictionary<char,bool> ItemExist = new Dictionary<char,bool>();
                
                for (int i = 0; i < line.Length/2; i++)
                {
                    if (!ItemExist.ContainsKey(line[i]))
                    {
                        ItemExist.Add(line[i], true);
                    }
                }
                for (int i = line.Length/2; i < line.Length; i++)
                {
                    if (ItemExist.ContainsKey(line[i]) && ItemExist[line[i]])
                    {
                        sum += CheckPriority(line[i]);
                        ItemExist[line[i]] = false;
                    }
                }
            }
            sr.Close();
            Console.WriteLine("PART 1");
            Console.WriteLine(sum);

            //PART 2
            Console.WriteLine("\nPART 2");
            sr = new StreamReader(@$"Data\{file}");
            sum = 0;
            
            while(!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                Dictionary<char, bool> ItemExist = new Dictionary<char, bool>();

                for (int i = 0; i < line.Length; i++)
                {
                    if (!ItemExist.ContainsKey(line[i]))
                    {
                        ItemExist.Add(line[i], true);
                    }
                }

                line = sr.ReadLine();
                for (int i = 0; i < line.Length; i++)
                {
                    if (ItemExist.ContainsKey(line[i]))
                    {
                        ItemExist[line[i]] = false;
                    }
                }

                line = sr.ReadLine();
                for (int i = 0; i < line.Length; i++)
                {
                    if(ItemExist.ContainsKey(line[i]))
                    {
                        if (!ItemExist[line[i]])
                        {
                            sum += CheckPriority(line[i]);
                            break;
                        }
                    }
                }
            }
            sr.Close();
            Console.WriteLine(sum);
        }
    }
}