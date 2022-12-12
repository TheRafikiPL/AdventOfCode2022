namespace Day10
{
    internal class Program
    {
        static int X = 1;
        static int cycleCounter = 0;
        static List<int> registerStatus = new List<int>();
        static void CallCycle()
        { 
            cycleCounter++;
            DrawPixel();
            CheckCycleCounter();
        }
        static void CheckCycleCounter()
        {
            if((cycleCounter-20) % 40 == 0)
            {
                registerStatus.Add(cycleCounter*X);
            }
            if (cycleCounter % 40 == 0)
            {
                Console.WriteLine();
            }
        }
        static void Command(string s)
        {
            string[] c = s.Split(' ');
            switch(c[0])
            {
                case "noop":
                    CallCycle();
                    break;
                case "addx":
                    CallCycle();
                    CallCycle();
                    X += Convert.ToInt32(c[1]);
                    break;
            }
        }

        static void DrawPixel()
        {
            if(cycleCounter%40-1>=X-1 && cycleCounter%40-1<=X+1)
            {
                Console.Write("#");
            }
            else 
            {
                Console.Write(".");
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("PART 2");
            string file = "assembly.txt";
            StreamReader sr = new StreamReader($@"Data\{file}");

            while (!sr.EndOfStream)
            {
                Command(sr.ReadLine());
            }
            sr.Close();

            Console.WriteLine("\nPART 1");
            int sum = 0;
            foreach(int i in registerStatus)
            {
                sum += i;
            }
            Console.WriteLine(sum);
        }
    }
}