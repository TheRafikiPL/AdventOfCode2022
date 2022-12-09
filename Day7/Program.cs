namespace Day7
{
    public class Dir
    {
        public string name;
        public int parent;
        public List<int> children;
        public Dictionary<string, int> files;

        public Dir(string name, int parent)
        {
            this.name = name;
            children = new List<int>();
            files = new Dictionary<string, int>();
            this.parent = parent;
        }

        public void AddChild(int i)
        {
            children.Add(i);
        }

        public int CalculateSize()
        {
            int sum = 0;

            foreach(var f in files.Values)
            {
                sum += f;
            }

            return sum;
        }
    }
    internal class Program
    {
        public static List<Dir> dirs = new List<Dir>();
        static void Main(string[] args)
        {
            string file = "commands.txt";
            StreamReader sr = new StreamReader($@"Data/{file}");
            sr.ReadLine();

            dirs.Add(new Dir("/", 0));
            int ind = 0;

            while(!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(' ');
                switch(line[0])
                {
                    case "$":
                        if (line[1]=="cd")
                        {
                            if (line[2]=="..")
                            {
                                ind = dirs[ind].parent;
                                break;
                            }
                            for (int i = 0; i < dirs[ind].children.Count; i++)
                            {
                                if (dirs[dirs[ind].children[i]].name == line[2])
                                {
                                    ind = dirs[ind].children[i];
                                    break;
                                }
                            }
                        }
                        break;
                    case "dir":
                        dirs[ind].children.Add(dirs.Count);
                        dirs.Add(new Dir(line[1], ind));
                        break;
                    default:
                        dirs[ind].files.Add(line[1], Convert.ToInt32(line[0]));
                        break;
                }
            }
            sr.Close();
            List<int> sizes = new List<int>();
            int sum = 0;
            int l = 0;
            foreach (Dir d in dirs)
            {
                /*
                Console.WriteLine($"{d.name}, {d.parent}");
                foreach (int j in d.children)
                {
                    Console.Write(j + " ");
                }
                Console.WriteLine();
                foreach (var k in d.files)
                {
                    Console.Write($"{k.Key} {k.Value}, ");
                }
                Console.WriteLine();*/
                int size = SizeOfDir(l);
                sizes.Add(size);
                //Console.WriteLine($"Size of files: {size}");
                if (size <= 100000)
                {
                    sum += size;
                }
                //Console.WriteLine("\n");
                l++;
            }
            Console.WriteLine("PART 1");
            Console.WriteLine(sum);
            sizes.Sort();
            int cap = 70000000;
            cap -= sizes[sizes.Count-1];
            int upd = 30000000;
            Console.WriteLine("\nPART 2");
            for (int p = 1; p < sizes.Count; p++)
            {
                if (cap + sizes[p]>upd)
                {
                    Console.WriteLine(sizes[p]);
                    return;
                }
            }
        }
        public static int SizeOfDir(int i)
        {
            if (dirs[i].children.Count>0)
            {
                int sum = 0;
                foreach(int j in dirs[i].children)
                {
                    sum += SizeOfDir(j);
                }
                return dirs[i].CalculateSize() + sum;
            }
            return dirs[i].CalculateSize();
        }
    }
}