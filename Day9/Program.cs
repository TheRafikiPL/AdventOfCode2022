using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Day9
{
    public class Cords : IEquatable<Cords>
    {
        public int x;
        public int y;
        public Cords(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public Cords()
        {
            x = 0;
            y = 0;
        }

        public bool Equals(Cords? other)
        {
            if(x==other.x && y==other.y)
            {
                return true;
            }
            return false;
        }
    }
    public class Line
    {
        Cords H;
        Cords T;
        public List<Cords> visited;
        public Line()
        {
            visited = new List<Cords>();
            H = new Cords();
            T = new Cords();
        }
        public void GoRight()
        {
            if(Math.Abs(H.x+1-T.x)>1 || Math.Abs(H.y - T.y) > 1)
            {
                T.x = H.x;
                T.y = H.y;
                if (!visited.Contains(T))
                {
                    visited.Add(new Cords(H.x, H.y));
                }
            }
            H.x++;
        }
        public void GoLeft()
        {
            if (Math.Abs(H.x - 1 - T.x) > 1 || Math.Abs(H.y - T.y) > 1)
            {
                T.x = H.x;
                T.y = H.y;
                if (!visited.Contains(T))
                {
                    visited.Add(new Cords(T.x,T.y));
                }
            }
            H.x--;
        }
        public void GoUp()
        {
            if (Math.Abs(H.x - T.x) > 1 || Math.Abs(H.y+1 - T.y) > 1)
            {
                T.x = H.x;
                T.y = H.y;
                if (!visited.Contains(T))
                {
                    visited.Add(new Cords(T.x, T.y));
                }
            }
            H.y++;
        }
        public void GoDown()
        {
            if (Math.Abs(H.x - T.x) > 1 || Math.Abs(H.y - 1 - T.y) > 1)
            {
                T.x = H.x;
                T.y = H.y;
                if (!visited.Contains(T))
                {
                    visited.Add(new Cords(T.x, T.y));
                }
            }
            H.y--;
        }
    }

    public class Line2
    {
        Cords[] T;
        public List<Cords> visited;
        public Line2()
        {
            visited = new List<Cords>();
            T = new Cords[10]
            {
                new Cords(),
                new Cords(),
                new Cords(),
                new Cords(),
                new Cords(),
                new Cords(),
                new Cords(),
                new Cords(),
                new Cords(),
                new Cords()
            };
        }
        public void Move(int X, int Y, int i = 0)
        {
            T[i].x += X;
            T[i].y += Y;
            CheckLastCords();
            if (i < 9)
            {
                if (Math.Pow(T[i + 1].x - T[i].x, 2) + Math.Pow(T[i + 1].y - T[i].y, 2) > 2)
                {
                    Move(Math.Sign(T[i].x - T[i + 1].x), Math.Sign(T[i].y - T[i + 1].y), i + 1);
                }
            }
        }
        public void CheckLastCords()
        {
            if (!visited.Contains(T[9]))
            {
                visited.Add(new Cords(T[9].x, T[9].y));
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "planks.txt";

            Line line = new Line();
            line.visited.Add(new Cords());
            StreamReader sr =  new StreamReader($@"Data\{file}");
            
            while(!sr.EndOfStream)
            {
                string[] s = sr.ReadLine().Split(' ');
                switch(s[0])
                {
                    case "R":
                        for (int i = 0; i < Convert.ToInt32(s[1]); i++)
                        {
                            line.GoRight();
                        }
                        break;
                    case "U":
                        for (int i = 0; i < Convert.ToInt32(s[1]); i++)
                        {
                            line.GoUp();
                        }
                        break;
                    case "L":
                        for (int i = 0; i < Convert.ToInt32(s[1]); i++)
                        {
                            line.GoLeft();
                        }
                        break;
                    case "D":
                        for (int i = 0; i < Convert.ToInt32(s[1]); i++)
                        {
                            line.GoDown();
                        }
                        break;
                }
            }
            Console.WriteLine(line.visited.Count);
            /*foreach(Cords c in line.visited)
            {
                Console.WriteLine($"{c.x}, {c.y}");
            }*/
            sr.Close();

            Line2 line2 = new Line2();
            line2.visited.Add(new Cords());
            sr = new StreamReader($@"Data\{file}");

            while (!sr.EndOfStream)
            {
                string[] s = sr.ReadLine().Split(' ');
                switch (s[0])
                {
                    case "R":
                        for (int i = 0; i < Convert.ToInt32(s[1]); i++)
                        {
                            line2.Move(1,0);
                        }
                        break;
                    case "U":
                        for (int i = 0; i < Convert.ToInt32(s[1]); i++)
                        {
                            line2.Move(0,1);
                        }
                        break;
                    case "L":
                        for (int i = 0; i < Convert.ToInt32(s[1]); i++)
                        {
                            line2.Move(-1,0);
                        }
                        break;
                    case "D":
                        for (int i = 0; i < Convert.ToInt32(s[1]); i++)
                        {
                            line2.Move(0,-1);
                        }
                        break;
                }
            }
            Console.WriteLine(line2.visited.Count);
            /*foreach(Cords c in line2.visited)
            {
                Console.WriteLine($"{c.x}, {c.y}");
            }*/
            sr.Close();
        }
    }
}